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

namespace SmartFridge
{
    [Activity(Label = "@string/my_group", MainLauncher = true)]
    public class MyGroupActivity : Activity
    {
        private ListView groupMembersListView;
        private Toolbar myGroupToolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.group_layout);
            groupMembersListView = FindViewById<ListView>(Resource.Id.listViewGroupMembers);
            myGroupToolbar = FindViewById<Toolbar>(Resource.Id.toolbarMyGroup);
            base.SetActionBar(myGroupToolbar);
            ActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
        }
       
    }
}