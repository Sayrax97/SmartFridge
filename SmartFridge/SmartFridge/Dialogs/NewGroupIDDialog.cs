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
using SmartFridge.WebReference;

namespace SmartFridge.Dialogs
{
    class NewGroupIdDialog:DialogFragment
    {
        private EditText newIdEditText;
        private Button addGroupId;
        private Button newGroupButton;
        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.no_group_dialog, container, false);
            newIdEditText = view.FindViewById<EditText>(Resource.Id.editTxtNewGroupId);
            addGroupId = view.FindViewById<Button>(Resource.Id.okButtonIDGroup);
            newGroupButton = view.FindViewById<Button>(Resource.Id.newGroupButtonIDGroup);
            newGroupButton.Click += NewGroupButton_Click;
            addGroupId.Click += AddGroupId_Click;
            return view;
        }

        private async void NewGroupButton_Click(object sender, EventArgs e)
        {
            string random;
            int x = 0;
            bool y = true;
            do
            {
                random = Guid.NewGuid().ToString().Replace("-", string.Empty)
                    .Replace("+", string.Empty).Substring(0, 9).ToLower();
            }
            while (await ChamberOfSecrets.Instance.group.CheckGroupAsync(random));
            ChamberOfSecrets.Proxy.dbAddGroup(new GroupDetails(){ID = random},out x,out y);
            ChamberOfSecrets.Proxy.dbAddToGroup(ChamberOfSecrets.Instance.LoggedUser.UserName,random,out x,out y);
            ChamberOfSecrets.Proxy.dbUpdateUserStatus("Supervizor",ChamberOfSecrets.Instance.LoggedUser.UserName);
            Dismiss();
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
            ChamberOfSecrets.Proxy.dbAddToGroup(ChamberOfSecrets.Instance.LoggedUser.UserName, newIdEditText.Text, out x,out y);
            if (x == 0)
            {
                Toast.MakeText(this.Activity,"Grupa ne postoji! Pokusajte ponovo!",ToastLength.Short).Show();
                return;
            }
            Dismiss();
            Toast.MakeText(Activity, $"Dodati ste u grupu {newIdEditText.Text}", ToastLength.Short).Show();
        }
    }
}