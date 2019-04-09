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
    [Activity(Label = "@string/my_profile", NoHistory = true)]
    public class MyProfileActivity : Activity
    {
        private TextView userNameTextView;
        private TextView passwordTextView;
        private TextView nameTextView;
        private TextView surNameTextView;
        private TextView emailTextView;
        private ImageButton profilePictureImageButton;
        private Button changeUsernameButton;
        private Button changePasswordButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.my_profile_layout);
            init();
            
        }

        private void init()
        {
            userNameTextView = FindViewById<TextView>(Resource.Id.textViewUsername);
            passwordTextView = FindViewById<TextView>(Resource.Id.textViewPassword);
            nameTextView = FindViewById<TextView>(Resource.Id.textViewName);
            surNameTextView = FindViewById<TextView>(Resource.Id.textViewSurName);
            emailTextView = FindViewById<TextView>(Resource.Id.textViewEmail);
            profilePictureImageButton = FindViewById<ImageButton>(Resource.Id.imageBtnPictureMyProfile);
            changeUsernameButton = FindViewById<Button>(Resource.Id.btnChangeUsername);
            changePasswordButton = FindViewById<Button>(Resource.Id.btnChangePassword);

        }
    }
}