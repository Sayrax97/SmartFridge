using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Graphics;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/my_group",Theme = "@style/AppThemeNoActionBar",NoHistory = true)]
    public class MyGroupActivity : AppCompatActivity
    {
        private ListView groupMembersListView;
        private Toolbar myGroupToolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.group_layout);
            init();
            myGroupToolbar.SetTitle(Resource.String.my_group);
            base.SetSupportActionBar(myGroupToolbar);
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

        private void init()
        {
            groupMembersListView = FindViewById<ListView>(Resource.Id.listViewGroupMembers);
            myGroupToolbar = FindViewById<Toolbar>(Resource.Id.toolbarMyGroup);
        }

    }
}