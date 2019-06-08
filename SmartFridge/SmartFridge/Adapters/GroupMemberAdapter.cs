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
        private List<string> status;

        public GroupMemberAdapter(Group myGroup, Context context)
        {
            this.myGroup = myGroup;
            this.context = context;
            status = new List<string>
            {
                Status.Potrosac.ToString(),
                Status.Nabavljac.ToString()
            };
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
            remove.Visibility = ViewStates.Invisible;
            Spinner spinner = convertView.FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.Visibility = ViewStates.Invisible;
            name.Text = myGroup.MyGroupMembers[position];

            void RemoveClick(object sender, EventArgs e)
            {
                ChamberOfSecrets.Instance.group.MyGroupMembers.RemoveAt(position);
                ChamberOfSecrets.Proxy.dbDeleteUserFromGroup(ChamberOfSecrets.Instance.group.MyGroupMembers[position]);
                if (context is MyGroupActivity activity)
                {
                    activity.Update();
                }
            }

            if (ChamberOfSecrets.Instance.LoggedUser.UserStatus == Status.Supervizor ||
                ChamberOfSecrets.Instance.LoggedUser.UserStatus == Status.Administrator)
            {
                remove.Visibility = ViewStates.Visible;
                spinner.Visibility = ViewStates.Visible;
                remove.Click += RemoveClick;
                spinner.Adapter= new ArrayAdapter(context,Resource.Layout.support_simple_spinner_dropdown_item,status);
                spinner.ItemSelected += SpinnerItemSelected;
            }

            return convertView;
        }


        public void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spin = (Spinner)sender;
            string toast = string.Format($"Selected {spin.GetItemAtPosition(e.Position)}");
            Toast.MakeText(context, toast, ToastLength.Long).Show();
        }

        public override int Count => myGroup.MyGroupMembers.Count;

        public override string this[int position] =>myGroup.MyGroupMembers[position] ;
    }
}