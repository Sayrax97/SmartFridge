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
    class ChangeUsernameDialog:DialogFragment
    {
        private EditText newUsernameEditText;
        private Button changenewUsernameButton;
        private Button cancelButton;
        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.change_username_dialog, container, false);
            newUsernameEditText = view.FindViewById<EditText>(Resource.Id.editTxtNewUserName);
            changenewUsernameButton = view.FindViewById<Button>(Resource.Id.changeToNewUserNameButton);
            changenewUsernameButton.Click += ChangeNewUsernameButton_Click;
            cancelButton = view.FindViewById<Button>(Resource.Id.btnCancelNewUsername);
            cancelButton.Click += CancelButton_Click;
            return view;
        }

        private void ChangeNewUsernameButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(changenewUsernameButton.Text))
            {
                Toast.MakeText(Activity, "Polje za novo Korisničko ime nesme biti prazno", ToastLength.Short).Show();
                return;
            }

            //ChamberOfSecrets.Proxy.dbUpdateUser(ChamberOfSecrets.Instance.LoggedUser.UserName, 
            //    ChamberOfSecrets.Instance.LoggedUser.UserName);
            ChamberOfSecrets.Instance.LoggedUser.UserName = newUsernameEditText.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dismiss();
            Toast.MakeText(Activity, "Promena otkazana", ToastLength.Short).Show();
        }
    }
}