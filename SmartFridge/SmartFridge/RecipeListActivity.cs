using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SmartFridge.Adapters;
using SmartFridge.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace SmartFridge
{
    [Activity(Label = "@string/recipe_list", Theme = "@style/AppThemeNoActionBar")]
    public class RecipeListActivity : AppCompatActivity
    {
        private Toolbar topToolbar;
        private RecyclerView recipeListRecyclerView;
        private RecyclerView.LayoutManager manager;
        private RecyclerView.Adapter adapter;
        private List<Recipe> recipes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.recipe_list_layout);
            Init();
            topToolbar.Title = Resources.GetString(Resource.String.recipe_list);
            SetSupportActionBar(topToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_arrow_back_white_18dp);

        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }

            return true;

        }
        private void Init()
        {
            topToolbar = FindViewById<Toolbar>(Resource.Id.topToolbarRecipeList);
            recipeListRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewRecipeList);
            recipes= new List<Recipe>();
            recipes.Add(new Recipe("Pica od suvog hleba",23, "Na podmazanu tepsiju ređati suvi hleb (bez korica). Ubutati jaja, mlijeko, kajmak i sir sjednitini i natopiti preko hleba.Stavljati preko hleba, salamu, pršutu, kulen i sir dobro poređati i poprskati kečapom.",""));
            recipes.Add(new Recipe("Pita sa koprivom", 64, "Koprivu očistiti obariti u slanoj vodi oko 5 minuta. Ocediti i iseckati ukupno da bude 250 g. Umutiti jaja. Dodati jogurt i ulje. Izmešati. Dodati brašna pomešana sa prašom za pecivo u so. Umutiti smesu.", ""));
            recipes.Add(new Recipe("Torta Pahuljica", 94, "Umutiti bjelanca sa šećerom, dodati brašno i prašak za pecivo. Smjesu izliti u kalup, obložen papirom za pečenje, pa peći na 200 C oko 30 minuta. Prokuhati 100 ml mlijeka i vanilin šećer. Pečen biskvit odvojiti od papira, izbockati pa preliti vrelim mlijekom. Ostaviti da se ohladi.", ""));
            recipes.Add(new Recipe("Pica od suvog hleba", 23, "Na podmazanu tepsiju ređati suvi hleb (bez korica). Ubutati jaja, mlijeko, kajmak i sir sjednitini i natopiti preko hleba.Stavljati preko hleba, salamu, pršutu, kulen i sir dobro poređati i poprskati kečapom.", ""));
            recipes.Add(new Recipe("Pita sa koprivom", 64, "Koprivu očistiti obariti u slanoj vodi oko 5 minuta. Ocediti i iseckati ukupno da bude 250 g. Umutiti jaja. Dodati jogurt i ulje. Izmešati. Dodati brašna pomešana sa prašom za pecivo u so. Umutiti smesu.", ""));
            recipes.Add(new Recipe("Torta Pahuljica", 94, "Umutiti bjelanca sa šećerom, dodati brašno i prašak za pecivo. Smjesu izliti u kalup, obložen papirom za pečenje, pa peći na 200 C oko 30 minuta. Prokuhati 100 ml mlijeka i vanilin šećer. Pečen biskvit odvojiti od papira, izbockati pa preliti vrelim mlijekom. Ostaviti da se ohladi.", ""));
            recipes.Add(new Recipe("Pica od suvog hleba", 23, "Na podmazanu tepsiju ređati suvi hleb (bez korica). Ubutati jaja, mlijeko, kajmak i sir sjednitini i natopiti preko hleba.Stavljati preko hleba, salamu, pršutu, kulen i sir dobro poređati i poprskati kečapom.", ""));
            recipes.Add(new Recipe("Pita sa koprivom", 64, "Koprivu očistiti obariti u slanoj vodi oko 5 minuta. Ocediti i iseckati ukupno da bude 250 g. Umutiti jaja. Dodati jogurt i ulje. Izmešati. Dodati brašna pomešana sa prašom za pecivo u so. Umutiti smesu.", ""));
            recipes.Add(new Recipe("Torta Pahuljica", 94, "Umutiti bjelanca sa šećerom, dodati brašno i prašak za pecivo. Smjesu izliti u kalup, obložen papirom za pečenje, pa peći na 200 C oko 30 minuta. Prokuhati 100 ml mlijeka i vanilin šećer. Pečen biskvit odvojiti od papira, izbockati pa preliti vrelim mlijekom. Ostaviti da se ohladi.", ""));

            manager = new LinearLayoutManager(this);
            recipeListRecyclerView.SetLayoutManager(manager);
            recipeListRecyclerView.SetAdapter(new RecipesRecyclerAdapter(recipes));
        }
    }
}