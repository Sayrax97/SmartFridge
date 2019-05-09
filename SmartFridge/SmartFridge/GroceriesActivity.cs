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
using Android.Support.V7.Widget;
using Android.Views;
using Com.Syncfusion.Autocomplete;
using Android.Widget;
using SmartFridge.Dialogs;
using SmartFridge.Model;
using SearchView = Android.Widget.SearchView;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/grocery_list", Theme = "@style/AppThemeNoActionBar")]
    public class GroceriesActivity : AppCompatActivity
    {
        private Toolbar topToolbar;
        private ListView groceryListView;
        private Button searchButton;
        private Button eatButton;
        private SearchView searchView;
        private FloatingActionButton groceriesFAB;
        public static AvailableGroceries availableGroceries= new AvailableGroceries();
        private  static AvailableGroceries pom = new AvailableGroceries();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gorceries_list_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.grocery_list);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            GroceryListItemAdapter adapterGroceryListItem = new GroceryListItemAdapter(availableGroceries.Groceries, this,false);
            groceryListView.Adapter = adapterGroceryListItem;
            searchView.QueryTextChange += SearchView_QueryTextChange;
        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchView.Query))
            {
                pom.Groceries.Clear();
                foreach (var grocery in availableGroceries.Groceries)
                {
                    if (grocery.Name.ToLower().Contains(searchView.Query.ToLower()))
                    {
                        pom.AddToList(grocery);
                    }
                }

                GroceryListItemAdapter adapterGroceryListItem = new GroceryListItemAdapter(pom.Groceries, this,false);
                groceryListView.Adapter = adapterGroceryListItem;
            }
            else
            {
                GroceryListItemAdapter adapterGroceryListItem = new GroceryListItemAdapter(availableGroceries.Groceries, this, false);
                groceryListView.Adapter = adapterGroceryListItem;
            }
        }

        private void Init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarTopGroceriesList);
            groceryListView = FindViewById<ListView>(Resource.Id.listGroceries);
            searchButton = FindViewById<Button>(Resource.Id.btnSearchRecipe);
            searchButton.Click += SearchButton_Click;
            eatButton = FindViewById<Button>(Resource.Id.btnEat);
            eatButton.Click += EatButton_Click;
            searchView = FindViewById<SearchView>(Resource.Id.searchView1);
            groceriesFAB = FindViewById<FloatingActionButton>(Resource.Id.fABgroceries);
            groceriesFAB.Click += GroceriesFAB_Click;
        }

        private void EatButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchView.Query))
            {
                foreach (var grocery in pom.Groceries.ToList())
                {
                    if (grocery.Checked)
                    {
                        pom.Groceries.Remove(grocery);
                        availableGroceries.Groceries.Remove(grocery);
                    }
                }
                GroceryListItemAdapter adapterGroceryListItem = new GroceryListItemAdapter(pom.Groceries, this, false);
                groceryListView.Adapter = adapterGroceryListItem;
            }
            else
            {
                //ToList because:
                //The issue is that availableGroceries.Groceries is being modified inside the foreach loop.
                //Calling availableGroceries.Groceries.ToList() copies the values of groceries
                //to a separate list at the start of the foreach.
                //Nothing else has access to this list (it doesn't even have a variable name!), so nothing can modify it inside the loop.
                foreach (var grocery in availableGroceries.Groceries.ToList())
                {
                    if (grocery.Checked)
                    {
                        availableGroceries.Groceries.Remove(grocery);
                    }

                }
                GroceryListItemAdapter adapterGroceryListItem = new GroceryListItemAdapter(availableGroceries.Groceries, this, false);
                groceryListView.Adapter = adapterGroceryListItem;
            }
        }

        private void GroceriesFAB_Click(object sender, EventArgs e)
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
           
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
            if (_event.Action == MotionEventActions.Scroll)
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