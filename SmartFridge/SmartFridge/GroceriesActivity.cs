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
        public static AvailableGroceries availableGroceries= new AvailableGroceries();
        private static AvailableGroceries pom = availableGroceries;

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
            availableGroceries.FilterByName(searchView.Query);
            LoadGroceries();
            watch.Stop();
            Toast.MakeText(this,"Vreme:"+watch.ElapsedMilliseconds,ToastLength.Short).Show();
        }

        private void Init()
        {
            FillUpAvailableGroceries();
            topToolbar = FindViewById<Toolbar>(Resource.Id.toolbarTopGroceriesList);
            groceryListView = FindViewById<ListView>(Resource.Id.listGroceries);
            categoriesComboBox = FindViewById<SfComboBox>(Resource.Id.cmboBoxCategories);
            InitCategories();
            searchButton = FindViewById<Button>(Resource.Id.btnSearchRecipe);
            searchButton.Click += SearchButton_Click;
            eatButton = FindViewById<Button>(Resource.Id.btnEat);
            eatButton.Click += EatButton_Click;
            searchView = FindViewById<SearchView>(Resource.Id.searchGroceries);
            groceriesFAB = FindViewById<FloatingActionButton>(Resource.Id.fABgroceries);
            groceriesFAB.Click += GroceriesFAB_Click;
            SetDefault();
        }

        private void FillUpAvailableGroceries()
        {
            //availableGroceries.Groceries.Clear();
            availableGroceries.AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            availableGroceries.AddToList(new Grocery("Hleb", Unit.Komad, Category.Flour, 3));
            availableGroceries.AddToList(new Grocery("Mast", Unit.Kilogram, Category.Cooking_oils, 1));
            availableGroceries.AddToList(new Grocery("Pasulj", Unit.Kilogram, Category.Vegtables, 5));
            availableGroceries.AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            availableGroceries.AddToList(new Grocery("garlic", Unit.Kilogram, Category.Vegtables, 6));
            availableGroceries.AddToList(new Grocery("powder", Unit.Gram, Category.Condiments, 2));
            availableGroceries.AddToList(new Grocery("bourbon", Unit.Mililitar, Category.Drink, 6));
            availableGroceries.AddToList(new Grocery("huckleberries", Unit.Gram, Category.Fruits, 6));
            availableGroceries.AddToList(new Grocery("Havarti cheese", Unit.Gram, Category.Milky, 3));
            availableGroceries.AddToList(new Grocery("cauliflower", Unit.Gram, Category.Vegtables, 7));
            availableGroceries.AddToList(new Grocery("lima beans", Unit.Gram, Category.Vegtables, 33));
            availableGroceries.AddToList(new Grocery("ice cream", Unit.Gram, Category.Milky, 23));
            availableGroceries.AddToList(new Grocery("oregano", Unit.Gram, Category.Food_additives‎, 22));
        }

        private void SetDefault()
        {
            foreach (var grocery in availableGroceries.Groceries)
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
            availableGroceries.FilterByType(Grocery.ParseEnum<Category>(categoriesComboBox.Text));
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
                foreach (var grocery in availableGroceries.Groceries.ToList())
                {
                    if (grocery.Checked)
                    {
                        availableGroceries.Groceries.Remove(grocery);
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

        public void  LoadGroceries()
        {
            groceryListView.Adapter = new GroceryListItemAdapter(availableGroceries.Groceries, this, false);
        }
    }
}