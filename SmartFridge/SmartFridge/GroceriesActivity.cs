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
        private  static AvailableGroceries pom = availableGroceries;
        private static ObservableCollection<object> selectedCategories=new ObservableCollection<object>();

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
                //if (categoriesComboBox.Text=="" || Grocery.ParseEnum<Category>(categoriesComboBox.Text) == Category.None)
                
                    pom.Groceries.Clear();
                    foreach (var grocery in availableGroceries.Groceries)
                    {
                        if (grocery.Name.ToLower().Contains(searchView.Query.ToLower()))
                        {
                            pom.AddToList(grocery);
                        }
                    }
                
                //else
                //{
                //    pom.Groceries.Clear();
                //    foreach (var grocery in availableGroceries.Groceries)
                //    {
                //        if (grocery.Name.ToLower().Contains(searchView.Query.ToLower()))
                //        {
                //            pom.AddToList(grocery);
                //        }
                //    }
                //}
                GroceryListItemAdapter adapterGroceryListItem =
                    new GroceryListItemAdapter(pom.Groceries, this, false);
                groceryListView.Adapter = adapterGroceryListItem;

            }
            else
            {
                //if (categoriesComboBox.Text == "" || Grocery.ParseEnum<Category>(categoriesComboBox.Text) == Category.None)
                //{
                //    foreach (var grocery in availableGroceries.Groceries)
                //    {
                //            pom.AddToList(grocery);
                //    }
                //}
                foreach (var grocery in availableGroceries.Groceries)
                {
                        pom.AddToList(grocery);
                }
                GroceryListItemAdapter adapterGroceryListItem =
                    new GroceryListItemAdapter(pom.Groceries, this, false);
                groceryListView.Adapter = adapterGroceryListItem;
            }
        }

        private void Init()
        {
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
        }

        private void InitCategories()
        {
            categoriesComboBox.TextColor=Color.Aquamarine;
            categoriesComboBox.DataSource = Model.Grocery.Categories;
            categoriesComboBox.ComboBoxMode = ComboBoxMode.Suggest;
            categoriesComboBox.SuggestionMode = SuggestionMode.StartsWith;
            categoriesComboBox.IsEditableMode = false;
            categoriesComboBox.SuggestionBoxPlacement = SuggestionBoxPlacement.Bottom;
            //categoriesComboBox.MultiSelectMode = MultiSelectMode.Token;
            //categoriesComboBox.Delimiter = ',';
            //categoriesComboBox.TokensWrapMode = TokensWrapMode.Wrap;
            //categoriesComboBox.IsSelectedItemsVisibleInDropDown = false;
            categoriesComboBox.TextHighlightMode = OccurrenceMode.FirstOccurrence;
            categoriesComboBox.HighlightedTextColor = Color.Red;
            categoriesComboBox.HighlightedTextFontTypeFace = TypefaceStyle.Bold;
            categoriesComboBox.SelectedItem =Grocery.Categories[0];
            //categoriesComboBox.Text = Category.None.ToString();
            //TokenSettings token = new TokenSettings();
            //token.BackgroundColor=Color.Azure;
            //token.CornerRadius = 15;
            //token.TextColor=Color.Black;
            //token.TextSize = 16;
            //categoriesComboBox.TokenSettings = token;
            categoriesComboBox.TextChanged+= CategoriesComboBox_TextChanged;
        }

        private void CategoriesComboBox_TextChanged(object sender, Syncfusion.Android.ComboBox.TextChangedEventArgs e)
        {
            //List<Grocery> x=new List<Grocery>();
            //foreach (var grocery in pom.Groceries)
            //{
            //    if (grocery.Type == Grocery.ParseEnum<Category>(e.Value))
            //    {
            //        x.Add(grocery);
            //    }
            //}

            //pom.Groceries= x;
            //groceryListView.Adapter = new GroceryListItemAdapter(pom.Groceries, this, false);
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
            }
            groceryListView.Adapter = new GroceryListItemAdapter(pom.Groceries, this, false);
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