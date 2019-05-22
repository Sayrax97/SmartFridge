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

        public override Grocery this[int position] => shoppingCart.Groceries[position];

        public override int Count => shoppingCart.Groceries.Count;

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
            CheckBox checkBox = convertView.FindViewById<CheckBox>(Resource.Id.checkBoxBought);
            amountBought.TextChanged += (sender, args) => 
            {
                if (!string.IsNullOrEmpty(amountBought.Text))
                {
                    shoppingCart.Groceries[position].Bought = int.Parse(amountBought.Text);
                    ChamberOfSecrets.Instance.shoppingCart.Groceries[position].Bought = int.Parse(amountBought.Text);
                }
            };
            
            checkBox.CheckedChange += (sender, args) =>
                {
                    shoppingCart.Groceries[position].Checked = checkBox.Checked;
                    ChamberOfSecrets.Instance.shoppingCart.Groceries[position].Checked =
                        shoppingCart.Groceries[position].Checked;

                };
            name.Text = shoppingCart.Groceries[position].Name;
            unit.Text = shoppingCart.Groceries[position].MeasurementUnit.ToString();
            amount.Text = shoppingCart.Groceries[position].Amount.ToString();

            return convertView;
        }

        void func()
        {
        }
    }
}