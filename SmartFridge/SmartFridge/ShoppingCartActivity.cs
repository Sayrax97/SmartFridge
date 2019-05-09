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
using SmartFridge.Adapters;
using SmartFridge.Dialogs;
using SmartFridge.Model;
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
        public static ShoppingCart shoppingCart = new ShoppingCart();
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.shopping_cart_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.shopping_cart);
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
            addToGroceriesListButton.Click += AddToGroceriesListButton_Click;
            topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbarCart);
            shoppingCartListView = FindViewById<ListView>(Resource.Id.listViewShoppingCart);
            ShoppingCartItemAdapter adapter= new ShoppingCartItemAdapter(this,shoppingCart);
            shoppingCartListView.Adapter = adapter;
            shoppingCartFloatingActionButton.Click += ShoppingCartFloatingActionButton_Click;

        }

        private void ShoppingCartFloatingActionButton_Click(object sender, EventArgs e)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            //Remove fragment else it will crash as it is already added to backstack
            Fragment prev = FragmentManager.FindFragmentByTag("NovaNamirnica");
            if (prev != null)
            {
                ft.Remove(prev);
            }
            ft.AddToBackStack(null);

            // Create and show the dialog.
            NewGroceryDialog newFragment = new NewGroceryDialog();
            //Add fragment
            newFragment.Show(ft, "NovaNamirnica");
        }

        private void AddToGroceriesListButton_Click(object sender, EventArgs e)
        {
            foreach (var grocery in shoppingCart.Groceries.ToList())
            {
                if (grocery.Checked)
                {
                    shoppingCart.Buy(grocery);
                    grocery.Bought = 0;
                }

            }
            ShoppingCartItemAdapter adapter = new ShoppingCartItemAdapter(this, shoppingCart);
            shoppingCartListView.Adapter = adapter;
            foreach (var grocery in shoppingCart.Groceries.ToList())
            {
                grocery.Checked = false;

            }
        }
    }
}