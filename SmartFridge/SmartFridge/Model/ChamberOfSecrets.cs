using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SmartFridge.WebReference;

namespace SmartFridge.Model
{
    public class ChamberOfSecrets
    {
        private static ChamberOfSecrets _instance = null;
        private static Service1 _proxy= null;
        private static object locker = true;

        public static ChamberOfSecrets Instance
        {
            get
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new ChamberOfSecrets();
                    }
                }
                return _instance;
            }
        }

        public static Service1 Proxy
        {
            get
            {
                lock (locker)
                {
                    if (_proxy == null)
                    {
                        _proxy = new Service1();
                        AvailableGroceriesDetails details=new AvailableGroceriesDetails();
                    }
                }
                return _proxy;
            }
        }

        public Group group { get; set; }
        public User LoggedUser { get; set; }
        public AvailableGroceries AllGroceries { get; set; }

        protected ChamberOfSecrets()
        {
            LoggedUser= new User();
            AllGroceries = new AvailableGroceries();
            group = new Group();
        }

    }
}