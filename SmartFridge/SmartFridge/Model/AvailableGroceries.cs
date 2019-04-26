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
    class AvailableGroceries
    {
        public List<Grocery> Groceries { get; set; }

        public AvailableGroceries()
        {
            Groceries=new List<Grocery>();
        }

        public AvailableGroceries(List<Grocery> groceries )
        {
            Groceries = groceries;
        }

        public void AddToList(Grocery grocery)
        {
            if (Groceries.Exists(x => x.Name.Equals(grocery)))
            {
                Grocery g;
                g=Groceries.Find(x => x.Equals(grocery));
                g.Amount += grocery.Amount;
            }
            else
            {
                Groceries.Add(grocery);
                Groceries.Sort();

            }
        }

        public List<Grocery> FilterByName(string name)
        {
            List<Grocery> pom = new List<Grocery>();
            foreach (Grocery grocery in pom)
            {
                if(grocery.Name.Equals(name))
                    pom.Add(grocery);
                
            }
            pom.Sort();
            return pom;
        }

        public List<Grocery> FilterByType(string type)
        {
            List<Grocery> pom = new List<Grocery>();
            foreach (Grocery grocery in pom)
            {
                if (grocery.Type.Equals(type))
                    pom.Add(grocery);

            }
            pom.Sort();
            return pom;
        }

    }
}