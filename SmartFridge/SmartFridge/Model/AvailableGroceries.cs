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
                Groceries.Add(grocery);
                //Groceries.Sort();

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
                grocery.Amount = amount;
                Groceries.Add(grocery);
                //Groceries.Sort();

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