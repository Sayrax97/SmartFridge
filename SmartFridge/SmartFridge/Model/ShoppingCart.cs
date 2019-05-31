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
            //proxy

            if (Groceries.Exists(x => x.Name==grocery.Name))
            {

                    Groceries.Find(x => x.Name == grocery.Name).Amount += grocery.Amount;
            }
            else
            {
                Groceries.Add(grocery);

            }
        }

        public void Buy(Grocery grocery)
        {
            //proxy
            if (grocery.Bought!=0)
            {
                ChamberOfSecrets.Instance.group.AvailableGroceries.AddToList(grocery, grocery.Bought);
                if ((Groceries.Find(x => x.Name == grocery.Name).Amount -= grocery.Bought) <= 0)
                {
                    RemoveFromShoppingCart(grocery);
                }
                else
                    Groceries.Find(x => x.Name == grocery.Name).Bought = 0;
            }
            else if(grocery.Bought == 0)
            {
                ChamberOfSecrets.Instance.group.AvailableGroceries.AddToList(grocery, grocery.Amount);
                    RemoveFromShoppingCart(grocery);
            }
        }

        public void RemoveFromShoppingCart(Grocery grocery)
        {
            //proxy
            Groceries.Remove(grocery);
        }

        public void ToShoppingCart(List<ShoppingCartDetails> details)
        {
            if(details.Count!=0)
            {
                foreach (var grocery in details)
                {
                    Grocery newGrocery= new Grocery(grocery.Grocery.Name,Grocery.ParseEnum<Unit>(grocery.Grocery.Unit),Grocery.ParseEnum<Category>(grocery.Grocery.Category),grocery.Amount);
                    Groceries.Add(newGrocery);
                }
            }
            else
            {
                Groceries=new List<Grocery>();
            }
        }
    }
}