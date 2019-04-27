using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SmartFridge.Model;

namespace SmartFridge.Adapters
{
    class RecipesRecyclerAdapter : RecyclerView.Adapter
    {
        private List<Recipe> recipes;

        public RecipesRecyclerAdapter(List<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public override int ItemCount => recipes.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder vh = holder as MyViewHolder;
            vh.TitleTextView.Text = recipes[position].Name;
            vh.ShortDescTextView.Text = recipes[position].Description.Substring(0, 50) + "...";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.recipes_Item_layout, parent, false);
            
            MyViewHolder myView = new MyViewHolder(view);
            return myView;
        }



        public class MyViewHolder:RecyclerView.ViewHolder
        {
            public ImageView RecipeImage { get; set; }
            public TextView TitleTextView { get; set; }
            public TextView ShortDescTextView { get; set; }

            public MyViewHolder(View view) : base(view)
            {
                RecipeImage = view.FindViewById<ImageView>(Resource.Id.imageRecipe);
                TitleTextView = view.FindViewById<TextView>(Resource.Id.txtRecipeTitle);
                ShortDescTextView = view.FindViewById<TextView>(Resource.Id.txtShortDesc);
            }
        }
    }
}