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
using SmartFridge.Model;

namespace SmartFridge.Adapters
{
    class GroupMemberAdapter:BaseAdapter<string>
    {
        private Group myGroup;
        private Context context;

        public GroupMemberAdapter(Group myGroup, Context context)
        {
            this.myGroup = myGroup;
            this.context = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.group_member, null);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.txtViewGroupMember);
            ImageButton remove = convertView.FindViewById<ImageButton>(Resource.Id.imageBtnRemove);
            ImageButton plus = convertView.FindViewById<ImageButton>(Resource.Id.imageBtnPlus);
            name.Text = myGroup.MyGroupMembers[position];
            return convertView;
        }

        public override int Count
        {
            get { return myGroup.MyGroupMembers.Count; }
        }

        public override string this[int position] =>myGroup.MyGroupMembers[position] ;
    }
}