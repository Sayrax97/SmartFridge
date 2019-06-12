using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.shopping_cart_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.shopping_cart);
            SetSupportActionBar(topToolbar);
            this.RequestedOrientation = ScreenOrientation.Portrait;
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);


            ChamberOfSecrets.Instance.@group.ShoppingCart.Groceries = new AvailableGroceries();
            ChamberOfSecrets.Instance.@group.ShoppingCart.ToShoppingCart(
                ChamberOfSecrets.Proxy.dbGetShoppingCart(ChamberOfSecrets.Instance.LoggedUser.MyGroup).ToList());
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            if(ChamberOfSecrets.Instance.LoggedUser.UserStatus==Status.Supervizor || ChamberOfSecrets.Instance.LoggedUser.UserStatus == Status.Administrator)
                base.MenuInflater.Inflate(Resource.Menu.shopping_cart_menu, menu);
            return true;
        }

        public  override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    Finish();
                    break;
                case Resource.Id.remove:
                    foreach (var grocery in ChamberOfSecrets.Instance.group.ShoppingCart.Groceries.Groceries.ToList())
                    {
                        if (grocery.Checked)
                        {
                            ChamberOfSecrets.Instance.group.ShoppingCart.RemoveFromShoppingCart(grocery);
                            ChamberOfSecrets.Proxy.dbDeleteShoppingCart(grocery.Name, ChamberOfSecrets.Instance.group.Id);
                        }
                        LoadGroceries();
                    }
                    break;
            }

            return true;
        }

        private void Init()
        {
            shoppingCartFloatingActionButton = FindViewById<FloatingActionButton>(Resource.Id.fABshoppingCart);
            addToGroceriesListButton = FindViewById<Button>(Resource.Id.btnAddtoGroceriesList);
            addToGroceriesListButton.Visibility = ViewStates.Invisible;
            if (ChamberOfSecrets.Instance.LoggedUser.UserStatus == Status.Nabavljac ||
                ChamberOfSecrets.Instance.LoggedUser.UserStatus == Status.Supervizor||
                ChamberOfSecrets.Instance.LoggedUser.UserStatus == Status.Administrator
                )
            {
                addToGroceriesListButton.Visibility = ViewStates.Visible;
                addToGroceriesListButton.Click += AddToGroceriesListButton_Click;
            }

            topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbarCart);
            shoppingCartListView = FindViewById<ListView>(Resource.Id.listViewShoppingCart);

            LoadGroceries();
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

        private async void AddToGroceriesListButton_Click(object sender, EventArgs e)
        {
            foreach (var grocery in ChamberOfSecrets.Instance.group.ShoppingCart.Groceries.Groceries.ToList())
            {
                if (grocery.Checked)
                    await ChamberOfSecrets.Instance.group.ShoppingCart.Buy(grocery);

            }
            LoadGroceries();
            foreach (var grocery in ChamberOfSecrets.Instance.group.ShoppingCart.Groceries.Groceries.ToList())
            {
                grocery.Checked = false;

            }
        }

        public void LoadGroceries()
        {
            shoppingCartListView.Adapter = new ShoppingCartItemAdapter(this, ChamberOfSecrets.Instance.group.ShoppingCart);
            
        }
    }
}