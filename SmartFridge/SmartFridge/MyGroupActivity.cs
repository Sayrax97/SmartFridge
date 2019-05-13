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
using SmartFridge.Adapters;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/my_group",Theme = "@style/AppThemeNoActionBar",NoHistory = true)]
    public class MyGroupActivity : AppCompatActivity
    {
        private ListView groupMembersListView;
        private Toolbar myGroupToolbar;
        public Group MyGroup;
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
            MyGroup= new Group(33,new AvailableGroceries(new List<Grocery>()),new List<User>(),new ShoppingCart(),new AvailableGroceries());
            MyGroup.MyGroupMembers.Add(new User("Dusan","Janakovic","Xamar","distingi97", "dusann.jankovic@elfak.rs",""));
            MyGroup.MyGroupMembers.Add(new User("Matija", "Janic", "AnubisLP", "matko123", "matija.janic@elfak.rs", ""));
            MyGroup.MyGroupMembers.Add(new User("Lazar", "Pavlovic","Brahman_n" ,"perfeks38", "lazarp@elfak.rs", ""));
            GroupMemberAdapter adapter = new GroupMemberAdapter(MyGroup,this);
            groupMembersListView.Adapter = adapter;
        }

    }
}