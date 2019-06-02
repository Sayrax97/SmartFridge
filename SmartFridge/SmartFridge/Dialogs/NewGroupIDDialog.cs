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

namespace SmartFridge.Dialogs
{
    class NewGroupIdDialog:DialogFragment
    {
        private EditText newIdEditText;
        private Button addGroupId;
        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.no_group_dialog, container, false);
            newIdEditText = view.FindViewById<EditText>(Resource.Id.editTxtNewGroupId);
            addGroupId = view.FindViewById<Button>(Resource.Id.okButtonIDGroup);
            addGroupId.Click += AddGroupId_Click;
            return view;
        }

        private void AddGroupId_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newIdEditText.Text))
            {
                Toast.MakeText(Activity, "Polje za novu Sifru nesme biti prazno", ToastLength.Short).Show();
                return;
            }

            int x = 0;
            bool y = true;
            ChamberOfSecrets.Instance.group.Id = newIdEditText.Text;
            //ChamberOfSecrets.Proxy.dbAddToGroup(ChamberOfSecrets.Instance.LoggedUser.UserName, ChamberOfSecrets.Instance.group.Id,out x,out y);
            Dismiss();
        }
    }
}