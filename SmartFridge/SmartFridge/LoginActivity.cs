using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.Net.Wifi;
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
            Init();
            loginButton.Click += LoginButton_Click;
            createAccountButton.Click += CreateAccountButton_Click;
        }

        private void Init()
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
            Connect();
            var group = ChamberOfSecrets.Instance.group;
            string password="";
            User user=new User();
            foreach (var member in group.MyGroupMembers)
            {
                    if (member.UserName == usernameEditText.Text)
                    {
                        password = member.Password;
                        user = member;
                        break;
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

        private void Connect()
        {

            WifiManager wifi = (WifiManager)Application.Context.GetSystemService(WifiService);
            if (wifi.IsWifiEnabled)
            {
                Toast.MakeText(this, "Wifi je vec ukljucen", ToastLength.Short).Show();
            }
            else if (!wifi.IsWifiEnabled)
            {
                wifi.SetWifiEnabled(true);
                Toast.MakeText(this, "Wifi ukljucen", ToastLength.Short).Show();
            }
        }
    }
}