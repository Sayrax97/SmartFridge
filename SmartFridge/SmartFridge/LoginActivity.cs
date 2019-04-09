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
    [Activity(Label = "@string/application_name", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        private EditText usernameEditText;
        private EditText passwordEditText;
        private Button loginButton;
        private Button createAccountButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);
            init();
            loginButton.Click += LoginButton_Click;
            createAccountButton.Click += CreateAccountButton_Click;
        }

        private void init()
        {
            usernameEditText = FindViewById<EditText>(Resource.Id.editTxtUsername);
            passwordEditText = FindViewById<EditText>(Resource.Id.editTxtPassword);
            loginButton = FindViewById<Button>(Resource.Id.btnLogin);
            createAccountButton = FindViewById<Button>(Resource.Id.btnCreateAcc);
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CreateAccountActivity));
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (usernameEditText.Text == "admin" && passwordEditText.Text == "admin")
            {
                StartActivity(typeof(MainActivity));
                Finish();
            }
            else
            {
                Toast.MakeText(this, "pogresno uneto kucaj admin u oba", ToastLength.Long).Show();
            }
        }
    }
}