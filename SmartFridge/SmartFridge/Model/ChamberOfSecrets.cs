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

namespace SmartFridge.Model
{
    public class ChamberOfSecrets
    {
        private static ChamberOfSecrets instance = null;

        private static object locker = true;

        public static ChamberOfSecrets Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new ChamberOfSecrets();
                }
                return instance;
            }
        }

        public Group group { get; set; }
        public AvailableGroceries allGroceries { get; set; }
        public AvailableGroceries availableGroceries { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public List<Recipe> recipes { get; set; }
        public Option option { get; set; }

        protected ChamberOfSecrets()
        {
            option=new Option("Dark","timenewroman");
            
            allGroceries=new AvailableGroceries();
            allGroceries.AddToList(new Grocery("garlic", Unit.Kilogram, Category.Vegtables, 0));
            allGroceries.AddToList(new Grocery("powder", Unit.Gram, Category.Condiments, 0));
            allGroceries.AddToList(new Grocery("bourbon", Unit.Mililitar, Category.Drink, 0));
            allGroceries.AddToList(new Grocery("spearmint", Unit.Komad, Category.Herbs, 0));
            allGroceries.AddToList(new Grocery("rose water", Unit.Litar, Category.Drink, 0));
            allGroceries.AddToList(new Grocery("anchovies", Unit.Gram, Category.Animal_product, 0));
            allGroceries.AddToList(new Grocery("huckleberries", Unit.Gram, Category.Fruits, 0));
            allGroceries.AddToList(new Grocery("Havarti cheese", Unit.Gram, Category.Milky, 0));
            allGroceries.AddToList(new Grocery("cauliflower", Unit.Gram, Category.Vegtables, 0));
            allGroceries.AddToList(new Grocery("lima beans", Unit.Gram, Category.Vegtables, 0));
            allGroceries.AddToList(new Grocery("ice cream", Unit.Gram, Category.Milky, 0));
            allGroceries.AddToList(new Grocery("oregano", Unit.Gram, Category.Food_additives‎, 0));
            allGroceries.AddToList(new Grocery("vinegar", Unit.Mililitar, Category.Cooking_oils, 0));
            allGroceries.AddToList(new Grocery("olive oil", Unit.Mililitar, Category.Cooking_oils, 0));
            allGroceries.AddToList(new Grocery("cashew nut", Unit.Gram, Category.Vegtables, 0));
            allGroceries.AddToList(new Grocery("rice", Unit.Gram, Category.Cereals, 0));

            availableGroceries= new AvailableGroceries();
            availableGroceries.AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            availableGroceries.AddToList(new Grocery("Hleb", Unit.Komad, Category.Flour, 3));
            availableGroceries.AddToList(new Grocery("Mast", Unit.Kilogram, Category.Cooking_oils, 1));
            availableGroceries.AddToList(new Grocery("Pasulj", Unit.Kilogram, Category.Vegtables, 5));
            availableGroceries.AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            availableGroceries.AddToList(new Grocery("garlic", Unit.Kilogram, Category.Vegtables, 6));
            availableGroceries.AddToList(new Grocery("powder", Unit.Gram, Category.Condiments, 2));
            availableGroceries.AddToList(new Grocery("bourbon", Unit.Mililitar, Category.Drink, 6));
            availableGroceries.AddToList(new Grocery("huckleberries", Unit.Gram, Category.Fruits, 6));
            availableGroceries.AddToList(new Grocery("Havarti cheese", Unit.Gram, Category.Milky, 3));
            availableGroceries.AddToList(new Grocery("cauliflower", Unit.Gram, Category.Vegtables, 7));
            availableGroceries.AddToList(new Grocery("lima beans", Unit.Gram, Category.Vegtables, 33));
            availableGroceries.AddToList(new Grocery("ice cream", Unit.Gram, Category.Milky, 23));
            availableGroceries.AddToList(new Grocery("oregano", Unit.Gram, Category.Food_additives‎, 22));

            shoppingCart= new ShoppingCart();
            shoppingCart.AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));
            shoppingCart.AddToList(new Grocery("Hleb", Unit.Komad, Category.Flour, 3));
            shoppingCart.AddToList(new Grocery("Mast", Unit.Kilogram, Category.Cooking_oils, 1));
            shoppingCart.AddToList(new Grocery("Pasulj", Unit.Kilogram, Category.Vegtables, 5));
            shoppingCart.AddToList(new Grocery("Mleko", Unit.Litar, Category.Milky, 2));

            recipes = new List<Recipe>();
            recipes.Add(new Recipe("Pica od suvog hleba", 23, "Na podmazanu tepsiju ređati suvi hleb (bez korica).\nUbutati jaja, mlijeko, kajmak i sir sjednitini i natopiti preko hleba.\nStavljati preko hleba, salamu, pršutu, kulen i sir dobro poređati i poprskati kečapom.\nZapeći u pekaru zagrijanu na 200C oko 15 minuta.\nPečenu picu poprskati majonezom malo ohladini i iseći po želji.", ""));
            recipes[0].AddToList(new Grocery("Jaje", Unit.Komad, Category.Animal_product, 2));
            recipes[0].AddToList(new Grocery("Hleb", Unit.Komad, Category.Flour, 2));
            recipes[0].AddToList(new Grocery("Brasno", Unit.Kilogram, Category.Flour, 0.5));
            recipes.Add(new Recipe("Pita sa koprivom", 64, "Koprivu očistiti obariti u slanoj vodi oko 5 minuta. Ocediti i iseckati ukupno da bude 250 g. Umutiti jaja. Dodati jogurt i ulje. Izmešati. Dodati brašna pomešana sa prašom za pecivo u so. Umutiti smesu.", ""));
            recipes[1].AddToList(new Grocery("Hleb", Unit.Komad, Category.Flour, 2));
            recipes.Add(new Recipe("Torta Pahuljica", 94, "Umutiti bjelanca sa šećerom, dodati brašno i prašak za pecivo. Smjesu izliti u kalup, obložen papirom za pečenje, pa peći na 200 C oko 30 minuta. Prokuhati 100 ml mlijeka i vanilin šećer. Pečen biskvit odvojiti od papira, izbockati pa preliti vrelim mlijekom. Ostaviti da se ohladi.", ""));
            recipes.Add(new Recipe("Pica od suvog hleba", 23, "Na podmazanu tepsiju ređati suvi hleb (bez korica). Ubutati jaja, mlijeko, kajmak i sir sjednitini i natopiti preko hleba.Stavljati preko hleba, salamu, pršutu, kulen i sir dobro poređati i poprskati kečapom.", ""));
            recipes.Add(new Recipe("Pita sa koprivom", 64, "Koprivu očistiti obariti u slanoj vodi oko 5 minuta. Ocediti i iseckati ukupno da bude 250 g. Umutiti jaja. Dodati jogurt i ulje. Izmešati. Dodati brašna pomešana sa prašom za pecivo u so. Umutiti smesu.", ""));
            recipes.Add(new Recipe("Torta Pahuljica", 94, "Umutiti bjelanca sa šećerom, dodati brašno i prašak za pecivo. Smjesu izliti u kalup, obložen papirom za pečenje, pa peći na 200 C oko 30 minuta. Prokuhati 100 ml mlijeka i vanilin šećer. Pečen biskvit odvojiti od papira, izbockati pa preliti vrelim mlijekom. Ostaviti da se ohladi.", ""));
            recipes.Add(new Recipe("Pica od suvog hleba", 23, "Na podmazanu tepsiju ređati suvi hleb (bez korica). Ubutati jaja, mlijeko, kajmak i sir sjednitini i natopiti preko hleba.Stavljati preko hleba, salamu, pršutu, kulen i sir dobro poređati i poprskati kečapom.", ""));
            recipes.Add(new Recipe("Pita sa koprivom", 64, "Koprivu očistiti obariti u slanoj vodi oko 5 minuta. Ocediti i iseckati ukupno da bude 250 g. Umutiti jaja. Dodati jogurt i ulje. Izmešati. Dodati brašna pomešana sa prašom za pecivo u so. Umutiti smesu.", ""));
            recipes.Add(new Recipe("Torta Pahuljica", 94, "Umutiti bjelanca sa šećerom, dodati brašno i prašak za pecivo. Smjesu izliti u kalup, obložen papirom za pečenje, pa peći na 200 C oko 30 minuta. Prokuhati 100 ml mlijeka i vanilin šećer. Pečen biskvit odvojiti od papira, izbockati pa preliti vrelim mlijekom. Ostaviti da se ohladi.", ""));

            group= new Group(4, availableGroceries, new List<User>(), shoppingCart, recipes);
            group.AddMember(new User("Dusan", "Janakovic", "Wicked", "qwerty", "dusann.jankovic@elfak.rs", ""));
            group.AddMember(new User("Matija", "Janic", "AnubisLP", "matko123", "matija.janic@elfak.rs", ""));
            group.AddMember(new User("Lazar", "Pavlovic", "Brahman_n", "perfeks38", "lazarp@elfak.rs", ""));
        }
    }
}