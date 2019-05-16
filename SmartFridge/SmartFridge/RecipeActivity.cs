using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/receipt",Theme = "@style/AppThemeNoActionBar")]
    public class RecipeActivity : AppCompatActivity
    {
        private ImageView recipeImageView;
        private TextView recipeNameTextView;
        private ListView groceriesListView;
        private TextView recipeDescriptionTextView;
        private Toolbar topToolbar;
        private BottomNavigationView recipeBottomNavigationView;
        private Recipe recipe;
        private AvailableGroceries groceryList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.recipe_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.receipt);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            groceriesListView.Adapter = new GroceryListItemAdapter(groceryList.Groceries, this, true);
            PutOnScreen();

        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }

            return true;

        }
        private void Init()
        {
            recipeImageView = FindViewById<ImageView>(Resource.Id.imageViewRecipe);
            recipeNameTextView = FindViewById<TextView>(Resource.Id.txtViewRecipeName);
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarRecipe);
            groceriesListView = FindViewById<ListView>(Resource.Id.listViewGroceriesRecipe);
            recipeDescriptionTextView = FindViewById<TextView>(Resource.Id.txtViewRecipeDescription);
            recipeBottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigationViewRecipe);
            recipe = JsonConvert.DeserializeObject<Recipe>(Intent.GetStringExtra("recept"));
            groceryList = recipe.Groceries;
            groceryList.SetDefault();
            foreach (var grocery in recipe.Groceries.Groceries)
            {
                if (CheckIfIsAvailable(grocery))
                {
                    recipeBottomNavigationView.Menu.GetItem(1).SetEnabled(false);
                    recipeBottomNavigationView.Menu.GetItem(2).SetEnabled(true);
                    break;
                }
                recipeBottomNavigationView.Menu.GetItem(1).SetEnabled(true);
                recipeBottomNavigationView.Menu.GetItem(2).SetEnabled(false);
            }
        }
        private void PutOnScreen()
        {
            recipeNameTextView.Text = recipe.Name;
            recipeDescriptionTextView.Text = recipe.Description;
        }

        private bool CheckIfIsAvailable(Grocery grocery)
        {
            if (GroceriesActivity.availableGroceries.Groceries.Exists(x => x.Name == grocery.Name))
                return false;
            return true;
        }
    }
}