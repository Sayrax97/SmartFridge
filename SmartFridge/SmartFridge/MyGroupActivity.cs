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
using Newtonsoft.Json;
using SmartFridge.Adapters;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.PM;
using System.Threading.Tasks;

namespace SmartFridge
{
    [Activity(Label = "@string/my_group",Theme = "@style/AppThemeNoActionBar",NoHistory = true)]
    public class MyGroupActivity : AppCompatActivity
    {
        private ListView groupMembersListView;
        private Toolbar myGroupToolbar;
        private TextView groupIdTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.group_layout);
            Init();
            this.RequestedOrientation = ScreenOrientation.Portrait;
            myGroupToolbar.SetTitle(Resource.String.my_group);
            base.SetSupportActionBar(myGroupToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            ChamberOfSecrets.Instance.group.MyGroupMembers = new List<string>();
            ChamberOfSecrets.Instance.@group.MyGroupMembers =
                ChamberOfSecrets.Proxy.dbInMyGroup(ChamberOfSecrets.Instance.LoggedUser.MyGroup).ToList();
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
            groupMembersListView = FindViewById<ListView>(Resource.Id.listViewGroupMembers);
            myGroupToolbar = FindViewById<Toolbar>(Resource.Id.toolbarMyGroup);
            groupIdTextView = FindViewById<TextView>(Resource.Id.txtViewGroupId);
            groupIdTextView.Text = $"ID grupe je: {ChamberOfSecrets.Instance.group.Id}";
            Update();
        }

        public void Update()
        {
            groupMembersListView.Adapter = new GroupMemberAdapter(ChamberOfSecrets.Instance.group, this);
        }

    }
}