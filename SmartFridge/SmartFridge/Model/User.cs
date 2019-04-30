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
    public class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string MyGroup { get; set; }
        public Option MyOptions { get; set; }

        public User(string name, string surName, string userName, string password, string email, string image)
        {
            Name = name;
            SurName = surName;
            UserName = userName;
            Password = password;
            Email = email;
            Image = image;
        }

        public void AddToGroup(string group)
        {
            MyGroup = group;
        }

        public void AddOptions(Option options)
        {
            MyOptions = options;
        }

        public override string ToString()
        {

            return Name +" "+ SurName;
        }
    }
}