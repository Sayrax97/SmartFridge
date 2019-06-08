using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartFridge.Model;

namespace SmartFridge.Adapters
{
    class ShoppingCartItemAdapter : BaseAdapter<Grocery>
    {
        private Context context;
        private  ShoppingCart shoppingCart;

        public ShoppingCartItemAdapter(Context context, ShoppingCart shoppingCart)
        {
            this.context = context;
            this.shoppingCart = shoppingCart;
        }

        public override Grocery this[int position] => shoppingCart.Groceries.Groceries[position];

        public override int Count => shoppingCart.Groceries.Groceries.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.shopping_cart_item_layout, null);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.textViewName);
            TextView amount = convertView.FindViewById<TextView>(Resource.Id.textViewAmount);
            TextView unit = convertView.FindViewById<TextView>(Resource.Id.textViewUnit);
            EditText amountBought = convertView.FindViewById<EditText>(Resource.Id.editTxtBought);
            amountBought.TextChanged += (sender, args) => 
            {
                if (!string.IsNullOrEmpty(amountBought.Text))
                {
                    shoppingCart.Groceries.Groceries[position].Bought = double.Parse(amountBought.Text);
                    ChamberOfSecrets.Instance.group.ShoppingCart.Groceries.Groceries[position].Bought = double.Parse(amountBought.Text);
                }
            };
            CheckBox checkBox = convertView.FindViewById<CheckBox>(Resource.Id.checkBoxBought);

            void OnCheckBoxOnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs args)
            {
                shoppingCart.Groceries.Groceries[position].Checked = checkBox.Checked;
                ChamberOfSecrets.Instance.@group.ShoppingCart.Groceries.Groceries[position].Checked = shoppingCart.Groceries.Groceries[position].Checked;
            }
            checkBox.CheckedChange += OnCheckBoxOnCheckedChange;
            ImageButton xButton = convertView.FindViewById<ImageButton>(Resource.Id.imageButton1);
            xButton.Visibility = ViewStates.Gone;
            //xButton.Click += XButton_Click;
            //void XButton_Click(object sender, EventArgs e)
            //{
            //    ChamberOfSecrets.Instance.group.ShoppingCart.RemoveFromShoppingCart(shoppingCart.Groceries[position]);
            //    NotifyDataSetChanged();
            //}
            name.Text = shoppingCart.Groceries.Groceries[position].Name;
            unit.Text = shoppingCart.Groceries.Groceries[position].MeasurementUnit.ToString();
            amount.Text = shoppingCart.Groceries.Groceries[position].Amount.ToString();

            return convertView;
        }
    }
}