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
            AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            AddToList(new Grocery("Hleb", Unit.Komad, Category.Flour, 3));
            AddToList(new Grocery("Mast", Unit.Kilogram, Category.Cooking_oils, 1));
            AddToList(new Grocery("Pasulj", Unit.Kilogram, Category.Vegtables, 5));
            AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            AddToList(new Grocery("garlic", Unit.Kilogram, Category.Vegtables, 6));
            AddToList(new Grocery("powder", Unit.Gram, Category.Condiments, 2));
            AddToList(new Grocery("bourbon", Unit.Mililitar, Category.Drink, 6));
            AddToList(new Grocery("huckleberries", Unit.Gram, Category.Fruits, 6));
            AddToList(new Grocery("Havarti cheese", Unit.Gram, Category.Milky, 3));
            AddToList(new Grocery("cauliflower", Unit.Gram, Category.Vegtables, 7));
            AddToList(new Grocery("lima beans", Unit.Gram, Category.Vegtables, 33));
            AddToList(new Grocery("ice cream", Unit.Gram, Category.Milky, 23));
            AddToList(new Grocery("oregano", Unit.Gram, Category.Food_additives‎, 22));
        }

        public AvailableGroceries(List<Grocery> groceries )
        {
            Groceries = groceries;
        }

        public void AddToList(Grocery grocery)
        {
            if (Groceries.Exists(x => x.Name.Contains(grocery.Name)))
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
            if (Groceries.Exists(x => x.Name.Contains(grocery.Name)))
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

    }
}