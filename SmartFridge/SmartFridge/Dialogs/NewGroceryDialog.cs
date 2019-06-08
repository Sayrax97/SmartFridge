using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
using SmartFridge.WebReference;
using Syncfusion.Android.ComboBox;
using OccurrenceMode = Com.Syncfusion.Autocomplete.OccurrenceMode;
using SuggestionBoxPlacement = Syncfusion.Android.ComboBox.SuggestionBoxPlacement;
using SuggestionMode = Com.Syncfusion.Autocomplete.SuggestionMode;

namespace SmartFridge.Dialogs
{
    class NewGroceryDialog:DialogFragment
    {
        private SfAutoComplete groceriesAutoComplete;
        private SfComboBox categoriesComboBox;
        private EditText amountEditText;
        private Button okButton;
        private Button cancelButton;
        private View view;
        private TextView unitTextView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.dialog_new_grocery_layout, container, false);
            groceriesAutoComplete = view.FindViewById<SfAutoComplete>(Resource.Id.autoCompleteGrocery);
            categoriesComboBox = view.FindViewById<SfComboBox>(Resource.Id.cmboBoxCategories);
            AutoCompleteInit();
            unitTextView = view.FindViewById<TextView>(Resource.Id.txtUnitNewGroceryDialog);
            amountEditText = view.FindViewById<EditText>(Resource.Id.editTxtAmountGrocery);
            okButton = view.FindViewById<Button>(Resource.Id.btnOK);
            cancelButton = view.FindViewById<Button>(Resource.Id.btnCancel);
            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;
            groceriesAutoComplete.TextChanged += GroceriesAutoComplete_TextChanged;
            return view;
        }

        private void GroceriesAutoComplete_TextChanged(object sender, Com.Syncfusion.Autocomplete.TextChangedEventArgs e)
        {
            if (ChamberOfSecrets.Instance.AllGroceries.Groceries.Exists(x => x.Name == groceriesAutoComplete.Text))
            {
                unitTextView.Text = ChamberOfSecrets.Instance.AllGroceries.Groceries
                    .Find(x => x.Name == groceriesAutoComplete.Text).MeasurementUnit.ToString();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dismiss();
            Toast.MakeText(Activity, "Dodavanje otkazano!!!", ToastLength.Short).Show();
        }

        private async void OkButton_Click(object sender, EventArgs e)
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
                if (category == Category.None)
                {
                    category = ChamberOfSecrets.Instance.AllGroceries.Groceries.Find(x => x.Name == name).Type;
                }
                unit = GetUnit(name, category);
                Grocery gr = new Grocery(name, unit, category, amount);
                gr.Default();
                if (this.Activity.GetType() == typeof(GroceriesActivity))
                {
                    ChamberOfSecrets.Instance.group.AvailableGroceries.AddToList(gr);
                    await Task.Run(() =>
                        ChamberOfSecrets.Proxy.dbAvailableGroceriesInsert(gr.ToAvaliableAvailableGroceriesDetails()));
                }
                else if (this.Activity.GetType() == typeof(ShoppingCartActivity))
                {
                    ChamberOfSecrets.Instance.group.ShoppingCart.AddToList(gr);
                   await Task.Run(()=>
                       ChamberOfSecrets.Proxy.dbInsertShoppingCart(gr.ToCartDetails()));
                }
                Dismiss();
                Toast.MakeText(Activity, "Dodata nova namirnica:" + name+" Kategorija: "+category, ToastLength.Short)
                    .Show();
                if (this.Activity.GetType() == typeof(GroceriesActivity))
                {
                    if (this.Activity is GroceriesActivity x) x.LoadGroceries();
                }
                else if(this.Activity.GetType() == typeof(ShoppingCartActivity))
                {
                    if (this.Activity is ShoppingCartActivity x) x.LoadGroceries();
                }
            }
            else
            {
                Toast.MakeText(Activity, "Morate uneti podatke u prazna polja", ToastLength.Short).Show();
            }
        }
        private void AutoCompleteInit()
        {
            groceriesAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
            groceriesAutoComplete.SuggestionMode = SuggestionMode.Contains;
            groceriesAutoComplete.MaximumDropDownHeight = 200;
            groceriesAutoComplete.Watermark = "Unesi ime namirnice";
            groceriesAutoComplete.PopUpDelay = 200;
            groceriesAutoComplete.DataSource = ChamberOfSecrets.Instance.AllGroceries.Groceries;
            groceriesAutoComplete.DisplayMemberPath = "Name";
            groceriesAutoComplete.MinimumPrefixCharacters = 0;
            groceriesAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
            groceriesAutoComplete.HighlightedTextColor = Color.Red;
            groceriesAutoComplete.NoResultsFoundText = "Nije pronadjen ni jedan rezultat";

            categoriesComboBox.TextColor = Color.Chocolate;
            categoriesComboBox.ComboBoxMode = ComboBoxMode.Suggest;
            categoriesComboBox.DataSource = Grocery.Categories;
            categoriesComboBox.IsEditableMode = false;
            categoriesComboBox.SuggestionBoxPlacement = SuggestionBoxPlacement.Bottom;
            categoriesComboBox.MaximumSuggestion = 5;
            categoriesComboBox.SelectedItem = Grocery.Categories[0];
            categoriesComboBox.TextChanged += CategoriesComboBox_TextChanged;
        }

        private void CategoriesComboBox_TextChanged(object sender, Syncfusion.Android.ComboBox.TextChangedEventArgs e)
        {
            ChamberOfSecrets.Instance.AllGroceries.FilterByType(Grocery.ParseEnum<Category>(categoriesComboBox.Text));
            groceriesAutoComplete.DataSource = from grocery in ChamberOfSecrets.Instance.AllGroceries.Groceries
                where grocery.IsCategorized == true
                select grocery.Name;
        }

        private Unit GetUnit(string name, Category type)
        {
            foreach (var grocery in ChamberOfSecrets.Instance.AllGroceries.Groceries)
            {
                if (grocery.Name == name && grocery.Type == type)
                    return grocery.MeasurementUnit;
            }

            return Unit.Nema;
        }
    }
}