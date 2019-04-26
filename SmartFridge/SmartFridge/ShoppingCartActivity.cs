using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/shopping_cart",NoHistory = true, Theme = "@style/AppThemeNoActionBar")]
    public class ShoppingCartActivity : AppCompatActivity
    {
        private ListView shoppingCartListView;
        private Button addToGroceriesListButton;
        private FloatingActionButton shoppingCartFloatingActionButton;
        private Toolbar topToolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.shopping_cart_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.grocery_list);
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
            shoppingCartFloatingActionButton = FindViewById<FloatingActionButton>(Resource.Id.fABshoppingCart);
            addToGroceriesListButton = FindViewById<Button>(Resource.Id.btnAddtoGroceriesList);
            topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbarCart);
            shoppingCartListView = FindViewById<ListView>(Resource.Id.listViewShoppingCart);
        }
    }
}