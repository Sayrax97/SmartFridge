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
    public class ShoppingCart
    {
        public  List<Grocery> Groceries { get; set; }

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
            
            if (Groceries.Exists(x => x.Equals(grocery)))
            {

                    Groceries.Find(x => x.Equals(grocery)).Amount += grocery.Amount;
            }
            else
            {
                Groceries.Add(grocery);

            }
        }

        public void Buy(Grocery grocery)
        {
            if (grocery.Bought!=0)
            {
                ChamberOfSecrets.Instance.availableGroceries.AddToList(grocery, grocery.Bought);
                if ((Groceries.Find(x => x.Equals(grocery)).Amount -= grocery.Bought) <= 0)
                    {
                        RemoveFromShoppingCart(grocery);
                    }
                else
                Groceries.Find(x => x.Equals(grocery)).Bought = 0;
            }
            else if(grocery.Bought == 0)
            {
                ChamberOfSecrets.Instance.availableGroceries.AddToList(grocery, grocery.Amount);
                    RemoveFromShoppingCart(grocery);
            }
        }

        public void RemoveFromShoppingCart(Grocery grocery)
        {
            Groceries.Remove(grocery);
        }
    }
}