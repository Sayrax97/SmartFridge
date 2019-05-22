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
using Newtonsoft.Json;
using SmartFridge.Model;

namespace SmartFridge
{
    [Activity(Label = "@string/application_name")]
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
            var groups = ChamberOfSecrets.Instance.groups;
            string password="";
            User user=new User();
            foreach (var group in groups)
            {
                for (int i = 0; i < group.MyGroupMembers.Count; i++)
                {
                    if (group.MyGroupMembers[i].UserName == usernameEditText.Text)
                    {
                        password = group.MyGroupMembers[i].Password;
                        user = group.MyGroupMembers[i];
                        break;
                    }
                }
            }

            if (password == "")
            {
                Toast.MakeText(this, "Korisnik ne postoji. Proverite da li ste lepo ukucali korisničko ime!", ToastLength.Long).Show();
                return;
            }

            if (password==passwordEditText.Text)
            {
                var intent=new Intent(this,typeof(MainActivity));
                intent.PutExtra("user", JsonConvert.SerializeObject(user));
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Pogrsno ste uneli lozinku, pokusajte ponovo!", ToastLength.Long).Show();
            }
        }
    }
}