using System;
using System.Collections.Generic;
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
using SmartFridge.WebReference;

namespace SmartFridge
{
    [Activity(Label = "@string/create_acc", NoHistory = true)]
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
            okButton = FindViewById<Button>(Resource.Id.btnOkCreateAcc);
            cancelButton = FindViewById<Button>(Resource.Id.btnCancelCreateAcc);
            groupCheckBox = FindViewById<CheckBox>(Resource.Id.checkBoxGroup);
            groupIdEditText = FindViewById<EditText>(Resource.Id.editTxtGroupID);
            groupCheckBox.Checked = false;
            if (groupCheckBox.Checked == false)
            {
                groupIdEditText.Visibility = ViewStates.Gone;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
           Finish();
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameEditText.Text))
                Toast.MakeText(this, "Polje za korisničko ime ne sme biti prazno", ToastLength.Short).Show();
            else if(string.IsNullOrEmpty(passwordEditText.Text))
            { 
                Toast.MakeText(this, "Polje za šifru ne sme biti prazno", ToastLength.Short).Show();
            }
            else if (string.IsNullOrEmpty(emailEditText.Text))
            {
                Toast.MakeText(this, "Polje za email ne sme biti prazno", ToastLength.Short).Show();
            }
            else if (string.IsNullOrEmpty(nameEditText.Text))
            {
                Toast.MakeText(this, "Polje za ime ne sme biti prazno", ToastLength.Short).Show();
            }
            else if (string.IsNullOrEmpty(surnameEditText.Text))
            {
                Toast.MakeText(this, "Polje za prezime ne sme biti prazno", ToastLength.Short).Show();
            }
            else if (groupIdEditText.Visibility == ViewStates.Visible && !string.IsNullOrEmpty(groupIdEditText.Text))
            {
                    Toast.MakeText(this, "Polje za grupu nesme biti prazno", ToastLength.Short).Show();
            }
            else
            {
                User user=new User(nameEditText.Text,surnameEditText.Text,usernameEditText.Text,
                passwordEditText.Text,emailEditText.Text,"");
                if (groupIdEditText.Visibility != ViewStates.Gone)
                {
                    if (await ChamberOfSecrets.Instance.group.CheckGroupAsync(groupIdEditText.Text) == false)
                    {
                        Toast.MakeText(this, "Grupa koju ste uneli ne postoji!Pokusajte ponovo!", ToastLength.Short).Show();
                        return;
                    }

                    user.AddToGroup(groupIdEditText.Text);
                    var x = 0;
                    var y = true;
                    await Task.Run(()=> ChamberOfSecrets.Proxy.dbInsertUser(user.ToUserDetails(), out x, out y));
                    if (x == 0)
                    {
                        Toast.MakeText(this, "Korisničko ime vec postoji", ToastLength.Short).Show();
                        return;
                    }

                }
                else
                {
                    var x = 0;
                    var y = true;
                    do
                    {
                        random = Guid.NewGuid().ToString().Replace("-", string.Empty)
                            .Replace("+", string.Empty).Substring(0, 9);
                    }
                    while (await ChamberOfSecrets.Instance.group.CheckGroupAsync(random));

                    user.AddToGroup(random);
                    ChamberOfSecrets.Instance.group.Id = random;
                    ChamberOfSecrets.Instance.group.AddMember(user.UserName);
                    //ChamberOfSecrets.Proxy.dbAddGroup(random,out x,out y); exception ako vec postoji grupa
                    await Task.Run(() => ChamberOfSecrets.Proxy.dbInsertUser(user.ToUserDetails(), out x, out y));
                    if (x == 0)
                    {
                        Toast.MakeText(this, "Korisničko ime vec postoji", ToastLength.Short).Show();
                        return;
                    }
                }
                
                Intent intent=new Intent(this, typeof(MainActivity));
                intent.PutExtra("user", JsonConvert.SerializeObject(user));
                StartActivity(intent);
            }

        
        }

    }
}