using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;
using SmartFridge.WebReference;

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
            this.RequestedOrientation = ScreenOrientation.Portrait;
            loginButton.Click += LoginButton_ClickAsync;
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

        private async void LoginButton_ClickAsync(object sender, EventArgs e)
        {
            Connect();
            User user= new User();
            user.ToUser(await Task.Run(() => ChamberOfSecrets.Proxy.dbFindUser(usernameEditText.Text)));

            if (user.Password == "")
            {
                Toast.MakeText(this, "Korisnik ne postoji. Proverite da li ste lepo ukucali korisničko ime!", ToastLength.Long).Show();
                return;
            }

            if(user.Password == passwordEditText.Text)
            {

                var intent=new Intent(this,typeof(MainActivity));
                ChamberOfSecrets.Instance.LoggedUser = user;

                ChamberOfSecrets.Instance.LoggedUser.MyOptions.ToOption(await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbGetOptions(user.UserName)));

                ChamberOfSecrets.Instance.@group.Id = user.MyGroup;
                ChamberOfSecrets.Instance.@group.MyGroupMembers= await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbInMyGroup(user.MyGroup).ToList());

                ChamberOfSecrets.Instance.@group.AvailableGroceries.ToAvailableGroceries(await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbGetAvailableGroceries(user.MyGroup).ToList()));

                ChamberOfSecrets.Instance.@group.ShoppingCart.ToShoppingCart( await Task.Run(() => 
                    ChamberOfSecrets.Proxy.dbGetShoppingCart(user.MyGroup).ToList()));
                
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