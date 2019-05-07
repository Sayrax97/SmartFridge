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
using Android.Widget;
using Com.Syncfusion.Autocomplete;
using SmartFridge.Model;

namespace SmartFridge.Dialogs
{
    class NewGroceryDialog:DialogFragment
    {
        private List<Grocery> groceries;
        private List<string> groceryNamesList;
        private List<string> groceryCategoriesList;
        private SfAutoComplete groceiesAutoComplete;
        private SfAutoComplete categoryAutoComplete;
        private EditText amontEditText;
        private Button okButton;
        private Button cancelButton;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            InitLists();
            View view = inflater.Inflate(Resource.Layout.dialog_new_grocery_layout, container, false);
            groceiesAutoComplete = view.FindViewById<SfAutoComplete>(Resource.Id.autoCompleteGrocery);
            categoryAutoComplete = view.FindViewById<SfAutoComplete>(Resource.Id.autoCompletecategory);
            AutoCompleteInit(view);
            amontEditText = view.FindViewById<EditText>(Resource.Id.editTxtAmountGrocery);
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
            GroceriesActivity.availableGroceries.AddToList(
                new Grocery(groceiesAutoComplete.Text,Unit.Komad,Grocery.ParseEnum<Category>(categoryAutoComplete.Text),Int32.Parse(amontEditText.Text)));
            Dismiss();
            Toast.MakeText(Activity, "Dodata nova namirnica:"+groceiesAutoComplete.Text, ToastLength.Short).Show();
        }

        private void InitLists()
        {
            groceries = new List<Grocery>()
            {
                new Grocery("garlic",Unit.Kilogram,Category.Vegtables,0),
                new Grocery("powder",Unit.Gram,Category.Condiments,0),
                new Grocery("bourbon",Unit.Mililitar,Category.Drink,0),
                new Grocery("spearmint",Unit.Komad,Category.Herbs,0),
                new Grocery("rose water",Unit.Litar,Category.Drink,0),
                new Grocery("anchovies",Unit.Gram,Category.Animal_product,0),
                new Grocery("huckleberries",Unit.Gram,Category.Fruits,0),
                new Grocery("Havarti cheese",Unit.Gram,Category.Milky,0),
                new Grocery("cauliflower",Unit.Gram,Category.Vegtables,0),
                new Grocery("lima beans",Unit.Gram,Category.Vegtables,0),
                new Grocery("ice cream",Unit.Gram,Category.Milky,0),
                new Grocery("oregano",Unit.Gram,Category.Food_additives‎,0),
                new Grocery("rice vinegar",Unit.Mililitar,Category.Cooking_oils,0),
                new Grocery("olive oil",Unit.Mililitar,Category.Cooking_oils,0),
                new Grocery("cashew nut",Unit.Gram,Category.Vegtables,0),
                new Grocery("rice",Unit.Gram,Category.Cereals,0)
            };
            groceryNamesList = new List<string>();
            groceryCategoriesList = Enum.GetNames(typeof(Category)).ToList();
            foreach (var grocery in groceries)
            {
                groceryNamesList.Add(grocery.Name);
            }
        }

        private void AutoCompleteInit(View view)
        {
            groceiesAutoComplete.AutoCompleteSource = new ArrayAdapter<string>(view.Context, Android.Resource.Layout.SimpleListItem1, groceryNamesList);
            groceiesAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
            groceiesAutoComplete.SuggestionMode = SuggestionMode.Contains;
            groceiesAutoComplete.MaximumDropDownHeight = 200;
            groceiesAutoComplete.Watermark = "Unesi ime namirnice";
            groceiesAutoComplete.PopUpDelay = 200;
            groceiesAutoComplete.DataSource = groceryNamesList;
            groceiesAutoComplete.MinimumPrefixCharacters = 0;
            groceiesAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
            groceiesAutoComplete.HighlightedTextColor = Color.Red;
            groceiesAutoComplete.NoResultsFoundText = "Nije pronadjen ni jedan rezultat";

            categoryAutoComplete.AutoCompleteSource = new ArrayAdapter<string>(view.Context, Android.Resource.Layout.SimpleListItem1, groceryCategoriesList);
            categoryAutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryAutoComplete.SuggestionMode = SuggestionMode.Contains;
            categoryAutoComplete.MaximumDropDownHeight = 200;
            categoryAutoComplete.Watermark = "Izaberi kategoriju namirnice";
            categoryAutoComplete.PopUpDelay = 200;
            categoryAutoComplete.DataSource = groceryCategoriesList;
            categoryAutoComplete.MinimumPrefixCharacters = 0;
            categoryAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
            categoryAutoComplete.HighlightedTextColor = Color.Red;
            categoryAutoComplete.NoResultsFoundText = "Nije pronadjen ni jedan rezultat";
        }
    }
}