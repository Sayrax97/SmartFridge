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
    class ShoppingCart
    {
        public List<Grocery> Groceries { get; set; }

        public ShoppingCart()
        {
            Groceries = new List<Grocery>();
        }

        public ShoppingCart(List<Grocery> groceries)
        {
            Groceries = groceries;
        }

        public void AddToList(Grocery grocery)
        {
            if (Groceries.Exists(x => x.Name.Equals(grocery)))
            {
                Grocery g;
                g = Groceries.Find(x => x.Equals(grocery));
                g.Amount += grocery.Amount;
            }
            else
            {
                Groceries.Add(grocery);

            }
        }

        public void Buy(double amount, Grocery grocery)
        {
            if ((Groceries.Find(x => x.Equals(grocery)).Amount -= amount) <= 0)
                Groceries.Remove(grocery);
        }

        public void RemoveFromShoppingCart(Grocery grocery)
        {
            Groceries.Remove(grocery);
        }
    }
}