using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;

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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.create_account_layout);
            Init();
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            groupCheckBox.CheckedChange += GroupCheckBox_CheckedChange;

        }

        private void GroupCheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (groupCheckBox.Checked == false)
            {
                groupIdEditText.Visibility = ViewStates.Gone;
            }
            else
            {
                groupIdEditText.Visibility = ViewStates.Visible;
            }
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

        private void OkButton_Click(object sender, EventArgs e)
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
            else if(groupIdEditText.Visibility == ViewStates.Visible && groupIdEditText.Length()!=7 
                                                                     && IsIdAvailable((int.Parse(groupIdEditText.Text))))
            {
                Toast.MakeText(this, "Polje za ID grupe nema 7 broja ili broj grupe vecp postoji", ToastLength.Short).Show();
            }
            else
            {
                User user=new User(nameEditText.Text,surnameEditText.Text,usernameEditText.Text,
                passwordEditText.Text,emailEditText.Text,"");
                if (groupIdEditText.Visibility != ViewStates.Gone)
                {
                    int groupId = int.Parse(groupIdEditText.Text);
                    user.AddToGroup(groupId);
                    ChamberOfSecrets.Instance.group.AddMember(user);
                }
                else
                {
                    Random random = new Random();
                    int randomNum =random.Next(1, 9999999);
                    user.AddToGroup(randomNum);
                    ChamberOfSecrets.Instance.group.AddMember(user);
                }
                
                Intent intent=new Intent(this, typeof(MainActivity));
                intent.PutExtra("user", JsonConvert.SerializeObject(user));
                StartActivity(intent);
            }
        }

        private bool IsIdAvailable(int id)
        {
            return true;
        }
    }
}