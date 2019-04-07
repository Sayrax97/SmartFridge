using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace SmartFridge
{
    [Activity(Label = "@string/shopping_cart")]
    public class ShoppingCartActivity : Activity
    {
        private ListView shoppingCartListView;
        private Button addToGroceriesListButton;
        private FloatingActionButton shoppingCartFloatingActionButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.shopping_cart_layout);
            shoppingCartFloatingActionButton = FindViewById<FloatingActionButton>(Resource.Id.fABshoppingCart);
            addToGroceriesListButton = FindViewById<Button>(Resource.Id.btnAddtoGroceriesList);
            shoppingCartListView = FindViewById<ListView>(Resource.Id.listViewShoppingCart);

        }
    }
}