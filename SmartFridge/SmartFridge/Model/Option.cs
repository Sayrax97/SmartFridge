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
    }
}