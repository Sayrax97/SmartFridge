using System;
using System.Collections.Generic;
using System.IO;
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
            this.recipes = (from receipt in recipes
                where receipt.Rank > 0
                select receipt).ToList();
            this.recyclerView = recyclerView;
        }

        public override int ItemCount => recipes.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            void ItemViewClick(object sender, EventArgs e)
            {
                Recipe recipeClicked = recipes[position];
                intent = new Intent(context, typeof(RecipeActivity));
                intent.PutExtra("recept", JsonConvert.SerializeObject(recipeClicked));
                context.StartActivity(intent);
            }
            MyViewHolder vh = holder as MyViewHolder;
            vh.TitleTextView.Text = recipes[position].Name;
            vh.ShortDescTextView.Text = recipes[position].Description;
            vh.ShortDescTextView.Text = recipes[position].Description.Substring
              (0, recipes[position].Description.Length < 80 ? recipes[position].Description.Length : 80) + "...";
            Bitmap bitmap = BitmapFactory.DecodeByteArray(ChamberOfSecrets.Instance.group.Recipes[position].Image,
                0, ChamberOfSecrets.Instance.group.Recipes[position].Image.Length);
            var bitmapScaled = Bitmap.CreateScaledBitmap(bitmap, 200, 200, false);
            vh.RecipeImage.SetImageBitmap(bitmapScaled);
            vh.ItemView.Click += ItemViewClick;
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