﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;
using System.ServiceModel;
using Android.Graphics;
using Android.Net;
using SmartFridge.WebReference;
using Option = SmartFridge.Model.Option;

namespace SmartFridge
{
    [Activity(Label = "@string/create_acc")]
    public class CreateAccountActivity : Activity
    {
        private EditText usernameEditText;
        private EditText passwordEditText;
        private EditText emailEditText;
        private EditText nameEditText;
        private EditText surnameEditText;
        private ImageButton pictureImageButton;
        private TextView choosePicTextView;
        private Button okButton;
        private Button cancelButton;
        private CheckBox groupCheckBox;
        private EditText groupIdEditText;
        private string random;
        private byte[] bitData;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.create_account_layout);
            Init();
            this.RequestedOrientation = ScreenOrientation.Portrait;
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            groupCheckBox.CheckedChange += GroupCheckBox_CheckedChange;

        }
        private void GroupCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            groupIdEditText.Visibility = groupCheckBox.Checked == false ? ViewStates.Gone : ViewStates.Visible;
        }

        private void Init()
        {
            usernameEditText = FindViewById<EditText>(Resource.Id.editTxtUserNameCreateAcc);
            passwordEditText = FindViewById<EditText>(Resource.Id.editTxtPasswordCreateAcc);
            emailEditText = FindViewById<EditText>(Resource.Id.editTxtEmailCreateAcc);
            nameEditText = FindViewById<EditText>(Resource.Id.editTxtNameCreateAcc);
            surnameEditText = FindViewById<EditText>(Resource.Id.editTxtSurNameCreateAcc);
            pictureImageButton = FindViewById<ImageButton>(Resource.Id.imagebtnPictureCreateAcc);
            pictureImageButton.Click += PictureImageButton_Click;
            okButton = FindViewById<Button>(Resource.Id.btnOkCreateAcc);
            cancelButton = FindViewById<Button>(Resource.Id.btnCancelCreateAcc);
            groupCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxGroup);
            groupIdEditText = FindViewById<EditText>(Resource.Id.editTxtGroupID);
            groupCheckBox.Checked = false;
            if (groupCheckBox.Checked == false)
            {
                groupIdEditText.Visibility = ViewStates.Gone;
            }
            var memStream = new MemoryStream();
            Bitmap defaultUserBitmap = BitmapFactory.DecodeResource(Resources,
                Resource.Drawable.blank_user);
            defaultUserBitmap.Compress(Bitmap.CompressFormat.Png, 0, memStream);
            var scaled = Bitmap.CreateScaledBitmap(defaultUserBitmap, 250, 250, false);
            pictureImageButton.SetImageBitmap(scaled);
            bitData = memStream.ToArray();
        }

        private void PictureImageButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Izaberite sliku"), 2);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode==2)
            {
                Stream stream = ContentResolver.OpenInputStream(data.Data);
                var bitmap = BitmapFactory.DecodeStream(stream);
                var bitmapScaled = Bitmap.CreateScaledBitmap(bitmap, 250, 250, false);
                pictureImageButton.SetImageBitmap(bitmapScaled);
                var memStream = new MemoryStream();
                var bitmapScaled2 = Bitmap.CreateScaledBitmap(bitmap, 500, 500, false);
                bitmapScaled2.Compress(Bitmap.CompressFormat.Png, 0, memStream);
                bitData = memStream.ToArray();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ChamberOfSecrets.Instance.AllGroceries=new AvailableGroceries();
            Finish();
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            if (!IsOnline())
            {
                Toast.MakeText(this, "Ne možete napraviti nalog ako niste povezani na internet. Pokušajte ponovo!!!", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrEmpty(usernameEditText.Text))
            {
                Toast.MakeText(this, "Polje za korisničko ime ne sme biti prazno", ToastLength.Short).Show();
                return;
            }
            else if(string.IsNullOrEmpty(passwordEditText.Text))
            { 
                Toast.MakeText(this, "Polje za šifru ne sme biti prazno", ToastLength.Short).Show();
                return;
            }
            else if (string.IsNullOrEmpty(emailEditText.Text))
            {
                Toast.MakeText(this, "Polje za email ne sme biti prazno", ToastLength.Short).Show();
                return;
            }
            else if (string.IsNullOrEmpty(nameEditText.Text))
            {
                Toast.MakeText(this, "Polje za ime ne sme biti prazno", ToastLength.Short).Show();
                return;
            }
            else if (string.IsNullOrEmpty(surnameEditText.Text))
            {
                Toast.MakeText(this, "Polje za prezime ne sme biti prazno", ToastLength.Short).Show();
                return;
            }
            else if (groupIdEditText.Visibility == ViewStates.Visible && string.IsNullOrEmpty(groupIdEditText.Text))
            {
                    Toast.MakeText(this, "Polje za grupu ne sme biti prazno", ToastLength.Short).Show();
                    return;
            }
            else
            {
                ChamberOfSecrets.Instance.LoggedUser = new User(nameEditText.Text, surnameEditText.Text, usernameEditText.Text,
                passwordEditText.Text, emailEditText.Text, bitData)
                {
                    MyOptions = new Option()
                };
                bool z = true;
                ChamberOfSecrets.Proxy.dbFindUserBool(ChamberOfSecrets.Instance.LoggedUser.UserName,out var findUserResult,out z);
                if (findUserResult)
                {
                    Toast.MakeText(this, "Korisnik vec postoji!!Promenite korisničko ime!", ToastLength.Short).Show();
                    return;
                }

                if (groupIdEditText.Visibility != ViewStates.Gone)
                {
                    if (await ChamberOfSecrets.Instance.group.CheckGroupAsync(groupIdEditText.Text) == false)
                    {
                        Toast.MakeText(this, "Grupa koju ste uneli ne postoji!Pokusajte ponovo!", ToastLength.Short).Show();
                        return;
                    }

                    ChamberOfSecrets.Instance.group.Id = groupIdEditText.Text;

                    ChamberOfSecrets.Instance.@group.MyGroupMembers = await Task.Run(() =>
                        ChamberOfSecrets.Proxy.dbInMyGroup(ChamberOfSecrets.Instance.group.Id).ToList());

                    ChamberOfSecrets.Instance.LoggedUser.AddToGroup(groupIdEditText.Text);
                    var x = 0;
                    var y = true;
                    ChamberOfSecrets.Proxy.dbInsertUser(ChamberOfSecrets.Instance.LoggedUser.ToUserDetails(), out x, out y);
                    ChamberOfSecrets.Instance.group.AddMember(ChamberOfSecrets.Instance.LoggedUser.UserName);
                    ChamberOfSecrets.Proxy.dbInsertOptions(ChamberOfSecrets.Instance.LoggedUser.MyOptions.ToOptionDetails());
                    ChamberOfSecrets.Proxy.dbModifyUserImage(bitData,ChamberOfSecrets.Instance.LoggedUser.UserName);
                }
                else
                {
                    var x = 0;
                    var y = true;
                    do
                    {
                        random = Guid.NewGuid().ToString().Replace("-", string.Empty)
                            .Replace("+", string.Empty).Substring(0, 9).ToLower();
                    }
                    while (await ChamberOfSecrets.Instance.group.CheckGroupAsync(random));

                    ChamberOfSecrets.Instance.LoggedUser.AddToGroup(random);
                    ChamberOfSecrets.Instance.group.Id = random;
                    ChamberOfSecrets.Instance.LoggedUser.UserStatus = Status.Supervizor;
                    ChamberOfSecrets.Instance.group.AddMember(ChamberOfSecrets.Instance.LoggedUser.UserName);
                    ChamberOfSecrets.Proxy.dbAddGroup(ChamberOfSecrets.Instance.group.ToGroupDetails(),out x,out y);
                    ChamberOfSecrets.Proxy.dbInsertUser(ChamberOfSecrets.Instance.LoggedUser.ToUserDetails(), out x, out y);
                    ChamberOfSecrets.Proxy.dbInsertOptions(ChamberOfSecrets.Instance.LoggedUser.MyOptions.ToOptionDetails());
                    ChamberOfSecrets.Proxy.dbModifyUserImage(bitData, ChamberOfSecrets.Instance.LoggedUser.UserName);
                }

                ChamberOfSecrets.Instance.@group.AvailableGroceries.ToAvailableGroceries(await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbGetAvailableGroceries(ChamberOfSecrets.Instance.LoggedUser.MyGroup).ToList()));

                ChamberOfSecrets.Instance.@group.ShoppingCart.ToShoppingCart(await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbGetShoppingCart(ChamberOfSecrets.Instance.LoggedUser.MyGroup).ToList()));

                Intent intent=new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }

        }
        public bool IsOnline()
        {
            ConnectivityManager manager = (ConnectivityManager)this.GetSystemService(Context.ConnectivityService);
            if (manager == null)
                return false;
            NetworkInfo networkInfo = manager.ActiveNetworkInfo;

            return networkInfo != null && networkInfo.IsConnected;
        }

    }
}