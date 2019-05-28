using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/options", Theme = "@style/AppThemeNoActionBar",NoHistory = true)]
    public class OptionsActivity : AppCompatActivity
    {
        private Toolbar topToolbar;
        private TextView fontTextView;
        private TextView themeTextView;
        private TextView notificationsTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.options_menu_layout);
            Init();
            this.RequestedOrientation = ScreenOrientation.Portrait;
            topToolbar.SetTitle(Resource.String.options);
            base.SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            
        }

        private void Init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarTopOptions);
            fontTextView = FindViewById<TextView>(Resource.Id.txtViewFontOptions);
            themeTextView = FindViewById<TextView>(Resource.Id.txtViewThemeOptions);
            notificationsTextView = FindViewById<TextView>(Resource.Id.txtViewNotificationsOptions);
            fontTextView.Text = ChamberOfSecrets.Instance.LoggedUser.MyOptions.Font;
            themeTextView.Text = ChamberOfSecrets.Instance.LoggedUser.MyOptions.Theme;
            notificationsTextView.Text = ChamberOfSecrets.Instance.LoggedUser.MyOptions.Notifications.ToString();
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
    }
}