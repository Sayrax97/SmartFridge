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
    public class Recipe
    {
        public string Name { get; set; }
        public int Id { get;set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public List<Grocery> Groceries { get; set; }
        public int Rank { get; set; }

        public Recipe()
        {
            Groceries= new List<Grocery>();
            Rank = 0;
        }

        public Recipe(string name, int id, string description, byte[] image)
        {
            Groceries = new List<Grocery>();
            Name = name;
            Id = id;
            Rank = 0;
            Description = description;
            Image = image;
        }


        public void AddToList(Grocery grocery)
        {
            Groceries.Add(grocery);
        }

        public void ToRecipe(RecipeDetails details)
        {
            Name = details.Name;
            Id = details.ID;
            Description = details.Description;
            Image = details.Image;
            var list = ChamberOfSecrets.Proxy.dbGetContains(Id,true).ToList();
            foreach (var item in list)
            {
                var grocery= new Grocery(item.Grocery.Name,Grocery.ParseEnum<Unit>(item.Grocery.Unit),Grocery.ParseEnum<Category>(item.Grocery.Category),item.Amount);
                Groceries.Add(grocery);
            }
        }
    }
}