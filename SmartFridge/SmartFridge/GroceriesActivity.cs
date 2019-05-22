using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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
using Syncfusion.Android.ComboBox;
using MultiSelectMode = Syncfusion.Android.ComboBox.MultiSelectMode;
using OccurrenceMode = Syncfusion.Android.ComboBox.OccurrenceMode;
using SearchView = Android.Widget.SearchView;
using SuggestionBoxPlacement = Syncfusion.Android.ComboBox.SuggestionBoxPlacement;
using SuggestionMode = Syncfusion.Android.ComboBox.SuggestionMode;
using TokensWrapMode = Syncfusion.Android.ComboBox.TokensWrapMode;
using TokenSettings = Syncfusion.Android.ComboBox.TokenSettings;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Net.Wifi;

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
        private SfComboBox categoriesComboBox;
        private FloatingActionButton groceriesFAB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gorceries_list_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.grocery_list);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);
            LoadGroceries();
            searchView.QueryTextChange += SearchView_QueryTextChange;
        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var watch=System.Diagnostics.Stopwatch.StartNew();
            ChamberOfSecrets.Instance.availableGroceries.FilterByName(searchView.Query);
            LoadGroceries();
            watch.Stop();
            Toast.MakeText(this,"Vreme:"+watch.ElapsedMilliseconds,ToastLength.Short).Show();
        }

        private void Init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarTopGroceriesList);
            groceryListView = FindViewById<ListView>(Resource.Id.listGroceries);
            categoriesComboBox = FindViewById<SfComboBox>(Resource.Id.cmboBoxCategories);
            searchButton = FindViewById<Button>(Resource.Id.btnSearchRecipe);
            searchButton.Click += SearchButton_Click;
            eatButton = FindViewById<Button>(Resource.Id.btnEat);
            eatButton.Click += EatButton_Click;
            searchView = FindViewById<SearchView>(Resource.Id.searchGroceries);
            groceriesFAB = FindViewById<FloatingActionButton>(Resource.Id.fABgroceries);
            groceriesFAB.Click += GroceriesFAB_Click;
            InitCategories();
            SetDefault();
        }
        private void SetDefault()
        {
            foreach (var grocery in ChamberOfSecrets.Instance.availableGroceries.Groceries)
            {
                grocery.Default();
            }

            categoriesComboBox.Text = Category.None.ToString();
        }

        private void InitCategories()
        {
            categoriesComboBox.TextColor=Color.Aquamarine;
            categoriesComboBox.DataSource = Model.Grocery.Categories;
            categoriesComboBox.IsEditableMode = false;
            categoriesComboBox.SuggestionBoxPlacement = SuggestionBoxPlacement.Bottom;
            categoriesComboBox.SelectedItem =Grocery.Categories[0];
            categoriesComboBox.TextChanged+= CategoriesComboBox_TextChanged;
        }

        private void CategoriesComboBox_TextChanged(object sender, Syncfusion.Android.ComboBox.TextChangedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            ChamberOfSecrets.Instance.availableGroceries.FilterByType(Grocery.ParseEnum<Category>(categoriesComboBox.Text));
            LoadGroceries();
            watch.Stop();
            Toast.MakeText(this, "Vreme:" + watch.ElapsedMilliseconds, ToastLength.Short).Show();
        }

        private void EatButton_Click(object sender, EventArgs e)
        {
                //ToList because:
                //The issue is that availableGroceries.Groceries is being modified inside the foreach loop.
                //Calling availableGroceries.Groceries.ToList() copies the values of groceries
                //to a separate list at the start of the foreach.
                //Nothing else has access to this list (it doesn't even have a variable name!), so nothing can modify it inside the loop.
                foreach (var grocery in ChamberOfSecrets.Instance.availableGroceries.Groceries.ToList())
                {
                    if (grocery.Checked)
                    {
                        ChamberOfSecrets.Instance.availableGroceries.Groceries.Remove(grocery);
                    }
                }
            LoadGroceries();
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

        public void  LoadGroceries()
        {
            groceryListView.Adapter = new GroceryListItemAdapter(ChamberOfSecrets.Instance.availableGroceries.Groceries, this, false);
        }
    }
}