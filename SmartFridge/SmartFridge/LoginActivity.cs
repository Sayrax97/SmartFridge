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
        private ProgressBar loadingProgressBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);
            Init();
            this.RequestedOrientation = ScreenOrientation.Portrait;
            loginButton.Click += LoginButton_ClickAsync;
            createAccountButton.Click += CreateAccountButton_Click;

        }


        protected override async void OnResume()
        {
            base.OnResume();
            while (!IsOnline())
            {
                Toast.MakeText(this, "Niste povezani na internet!!!", ToastLength.Short).Show();
                await Task.Delay(5000);
            }

            await Task.Run(()=>ChamberOfSecrets.Instance.AllGroceries.ToAllGroceries(ChamberOfSecrets.Proxy.dbGetgroceriesName().ToList()));
            await Task.Run(()=>ChamberOfSecrets.Instance.@group.ToRecipes(ChamberOfSecrets.Proxy.dbLoadRecipe().ToList()));
        }

        private void Init()
        {
            usernameEditText = FindViewById<EditText>(Resource.Id.editTxtUsername);
            passwordEditText = FindViewById<EditText>(Resource.Id.editTxtPassword);
            loginButton = FindViewById<Button>(Resource.Id.btnLogin);
            createAccountButton = FindViewById<Button>(Resource.Id.btnCreateAcc);
            loadingProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            loadingProgressBar.Visibility = ViewStates.Invisible;
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(CreateAccountActivity));
        }

        private async void LoginButton_ClickAsync(object sender, EventArgs e)
        {
            await Task.Delay(500);
            if (!IsOnline())
            {
                Toast.MakeText(this, "Niste povezani na internet!!!", ToastLength.Short).Show();
                return;
            }
            loadingProgressBar.Visibility = ViewStates.Visible;
            User user= new User();
            if (string.IsNullOrEmpty(passwordEditText.Text))
            {
                Toast.MakeText(this, "Unesite sifru", ToastLength.Long).Show();
                loadingProgressBar.Visibility = ViewStates.Invisible;
                return;
            }
            bool findUserResult = false;
            bool x = true;
            await Task.Run(() => ChamberOfSecrets.Proxy.dbFindUserBool(usernameEditText.Text,out findUserResult, out x));
            if (!findUserResult)
            {
                Toast.MakeText(this, "Korisnik ne postoji.Proverite da li ste lepo ukucali korisničko ime!", ToastLength.Long).Show();
                loadingProgressBar.Visibility = ViewStates.Invisible;
                return;
            }

            user.ToUser(await Task.Run(() =>
                ChamberOfSecrets.Proxy.dbFindUser(usernameEditText.Text, passwordEditText.Text)));
            if (user.Password == null)
            {
                Toast.MakeText(this, "Pogrešili ste šifru!!!", ToastLength.Long).Show();
                loadingProgressBar.Visibility = ViewStates.Invisible;
                return;
            }
            else
            {
                user.Password = passwordEditText.Text;
                var intent =new Intent(this,typeof(MainActivity));
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
                loadingProgressBar.Visibility = ViewStates.Invisible;
                Finish();
            }
        }
        public bool IsOnline()
        {
            ConnectivityManager manager = (ConnectivityManager) this.GetSystemService(Context.ConnectivityService);
            if (manager == null)
                return false;
            NetworkInfo networkInfo = manager.ActiveNetworkInfo;

            return networkInfo != null && networkInfo.IsConnected;
        }
    }
}