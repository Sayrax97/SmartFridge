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
    [Activity(Label = "@string/grocery_list", Theme = "@style/AppThemeNoActionBar")]
    public class GroceriesActivity : AppCompatActivity
    {
        private Toolbar topToolbar;
        private RecyclerView groceryListRecyclerView;
        private Button searchButton;
        private Button eatButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gorceries_list_layout);
            init();
            topToolbar.Title = Resources.GetString(Resource.String.grocery_list);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            
        }

        private void init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarTopGroceriesList);
            groceryListRecyclerView = FindViewById<RecyclerView>(Resource.Id.groceryList);
            searchButton = FindViewById<Button>(Resource.Id.btnSearchRecipe);
            eatButton = FindViewById<Button>(Resource.Id.btnEat);
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
        public override bool OnTouchEvent(MotionEvent _event)
        {
            if (_event.Action == MotionEventActions.Down)
                if (SupportActionBar != null)
                {
                    if (SupportActionBar.IsShowing)
                    {
                        SupportActionBar.Hide();
                    }
                    else
                    {
                        SupportActionBar.Show();
                    }
                }
            return true;
        }
    }
}