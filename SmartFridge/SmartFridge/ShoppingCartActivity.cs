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
        private ShoppingCart shoppingCart;
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
            shoppingCart= new ShoppingCart();
            shoppingCart.AddToList(new Grocery("Mleko", Category.Litar, "Mlecni", 2));
            shoppingCart.AddToList(new Grocery("Helb", Category.Komad, "", 3));
            shoppingCart.AddToList(new Grocery("Mast", Category.Kilogram, "", 1));
            shoppingCart.AddToList(new Grocery("Pasulj", Category.Kilogram, "", 5));
            shoppingCart.AddToList(new Grocery("Mleko", Category.Litar, "Mlecni", 2));
            shoppingCartListView = FindViewById<ListView>(Resource.Id.listViewShoppingCart);
            ShoppingCartItemAdapter adapter= new ShoppingCartItemAdapter(this,shoppingCart);
            shoppingCartListView.Adapter = adapter;
        }

        private void AddToGroceriesListButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}