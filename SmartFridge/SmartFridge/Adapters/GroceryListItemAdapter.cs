﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
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
        private bool flagReceipt;
        public override Grocery this[int position] => groceries[position];

        public GroceryListItemAdapter(List<Grocery> groceries, Context context,bool flagReceipt)
        {
            this.groceries = (from grocery in groceries
                where grocery.IsInList == true && grocery.IsCategorized==true
                select grocery).ToList();
            this.context = context;
            this.flagReceipt = flagReceipt;
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
                if(flagReceipt==false)
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.groceies_list_item_layout,null);
                else
                {
                    convertView = LayoutInflater.From(context).Inflate(Resource.Layout.groceries_recipe_item_layout, null);
                }
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.txtNameGrocery);
            TextView amount = convertView.FindViewById<TextView>(Resource.Id.txtAmountGrocery);
            TextView unit = convertView.FindViewById<TextView>(Resource.Id.txtUnitGrocery);
            CheckBox checkBox = convertView.FindViewById<CheckBox>(Resource.Id.checkBoxGrocery);
            name.Text = groceries[position].Name;
            amount.Text = groceries[position].Amount.ToString();
            unit.Text = groceries[position].MeasurementUnit.ToString();
            if (flagReceipt == false)
                checkBox.CheckedChange+= (sender, args) => {
                groceries[position].Checked = !groceries[position].Checked;
                GroceriesActivity.availableGroceries.Groceries[position].Checked = groceries[position].Checked;
            };
            return convertView;
        }
    }
}