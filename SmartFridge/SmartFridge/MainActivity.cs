﻿using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/application_name", Theme = "@style/AppThemeNoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar mainTopToolbar;
        private BottomNavigationView mainBottomNavigationView;
        private FrameLayout contentMainFrameLayout;
        private DrawerLayout mainDrawerLayout;
        private NavigationView drawerMainNavigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            init();
            mainTopToolbar.Title = Resources.GetString(Resource.String.application_name);
            SetSupportActionBar(mainTopToolbar);
            drawerMainNavigationView.NavigationItemSelected += OnMenuItemSelected;
            mainBottomNavigationView.NavigationItemSelected += MainBottomNavigationView_NavigationItemSelected;
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_menu_black_24dp);
        }

        private void MainBottomNavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.menu_goceries: StartActivity(typeof(GroceriesActivity)); break;
                case Resource.Id.menu_recipes: StartActivity(typeof(MyGroupActivity)); break;
            }
        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            base.MenuInflater.Inflate(Resource.Menu.main_top_menu, menu);
            mainTopToolbar.Menu.FindItem(Resource.Id.cartMain).SetIcon(Resource.Drawable.baseline_shopping_cart_black_24dp);
            return true;
        }
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.cartMain:
                    StartActivity(typeof(ShoppingCartActivity));
                    break;

                case Android.Resource.Id.Home:
                    mainDrawerLayout.OpenDrawer(GravityCompat.Start);
                    break;
            }
            return true;
        }
        void OnMenuItemSelected(object sender, Android.Support.Design.Widget.NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.myProfileMain: StartActivity(typeof(MyProfileActivity)); break;
                case Resource.Id.myGroupMain: StartActivity(typeof(MyGroupActivity)); break;
                case Resource.Id.settingsMain: StartActivity(typeof(OptionsActivity)); break;
                case Resource.Id.feedbackMain:
                    Intent emailIntent = new Intent(Intent.ActionSendto, Uri.FromParts("mailto", "4infinityteam@gmail.com", null));
                    emailIntent.PutExtra(Intent.ExtraSubject, "Feedback");
                    emailIntent.PutExtra(Intent.ExtraText, "Problem/Suggestion/etc.");
                    StartActivity(Intent.CreateChooser(emailIntent, "Send email..."));
                     break;
                case Resource.Id.logoutMain: StartActivity(typeof(LoginActivity));Finish(); break;

            }
            
            mainDrawerLayout.CloseDrawer(GravityCompat.Start);
        }

        private void init()
        {
            mainTopToolbar = FindViewById<Toolbar>(Resource.Id.toolbarMain);
            drawerMainNavigationView = FindViewById<NavigationView>(Resource.Id.navViewDrawerMain);
            mainBottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.navigationViewMain);
            mainDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerMain);
        }
    }
}