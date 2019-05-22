using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SmartFridge.Model;

namespace SmartFridge.Adapters
{
    class RecipesRecyclerAdapter : RecyclerView.Adapter
    {
        private Context context;
        private List<Recipe> recipes;
        private RecyclerView recyclerView;
        private Intent intent;

        public RecipesRecyclerAdapter(Context context, List<Recipe> recipes, RecyclerView recyclerView)
        {
            this.context = context;
            this.recipes = recipes;
            this.recyclerView = recyclerView;
        }

        public override int ItemCount => recipes.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder vh = holder as MyViewHolder;
            vh.TitleTextView.Text = recipes[position].Name;
            vh.ShortDescTextView.Text = recipes[position].Description.Substring(0, 50) + "...";
            //var bitmap = BitmapDrawable.cre(context.GetExternalFilesDir("jpg").AbsolutePath+"/"+recipes[position].Image+".jpg");
            vh.RecipeImage.SetImageDrawable(context.GetDrawable
                (context.Resources.GetIdentifier(recipes[position].Image,"drawable",context.PackageName)));
            vh.ItemView.Click += ItemView_Click;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            int position = this.recyclerView.GetChildAdapterPosition((View) sender);
            Recipe recipeClicked = recipes[position];
            intent= new Intent(context,typeof(RecipeActivity));
            intent.PutExtra("recept", JsonConvert.SerializeObject(recipeClicked));
            context.StartActivity(intent);
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