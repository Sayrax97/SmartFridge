using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SmartFridge
{
    [Activity(Label = "CreateAccountActivity")]
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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.create_account_layout);
            usernameEditText = FindViewById<EditText>(Resource.Id.editTxtUserNameCreateAcc);
            passwordEditText = FindViewById<EditText>(Resource.Id.editTxtPasswordCreateAcc);
            emailEditText = FindViewById<EditText>(Resource.Id.editTxtEmailCreateAcc);
            nameEditText = FindViewById<EditText>(Resource.Id.editTxtNameCreateAcc);
            surnameEditText = FindViewById<EditText>(Resource.Id.editTxtSurNameCreateAcc);
            pictureImageButton = FindViewById<ImageButton>(Resource.Id.imagebtnPictureCreateAcc);
            okButton = FindViewById<Button>(Resource.Id.btnOkCreateAcc);
            cancelButton = FindViewById<Button>(Resource.Id.btnCancelCreateAcc);
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;


        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}