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
    public enum Status
    {
        Potrosac,
        Nabavljac,
        Supervizor,
        Administrator
    }

    public class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public Status UserStatus { get; set; }
        public string MyGroup { get; set; }
        public Option MyOptions { get; set; }

        public User()
        {
            this.UserName = "";
            Password = "";
            Name = "";
            SurName = "";
            Email = "";
            MyOptions = new Option();
            MyGroup = "";
            UserStatus = Status.Potrosac;
        }

        public User(string name, string surName, string userName, string password, string email, string image)
        {
            Name = name;
            SurName = surName;
            UserName = userName;
            Password = password;
            Email = email;
            Image = image;
            UserStatus = Status.Potrosac;
            MyOptions= new Option();
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

        public void ToUser(UserDetails user)
        {
            if (user!=null)
            {
                this.UserName = user.UserName;
                Password = user.Password;
                Name = user.Name;
                SurName = user.Surname;
                Email = user.Email;
                UserStatus = Grocery.ParseEnum<Status>(user.Status);
                MyOptions = new Option();
                MyGroup = user.MyGroup;
            }
        }

        public UserDetails ToUserDetails()
        {
                UserDetails details=new UserDetails();
                details.UserName = UserName;
                details.Password = Password;
                details.Name = Name;
                details.Surname = SurName;
                details.Email = Email;
                details.MyGroup = MyGroup;
                details.Status = UserStatus.ToString();
                details.Image = "";
                return details;
        }
    }
}