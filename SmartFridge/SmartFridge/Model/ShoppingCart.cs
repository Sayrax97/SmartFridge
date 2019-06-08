using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public  AvailableGroceries Groceries { get; set; }

        public ShoppingCart()
        {
            Groceries = new AvailableGroceries();
        }

        public ShoppingCart(AvailableGroceries groceries)
        {
            Groceries = groceries;
        }

        public void AddToList(Grocery grocery)
        {
            //proxy

            if (Groceries.Groceries.Exists(x => x.Name==grocery.Name))
            {

                    Groceries.Groceries.Find(x => x.Name == grocery.Name).Amount += grocery.Amount;
            }
            else
            {
                Groceries.AddToList(grocery);

            }
        }

        public async Task Buy(Grocery grocery)
        {
            if (grocery.Bought!=0)
            {
                ChamberOfSecrets.Instance.group.AvailableGroceries.AddToList(grocery, grocery.Bought);
                Grocery g = new Grocery()
                {
                    Name = grocery.Name,
                    Amount = grocery.Bought,
                    Bought = 0,
                    Type = grocery.Type,
                    MeasurementUnit = grocery.MeasurementUnit
                };
                await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbAvailableGroceriesInsert(g.ToAvaliableAvailableGroceriesDetails()));

                Groceries.Groceries.Find(x => x.Name == grocery.Name).Amount-=grocery.Bought;
                await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbUpdateShoppingCart((float)Groceries.Groceries.Find(x => x.Name == grocery.Name).Amount
                        , true,grocery.Name, ChamberOfSecrets.Instance.group.Id));

                if ((Groceries.Groceries.Find(x => x.Name == grocery.Name).Amount) <= 0)
                {
                    await Task.Run(() => ChamberOfSecrets.Proxy.dbDeleteShoppingCart(grocery.Name, ChamberOfSecrets.Instance.group.Id));
                    RemoveFromShoppingCart(grocery);
                }
                else
                    Groceries.Groceries.Find(x => x.Name == grocery.Name).Bought = 0;
            }
            else if(grocery.Bought == 0)
            {
                ChamberOfSecrets.Instance.group.AvailableGroceries.AddToList(grocery, grocery.Amount);
                await Task.Run(() =>
                    ChamberOfSecrets.Proxy.dbAvailableGroceriesInsert(grocery.ToAvaliableAvailableGroceriesDetails()));
                await Task.Run(() => 
                    ChamberOfSecrets.Proxy.dbDeleteShoppingCart(grocery.Name, ChamberOfSecrets.Instance.group.Id));
                RemoveFromShoppingCart(grocery);
            }
        }

        public void RemoveFromShoppingCart(Grocery grocery)
        {
            Groceries.Groceries.Remove(grocery);
        }

        public void ToShoppingCart(List<ShoppingCartDetails> details)
        {
            if(details.Count!=0)
            {
                foreach (var grocery in details)
                {
                    Grocery newGrocery= new Grocery(grocery.Grocery.Name,Grocery.ParseEnum<Unit>(grocery.Grocery.Unit),Grocery.ParseEnum<Category>(grocery.Grocery.Category),grocery.Amount);
                    Groceries.AddToList(newGrocery);
                }
            }
            else
            {
                Groceries=new AvailableGroceries();
            }
        }

    }
}