using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartFridge.Model;

namespace SmartFridge
{
    class GroceryListItemAdapter : BaseAdapter<Grocery>
    {
        private List<Grocery> groceries;
        private Context context;
        private bool flagRecipe;
        public override Grocery this[int position] => groceries[position];

        public GroceryListItemAdapter(List<Grocery> groceries, Context context,bool flagReceipt)
        {
            this.groceries = (from grocery in groceries
                where grocery.IsInList == true && grocery.IsCategorized==true && grocery.Amount>0
                select grocery).ToList();
            this.context = context;
            this.flagRecipe = flagReceipt;
        }

        public override int Count => groceries.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(!flagRecipe ? Resource.Layout.shopping_cart_item_layout : Resource.Layout.groceries_recipe_item_layout, null);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.textViewName);
            TextView amount = convertView.FindViewById<TextView>(Resource.Id.textViewAmount);
            TextView unit = convertView.FindViewById<TextView>(Resource.Id.textViewUnit);
            if(!flagRecipe)
            {
                CheckBox checkBox = convertView.FindViewById<CheckBox>(Resource.Id.checkBoxBought);
                EditText boughtEditText = convertView.FindViewById<EditText>(Resource.Id.editTxtBought);
                ImageButton xButton = convertView.FindViewById<ImageButton>(Resource.Id.imageButton1);
                xButton.Visibility = ViewStates.Gone;
                
                boughtEditText.TextChanged += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(boughtEditText.Text))
                    {
                        groceries[position].Bought = double.Parse(boughtEditText.Text);
                        ChamberOfSecrets.Instance.group.AvailableGroceries.Groceries[position].Bought= double.Parse(boughtEditText.Text);
                    }
                };
                
                void OnChange(object sender, CompoundButton.CheckedChangeEventArgs args)
                {
                    groceries[position].Checked = checkBox.Checked;
                    ChamberOfSecrets.Instance.@group.AvailableGroceries.Groceries[position].Checked = groceries[position].Checked;
                }

                checkBox.CheckedChange += OnChange;

            }
            name.Text = groceries[position].Name;
            amount.Text = groceries[position].Amount.ToString();
            unit.Text = groceries[position].MeasurementUnit.ToString();
            name.SetTextColor(Color.Gray);
            name.SetTypeface(null, TypefaceStyle.Normal);
            amount.SetTextColor(Color.Gray);
            amount.SetTypeface(null, TypefaceStyle.Normal);
            unit.SetTextColor(Color.Gray);
            unit.SetTypeface(null, TypefaceStyle.Normal);

            if(flagRecipe && !CheckIfIsAvailable(groceries[position]))
            {
                groceries[position].IsInList = false;
                name.SetTextColor(Color.Red);
                name.SetTypeface(null,TypefaceStyle.Bold);
                amount.SetTextColor(Color.Red);
                amount.SetTypeface(null, TypefaceStyle.Bold);
                unit.SetTextColor(Color.Red);
                unit.SetTypeface(null, TypefaceStyle.Bold);
            }
            return convertView;
        }

        private bool CheckIfIsAvailable(Grocery grocery)
        {
            return ChamberOfSecrets.Instance.@group.AvailableGroceries.Groceries.Exists(x=>x.Name==grocery.Name&&x.Amount>=grocery.Amount);
        }
    }
}