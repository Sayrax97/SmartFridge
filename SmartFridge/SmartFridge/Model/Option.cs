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
using SmartFridge.WebReference;

namespace SmartFridge.Model
{
    public class Option
    {
        public string Theme { get; set; }
        public string Font { get; set; }
        public bool Notifications { get; set; }

        public Option()
        {
            Theme = "Dark";
            Font = "default";
            Notifications = true;
        }

        public Option(string theme, string font)
        {
            Theme = theme;
            Font = font;
            Notifications = true;
        }

        public void TurnOffNotifications()
        {
            Notifications = false;
        }

        public void TurnOnNotifications()
        {
            Notifications = true;
        }

        public void ToOption(OptionDetails details)
        {
            Theme = details.Theme;
            Font = details.Font;
            Notifications = details.Notification;
        }

        public OptionDetails ToOptionDetails()
        {
            OptionDetails od= new OptionDetails();
            od.Font = Font;
            od.Notification = Notifications;
            od.Theme = Theme;
            od.UserNickname = ChamberOfSecrets.Instance.LoggedUser.UserName;
            return od;
        }
    }
}