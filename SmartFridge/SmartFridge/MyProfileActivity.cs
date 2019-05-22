using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/my_profile", Theme = "@style/AppThemeNoActionBar")]
    public class MyProfileActivity : AppCompatActivity
    {
        private TextView userNameTextView;
        private TextView passwordTextView;
        private TextView nameTextView;
        private TextView surNameTextView;
        private TextView emailTextView;
        private ImageButton profilePictureImageButton;
        private Button changeUsernameButton;
        private Button changePasswordButton;
        private Toolbar topToolbar;
        private User user;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.my_profile_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.my_profile);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
        }
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }
            return true;
        }
        private void Init()
        {
            userNameTextView = FindViewById<TextView>(Resource.Id.textViewUsername);
            passwordTextView = FindViewById<TextView>(Resource.Id.textViewPassword);
            nameTextView = FindViewById<TextView>(Resource.Id.textViewName);
            surNameTextView = FindViewById<TextView>(Resource.Id.textViewSurName);
            emailTextView = FindViewById<TextView>(Resource.Id.textViewEmail);
            profilePictureImageButton = FindViewById<ImageButton>(Resource.Id.imageBtnPictureMyProfile);
            changeUsernameButton = FindViewById<Button>(Resource.Id.btnChangeUsername);
            changePasswordButton = FindViewById<Button>(Resource.Id.btnChangePassword);
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarMyProfile);

            user = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("user"));
            userNameTextView.Text = user.UserName;
            passwordTextView.Text = ToPassword(user.Password);
            nameTextView.Text = user.Name;
            surNameTextView.Text = user.SurName;
            emailTextView.Text = user.Email;
        }

        private string ToPassword(string s)
        {
            string p="";
            for (int i = 0; i < s.Length; i++)
                p += "*";
            return p;
        }
    }
}