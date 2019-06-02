using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.IO;
using Newtonsoft.Json;
using SmartFridge.Dialogs;
using SmartFridge.Model;
using Stream = System.IO.Stream;
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
            this.RequestedOrientation = ScreenOrientation.Portrait;
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
            profilePictureImageButton.Click += ProfilePictureImageButton_Click;
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarMyProfile);
            changeUsernameButton = FindViewById<Button>(Resource.Id.btnChangeUsername);
            changeUsernameButton.Click += ChangeUsernameButton_Click;
            changePasswordButton = FindViewById<Button>(Resource.Id.btnChangePassword);
            changePasswordButton.Click += ChangePasswordButton_Click;

            user = ChamberOfSecrets.Instance.LoggedUser;
            userNameTextView.Text = user.UserName;
            passwordTextView.Text = ToPassword(user.Password);
            nameTextView.Text = user.Name;
            surNameTextView.Text = user.SurName;
            emailTextView.Text = user.Email;

            Bitmap bitmap = BitmapFactory.DecodeByteArray(ChamberOfSecrets.Instance.LoggedUser.Image,
                0, ChamberOfSecrets.Instance.LoggedUser.Image.Length);
            profilePictureImageButton.SetImageBitmap(bitmap);
        }

        private void ProfilePictureImageButton_Click(object sender, EventArgs e)
        {
            Intent intent= new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent,"Izabrite sliku"),0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                Stream stream = ContentResolver.OpenInputStream(data.Data);
                var bitmap = BitmapFactory.DecodeStream(stream);
                var bitmapScaled = Bitmap.CreateScaledBitmap(bitmap, 500, 500, false);
                profilePictureImageButton.SetImageBitmap(bitmapScaled);
                byte[] bitmapData;
                var memStream = new MemoryStream();
                bitmapScaled.Compress(Bitmap.CompressFormat.Png, 0, memStream);
                ChamberOfSecrets.Instance.LoggedUser.Image = memStream.ToArray();
                //ChamberOfSecrets.Proxy.dbModifyUserImage(bitmapData,ChamberOfSecrets.Instance.LoggedUser.UserName);
            }
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            Fragment prev = FragmentManager.FindFragmentByTag("Promena Sifre");
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);
            ChangePasswordDialog newFragment = new ChangePasswordDialog();
            newFragment.Show(ft, "Promena Sifre");
        }
        
        private void ChangeUsernameButton_Click(object sender, EventArgs e)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            Fragment prev = FragmentManager.FindFragmentByTag("Promena Username");
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);
            ChangeUsernameDialog newFragment = new ChangeUsernameDialog();
            newFragment.Show(ft, "Promena Username");
        }
        private string ToPassword(string s)
        {
            var p="";
            for (var i = 0; i < s.Length; i++)
                p += "*";
            return p;
        }
        //public byte[] ConvertBitMapToByteArray(Bitmap bitmap)
        //{
        //    byte[] result = null;

        //    if (bitmap != null)
        //    {
        //        MemoryStream stream = new MemoryStream();
        //        bitmap.(stream, bitmap.RawFormat);
        //        result = stream.ToArray();
        //    }

        //    return result;
        //}
    }
}