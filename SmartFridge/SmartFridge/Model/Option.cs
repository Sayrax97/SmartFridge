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
        public string Notifications { get; set; }

        public Option(string theme, string font, string notifications)
        {
            Theme = theme;
            Font = font;
            Notifications = notifications;
        }
    }
}