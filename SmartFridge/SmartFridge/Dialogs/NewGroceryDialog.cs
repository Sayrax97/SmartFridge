using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Com.Syncfusion.Autocomplete;
using SmartFridge.Model;
using Syncfusion.Android.ComboBox;
using OccurrenceMode = Com.Syncfusion.Autocomplete.OccurrenceMode;
using SuggestionBoxPlacement = Syncfusion.Android.ComboBox.SuggestionBoxPlacement;
using SuggestionMode = Com.Syncfusion.Autocomplete.SuggestionMode;

namespace SmartFridge.Dialogs
{
    class NewGroceryDialog:DialogFragment
    {
        private static AvailableGroceries groceries=new AvailableGroceries();
        private SfAutoComplete groceriesAutoComplete;
        private SfComboBox categoriesComboBox;
        private EditText amountEditText;
        private Button okButton;
        private Button cancelButton;
        private View view;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            InitLists();
            view = inflater.Inflate(Resource.Layout.dialog_new_grocery_layout, container, false);
            groceriesAutoComplete = view.FindViewById<SfAutoComplete>(Resource.Id.autoCompleteGrocery);
            categoriesComboBox = view.FindViewById<SfComboBox>(Resource.Id.cmboBoxCategories);
            AutoCompleteInit(view);
            amountEditText = view.FindViewById<EditText>(Resource.Id.editTxtAmountGrocery);
            okButton = view.FindViewById<Button>(Resource.Id.btnOK);
            cancelButton = view.FindViewById<Button>(Resource.Id.btnCancel);
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            return view;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dismiss();
            Toast.MakeText(Activity, "Dialog fragment dismissed!", ToastLength.Short).Show();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Category category;
            string name;
            double amount;
            Unit unit;
            if (!string.IsNullOrEmpty(groceriesAutoComplete.Text) && !string.IsNullOrEmpty(amountEditText.Text) 
                                                                  && Int32.Parse(amountEditText.Text)!=0)
            {
                category = Grocery.ParseEnum<Category>(categoriesComboBox.Text);
                name = groceriesAutoComplete.Text;
                amount = double.Parse(amountEditText.Text);
                unit = getUnit(name, category);
                if (category == Category.None)
                {
                    category = groceries.Groceries.Find(x => x.Name == name).Type;
                }
                Grocery gr = new Grocery(name, unit, category, amount);
                gr.Default();
                if (this.Activity.GetType() == typeof(GroceriesActivity))
                {
                    GroceriesActivity.availableGroceries.AddToList(gr);
                }
                else if (this.Activity.GetType() == typeof(ShoppingCartActivity))
                {
                    ShoppingCartActivity.shoppingCart.AddToList(gr);
                }

                Dismiss();
                Toast.MakeText(Activity, "Dodata nova namirnica:" + name+" Kategorija: "+category, ToastLength.Short)
                    .Show();
                if (this.Activity.GetType() == typeof(GroceriesActivity))
                {
                    GroceriesActivity x= this.Activity as GroceriesActivity;
                    x.LoadGroceries();
                }
                else if(this.Activity.GetType() == typeof(ShoppingCartActivity))
                {
                    ShoppingCartActivity x = this.Activity as ShoppingCartActivity;
                    x.LoadGroceries();
                }
            }
            else
            {
                Toast.MakeText(Activity, "Morate uneti podatke u prazna polja", ToastLength.Short).Show();
            }
        }
        private void InitLists()
        {
            groceries.Groceries.Clear();
            groceries.AddToList(new Grocery("garlic", Unit.Kilogram, Category.Vegtables, 0));
            groceries.AddToList(new Grocery("powder", Unit.Gram, Category.Condiments, 0));
            groceries.AddToList(new Grocery("bourbon", Unit.Mililitar, Category.Drink, 0));
            groceries.AddToList(new Grocery("spearmint", Unit.Komad, Category.Herbs, 0));
            groceries.AddToList(new Grocery("rose water", Unit.Litar, Category.Drink, 0));
            groceries.AddToList(new Grocery("anchovies", Unit.Gram, Category.Animal_product, 0));
            groceries.AddToList(new Grocery("huckleberries", Unit.Gram, Category.Fruits, 0));
            groceries.AddToList(new Grocery("Havarti cheese", Unit.Gram, Category.Milky, 0));    
            groceries.AddToList(new Grocery("cauliflower", Unit.Gram, Category.Vegtables, 0));
            groceries.AddToList(new Grocery("lima beans", Unit.Gram, Category.Vegtables, 0));
            groceries.AddToList(new Grocery("ice cream", Unit.Gram, Category.Milky, 0));
            groceries.AddToList(new Grocery("oregano", Unit.Gram, Category.Food_additives‎, 0));
            groceries.AddToList(new Grocery("vinegar", Unit.Mililitar, Category.Cooking_oils, 0));
            groceries.AddToList(new Grocery("olive oil", Unit.Mililitar, Category.Cooking_oils, 0));
            groceries.AddToList(new Grocery("cashew nut", Unit.Gram, Category.Vegtables, 0));
            groceries.AddToList(new Grocery("rice", Unit.Gram, Category.Cereals, 0));
        }

        private void AutoCompleteInit(View view)
        {
            groceriesAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
            groceriesAutoComplete.SuggestionMode = SuggestionMode.Contains;
            groceriesAutoComplete.MaximumDropDownHeight = 200;
            groceriesAutoComplete.Watermark = "Unesi ime namirnice";
            groceriesAutoComplete.PopUpDelay = 200;
            groceriesAutoComplete.DataSource = groceries.Groceries;
            groceriesAutoComplete.DisplayMemberPath = "Name";
            groceriesAutoComplete.MinimumPrefixCharacters = 0;
            groceriesAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
            groceriesAutoComplete.HighlightedTextColor = Color.Red;
            groceriesAutoComplete.NoResultsFoundText = "Nije pronadjen ni jedan rezultat";

            categoriesComboBox.TextColor = Color.Chocolate;
            categoriesComboBox.ComboBoxMode = ComboBoxMode.Suggest;
            categoriesComboBox.DataSource = Model.Grocery.Categories;
            categoriesComboBox.IsEditableMode = false;
            categoriesComboBox.SuggestionBoxPlacement = SuggestionBoxPlacement.Bottom;
            categoriesComboBox.MaximumSuggestion = 5;
            categoriesComboBox.SelectedItem = Grocery.Categories[0];
            categoriesComboBox.TextChanged += CategoriesComboBox_TextChanged;
        }

        private void CategoriesComboBox_TextChanged(object sender, Syncfusion.Android.ComboBox.TextChangedEventArgs e)
        {
            groceries.FilterByType(Grocery.ParseEnum<Category>(categoriesComboBox.Text));
            groceriesAutoComplete.DataSource = from grocery in groceries.Groceries
                where grocery.IsCategorized == true
                select grocery.Name;
        }

        private Unit getUnit(string name, Category type)
        {
            foreach (var grocery in groceries.Groceries)
            {
                if (grocery.Name == name && grocery.Type == type)
                    return grocery.MeasurementUnit;
            }

            return Unit.Nema;
        }
    }
}