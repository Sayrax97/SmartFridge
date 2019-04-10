using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/recipe_list", Theme = "@style/AppThemeNoActionBar")]
    public class RecipeListActivity : AppCompatActivity
    {
        private Toolbar topToolbar;
        private RecyclerView recipeListRecyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.recipe_list_layout);
            init();
            topToolbar.Title = Resources.GetString(Resource.String.recipe_list);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);

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
        private void init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbarRecipeList);
            recipeListRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewRecipeList);
        }
    }
}