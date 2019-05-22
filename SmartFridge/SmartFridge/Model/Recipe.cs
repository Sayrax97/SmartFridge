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
    public class Recipe
    {
        public string Name { get; set; }
        public int Id { get;set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public AvailableGroceries Groceries { get; set; }

        public Recipe()
        {
            Groceries= new AvailableGroceries();
        }

        public Recipe(string name, int id, string description, string image)
        {
            Groceries = new AvailableGroceries();
            Name = name;
            Id = id;
            Description = description;
            Image = image;
            AddImage();
        }


        public void AddToList(Grocery grocery)
        {
            Groceries.AddToList(grocery);
            //Groceries.Sort();
        }

        public void AddImage()
        {
            var words = Name.Split(' ');
            Image = "";
            foreach (var word in words)
            {
                Image += word.ToLower() + "_";
            }

            //Image += ".jpg";
        }
    }
}