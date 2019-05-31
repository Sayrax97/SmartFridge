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
            //proxy
            if (Groceries.Exists(x => x.Name==grocery.Name))
            {
               Groceries.Find(x => x.Name==grocery.Name).Amount += grocery.Amount;
            }
            else
            {
                grocery.IsInList = true;
                Groceries.Add(grocery);

            }
        }

        public void AddToList(Grocery grocery,double amount)
        {
            //proxy
            if (Groceries.Exists(x => x.Name==grocery.Name))
            {
                Groceries.Find(x => x.Name==grocery.Name).Amount += amount;
            }
            else
            {
                var gr = new Grocery()
                {
                    IsInList = true,
                    Amount = amount,
                    IsCategorized = true,
                    Bought = 0,
                    Checked = false,
                    Image = grocery.Image,
                    MeasurementUnit = grocery.MeasurementUnit,
                    Type = grocery.Type,
                    Name = grocery.Name
                };
                Groceries.Add(gr);

            }
        }

        public void FilterByName(string name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                foreach (Grocery grocery in Groceries)
                {
                    grocery.IsInList = grocery.Name.ToLower().Contains(name.ToLower());
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
            {
                foreach (Grocery grocery in Groceries)
                {
                    grocery.IsCategorized = grocery.Type == type;
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

        public void ToAvailableGroceries(List<AvailableGroceriesDetails> details)
        {
            foreach (var grocery in details)
            {
                Grocery newGrocery= new Grocery(grocery.Grocery.Name,Grocery.ParseEnum<Unit>(grocery.Grocery.Unit),Grocery.ParseEnum<Category>(grocery.Grocery.Category),grocery.Amount);
                this.AddToList(newGrocery);
            }
        }
        public void ToAllGroceries(List<GroceryDetails> details)
        {
            foreach (var grocery in details)
            {
                Grocery newGrocery = new Grocery(grocery.Name, Grocery.ParseEnum<Unit>(grocery.Unit), Grocery.ParseEnum<Category>(grocery.Category),0);
                this.AddToList(newGrocery);
            }
        }

        public void RemoveFromList(string name)
        {
            //proxy
            Groceries.Remove(Groceries.Find(x => x.Name == name));
        }
    }
}