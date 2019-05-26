﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SmartFridge.Adapters;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/recipe_list", Theme = "@style/AppThemeNoActionBar")]
    public class RecipeListActivity : AppCompatActivity
    {
        private Toolbar topToolbar;
        private RecyclerView recipeListRecyclerView;
        private RecyclerView.LayoutManager manager;
        private RecyclerView.Adapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.recipe_list_layout);
            Init();
            this.RequestedOrientation = ScreenOrientation.Portrait;
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
        private void Init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbarRecipeList);
            recipeListRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewRecipeList);
            manager = new LinearLayoutManager(this);
            recipeListRecyclerView.SetLayoutManager(manager);
            recipeListRecyclerView.SetAdapter(new RecipesRecyclerAdapter(this,ChamberOfSecrets.Instance.group.Recipes,recipeListRecyclerView));
        }
    }
}