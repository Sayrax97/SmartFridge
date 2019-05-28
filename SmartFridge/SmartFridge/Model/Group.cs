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
    public class Group
    {
        public string Id { get; set; }
        public AvailableGroceries AvailableGroceries { get; set; }
        public List<string> MyGroupMembers { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Group()
        {
            AvailableGroceries= new AvailableGroceries();
            Recipes = new List<Recipe>();
            MyGroupMembers = new List<string>();
            ShoppingCart = new ShoppingCart();
        }
        public Group(string x)
        {
            Id = x;
            Recipes = new List<Recipe>();
            MyGroupMembers = new List<string>();
            ShoppingCart = new ShoppingCart();
        }
        public Group(string id, AvailableGroceries availableGroceries, List<string> myGroupMembers, ShoppingCart shoppingCart, List<Recipe> recipes)
        {
            Id = id;
            AvailableGroceries = availableGroceries;
            MyGroupMembers = myGroupMembers;
            ShoppingCart = shoppingCart;
            Recipes = recipes;
        }


        public void AddMember(string user)
        {
            MyGroupMembers.Add(user);
            //user.MyGroup = Id;
        }

        public bool CheckUsername(string example)
        {
            return MyGroupMembers.Exists(x => x == example);
        }

        public async Task<bool> CheckGroupAsync(string id)
        {
            bool x = true;
            bool y = true;
            await Task.Run(()=>ChamberOfSecrets.Proxy.dbGroupExists(id, out x, out y));
            return x;
        }

        public void ToRecipes(List<RecipeDetails> recipesList)
        {
            foreach (var recipe in recipesList)
            {
                Recipe r= new Recipe();
                r.ToRecipe(recipe);
                Recipes.Add(r);
            }
        }

        public GroupDetails ToGroupDetails()
        {
            return new GroupDetails { ID = Id };
        }
    }
}