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
    class User
    {
        public User(string name, string surName, string password, string email, string image)
        {
            Name = name;
            SurName = surName;
            Password = password;
            Email = email;
            Image = image;
        }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string MyGroup { get; set; }
        public Option MyOptions { get; set; }

        void AddToGroup(string group)
        {
            MyGroup = group;
        }

        void AddOptions(Option options)
        {
            MyOptions = options;
        }
    }
}