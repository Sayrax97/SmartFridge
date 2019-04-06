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
    [Activity(Label = "MyGroupActivity")]
    public class MyGroupActivity : Activity
    {
        private ListView groupMembersListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.group_layout);
            groupMembersListView = FindViewById<ListView>(Resource.Id.listViewGroupMembers);
        }
    }
}