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
    public class AvailableGroceries
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
            if (Groceries.Exists(x => x.Name==grocery.Name))
            {
               Groceries.Find(x => x.Equals(grocery)).Amount += grocery.Amount;
            }
            else
            {
                grocery.IsInList = true;
                Groceries.Add(grocery);

            }
        }

        public void AddToList(Grocery grocery,double amount)
        {
            if (Groceries.Exists(x => x.Name==grocery.Name))
            {
                Groceries.Find(x => x.Equals(grocery)).Amount += amount;
            }
            else
            {
                grocery.IsInList = true;
                grocery.Amount = amount;
                Groceries.Add(grocery);

            }
        }

        public void FilterByName(string name)
        {
            if(!string.IsNullOrEmpty(name))
            foreach (Grocery grocery in Groceries)
            {
                if(!grocery.Name.ToLower().Contains(name.ToLower()))
                    grocery.IsInList=false;
                else
                {
                    grocery.IsInList = true;
                }
            }
            else
            {
                foreach (Grocery grocery in Groceries)
                {
                        grocery.IsInList = true;

                }
            }
        }

        public void FilterByType(Category type)
        {
            if(type!=Category.None)
            foreach (Grocery grocery in Groceries)
            {
                    if (grocery.Type != type)
                    grocery.IsCategorized = false;
                    else
                    {
                        grocery.IsCategorized = true;
                    }

            }
            else
            {
                foreach (Grocery grocery in Groceries)
                {
                    grocery.IsCategorized = true;
                }
            }
        }

        public void SetDefault()
        {
            foreach (var grocery in Groceries)
            {
                grocery.Default();
            }
        }
    }
}