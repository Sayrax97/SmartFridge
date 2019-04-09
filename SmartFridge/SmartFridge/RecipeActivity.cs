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
using Android.Views;
using Android.Widget;

namespace SmartFridge
{
    [Activity(Label = "@string/receipt")]
    public class RecipeActivity : Activity
    {
        private ImageView recipeImageView;
        private TextView recipeNameTextView;
        private ListView groceriesListView;
        private TextView recipeDescriptionTextView;
        private BottomNavigationView recipeBottomNavigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.recipe_layout);
            init();

        }

        private void init()
        {
            recipeImageView = FindViewById<ImageView>(Resource.Id.imageViewRecipe);
            recipeNameTextView = FindViewById<TextView>(Resource.Id.txtViewRecipeName);
            groceriesListView = FindViewById<ListView>(Resource.Id.listViewGroceriesRecipe);
            recipeDescriptionTextView = FindViewById<TextView>(Resource.Id.txtViewRecipeDescription);
            recipeBottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottomNavigationViewRecipe);
        }
    }
}