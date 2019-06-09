using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private TextView name;
        private bool picked;

        public GroupMemberAdapter(Group myGroup, Context context)
        {
            this.myGroup = myGroup;
            this.context = context;
            status = new List<string>
            {
                Status.Potrosac.ToString(),
                Status.Nabavljac.ToString(),
                Status.Supervizor.ToString(),
                Status.Administrator.ToString()
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
            name = convertView.FindViewById<TextView>(Resource.Id.txtViewGroupMember);
            picked = false;
            ImageButton remove = convertView.FindViewById<ImageButton>(Resource.Id.imageBtnRemove);
            remove.Visibility = ViewStates.Invisible;
            name.Text = myGroup.MyGroupMembers[position];
            Spinner spinner = convertView.FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.Visibility = ViewStates.Invisible;

            void RemoveClick(object sender, EventArgs e)
            {
                ChamberOfSecrets.Proxy.dbDeleteUserFromGroup(ChamberOfSecrets.Instance.group.MyGroupMembers[position]);
                ChamberOfSecrets.Instance.group.MyGroupMembers.RemoveAt(position);
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
                spinner.ItemSelected += SpinnerItemSelected;
                remove.Click += RemoveClick;
                spinner.Adapter= new ArrayAdapter(context,Resource.Layout.support_simple_spinner_dropdown_item,status);
                string userStatus = ChamberOfSecrets.Proxy.dbGetUserStatus(name.Text);
                switch (userStatus)
                {
                    case "Potrosac":
                        spinner.SetSelection(0);
                        break;
                    case "Nabavljac":
                        spinner.SetSelection(1);
                        break;
                    case "Supervizor":
                        spinner.SetSelection(2);
                        break;
                    case "Administrator":
                        spinner.SetSelection(3);
                        break;
                }
                void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
                {
                    Spinner spin = (Spinner)sender;
                    if (picked)
                    {
                        ChamberOfSecrets.Proxy.dbUpdateUserStatus(spin.GetItemAtPosition(e.Position).ToString(),
                            ChamberOfSecrets.Instance.group.MyGroupMembers[position]);
                    }
                    else
                    {
                        picked = true;
                    }
                }
            }

            return convertView;
        }

        public override int Count => myGroup.MyGroupMembers.Count;

        public override string this[int position] =>myGroup.MyGroupMembers[position] ;
    }
}