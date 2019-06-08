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
    public class ChangePasswordDialog : DialogFragment
    {
        private EditText newPasswordEditText;
        private Button changePassButton;
        private Button cancelButton;
        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.change_password_dialog_layout, container, false);
            newPasswordEditText = view.FindViewById<EditText>(Resource.Id.editTxtNewPass);
            changePassButton = view.FindViewById<Button>(Resource.Id.changePassButton);
            changePassButton.Click += ChangePassButton_Click;
            cancelButton = view.FindViewById<Button>(Resource.Id.btnCancelNewPass);
            cancelButton.Click += CancelButton_Click;
            return view;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dismiss();
            Toast.MakeText(Activity, "Promena otkazana", ToastLength.Short).Show();
        }

        private void ChangePassButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newPasswordEditText.Text))
            {
                Toast.MakeText(Activity,"Polje za novu Sifru nesme biti prazno",ToastLength.Short).Show();
                return;
            }

            ChamberOfSecrets.Instance.LoggedUser.Password = newPasswordEditText.Text;
            ChamberOfSecrets.Proxy.dbUpdateUser(ChamberOfSecrets.Instance.LoggedUser.Password,
                ChamberOfSecrets.Instance.LoggedUser.UserName);
            Dismiss();
        }
    }
}