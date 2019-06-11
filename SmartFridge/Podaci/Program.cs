using WCFbaza.ServiceReference1;
using System.Collections.Generic;
using System;
using System.IO;

namespace WCFbazasadrzaj
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client Klijent = new Service1Client();

            RecipeDetails recept1 = new RecipeDetails();
            recept1.ID = 1;
            recept1.Name = "Bela riba u paradajz sosu";
            recept1.Description = "Ugrejte rernu na 200 C. Premažite tanko uljem dno posude za pečenje. " +
                "Filete ribe postavite tako da kožica, ukoliko je ima, bude dole. Paradajz isecite na manje komade pa poređajte pored ribe. " +
                "Dodajte sos iz konzerve. Listove bosiljka isecite i pospite polovinu preko ribe i paradjza. Iscedite limun pa poprskajte sve njime. " +
                "Posolite i pobiberite po ukusu. Pecite, nepoklopljeno oko 15 minuta. Pospite preostalim iseckanim listovima bosiljka i služite.";
            Klijent.loadRecipe(recept1);

            GroceryDetails namirnica1 = new GroceryDetails();
            namirnica1.Name = "Oslić file";
            namirnica1.Unit = "Komad";
            namirnica1.Category = "Riba";
            Klijent.loadGrocerie(namirnica1);

            GroceryDetails namirnica2 = new GroceryDetails();
            namirnica2.Name = "Paradajz";
            namirnica2.Unit = "Gram";
            namirnica2.Category = "Povrće";
            Klijent.loadGrocerie(namirnica2);

            GroceryDetails namirnica3 = new GroceryDetails();
            namirnica3.Name = "Sok od paradajza";
            namirnica3.Unit = "Mililitar";
            namirnica3.Category = "Pića";
            Klijent.loadGrocerie(namirnica3);

            GroceryDetails namirnica4 = new GroceryDetails();
            namirnica4.Name = "Sok od limuna";
            namirnica4.Unit = "Mililitar";
            namirnica4.Category = "Pića";
            Klijent.loadGrocerie(namirnica4);

            GroceryDetails namirnica5 = new GroceryDetails();
            namirnica5.Name = "Bosiljak";
            namirnica5.Unit = "Gram";
            namirnica5.Category = "Začin";
            Klijent.loadGrocerie(namirnica5);
            /*
    oslic file komad 4
    pradajz kilogram 0,3
    150 ml paradajz soka)
    limunov sok 2 kasike
    bosiljak
*/
            RecipeDetails recept2 = new RecipeDetails();
            recept2.ID = 2;
            recept2.Name = "Kukuruzna pita sa sirom";
            recept2.Description = "Tanke kore za pitu preseci po sirini i prekriti vlaznom krpom da se ne suse dok pripremite fil. " +
                "Za fil pomesati kajmak, sir, jaja,0,5 dl ulja, jogurt, p.z.p.i semenke bundeve. Soli dodajte po ukusu. " +
                "Uzimati po dve kore, na prvu kapnuti par kapi ulja i razmazati, preklopiti pa na drugu namazati dve kasike fila, a krajeve ostavljati prazne." +
                "Stranicne delove preklopiti prema unutra pa zamotati u 'stapice'. Gotove stapice redjati u pleh, premazati ih ostatkom fila i obilno posuti palentom. " +
                "Peci u zagrejanoj rerni na 200 C oko pola sata.";
            Klijent.loadRecipe(recept2);

            GroceryDetails namirnica6 = new GroceryDetails();
            namirnica6.Name = "Kore";
            namirnica6.Unit = "Gram";
            namirnica6.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica6);

            GroceryDetails namirnica7 = new GroceryDetails();
            namirnica7.Name = "Kajmak";
            namirnica7.Unit = "Gram";
            namirnica7.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica7);

            GroceryDetails namirnica8 = new GroceryDetails();
            namirnica8.Name = "Krem sir";
            namirnica8.Unit = "Gram";
            namirnica8.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica8);

            GroceryDetails namirnica9 = new GroceryDetails();
            namirnica9.Name = "Jogurt";
            namirnica9.Unit = "Mililitar";
            namirnica9.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica9);

            GroceryDetails namirnica10 = new GroceryDetails();
            namirnica10.Name = "Jaje";
            namirnica10.Unit = "Komad";
            namirnica10.Category = "Životinjski_proizvod";
            Klijent.loadGrocerie(namirnica10);

            GroceryDetails namirnica11 = new GroceryDetails();
            namirnica11.Name = "Prašak za pecivo";
            namirnica11.Unit = "Komad";
            namirnica11.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica11);

            GroceryDetails namirnica12 = new GroceryDetails();
            namirnica12.Name = "Semenke bundeve";
            namirnica12.Unit = "Gram";
            namirnica12.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica12);

            GroceryDetails namirnica13 = new GroceryDetails();
            namirnica13.Name = "Palenta";
            namirnica13.Unit = "Gram";
            namirnica13.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica13);

            GroceryDetails namirnica14 = new GroceryDetails();
            namirnica14.Name = "Ulje";
            namirnica14.Unit = "Mililitar";
            namirnica14.Category = "Ulja";
            Klijent.loadGrocerie(namirnica14);

            GroceryDetails namirnica15 = new GroceryDetails();
            namirnica15.Name = "So";
            namirnica15.Unit = "Gram";
            namirnica15.Category = "Začin";
            Klijent.loadGrocerie(namirnica15);

            /*

    500 gr kore za pitu
    300 gr kajmak
    100 gr krem sir
    200 ml jogurt
    2 kom jaja
    1/2 prasak za pecivo
    30 gr semenke bundeve
    250 gr palente ( kukuruzni griz )
    so
    1,5 dl ulja

*/
            RecipeDetails recept3 = new RecipeDetails();
            recept3.ID = 3;
            recept3.Name = "Sir u paprikama";
            recept3.Description = "Cele paprike prokuvajte oko 5 minuta u blago posoljenoj vodi te odmah ohladite hladnom vodom. " +
                "Prerežite ih po dužini, očistite od semenki i žilica. Električnom mešalicom dobro izmešajte sveži kravlji sir s jajetom, " +
                "gorgonzolom iseckanom na sitne kockice i Vegetom. Rasporedite sir u polovine paprika i stavite u nauljenu vatrostalnu posudu. " +
                "Pecite na 200°C oko 20 minuta.";
            Klijent.loadRecipe(recept3);

            GroceryDetails namirnica16 = new GroceryDetails();
            namirnica16.Name = "Sir";
            namirnica16.Unit = "Gram";
            namirnica16.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica16);

            GroceryDetails namirnica17 = new GroceryDetails();
            namirnica17.Name = "Gorgonzola";
            namirnica17.Unit = "Gram";
            namirnica17.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica17);

            GroceryDetails namirnica19 = new GroceryDetails();
            namirnica19.Name = "Crvena paprika";
            namirnica19.Unit = "Komad";
            namirnica19.Category = "Povrće";
            Klijent.loadGrocerie(namirnica19);

            GroceryDetails namirnica20 = new GroceryDetails();
            namirnica20.Name = "Vegeta";
            namirnica20.Unit = "Gram";
            namirnica20.Category = "Začin";
            Klijent.loadGrocerie(namirnica20);

            GroceryDetails namirnica21 = new GroceryDetails();
            namirnica21.Name = "Maslinovo ulje";
            namirnica21.Unit = "Mililitar";
            namirnica21.Category = "Ulja";
            Klijent.loadGrocerie(namirnica21);

            /*500 g kravljeg sira
            100 g gorgonzole
            4 crvene paprike
            1 jaje
            1 kašika Vegete
            2 kašike maslinovog ulja
            so*/
            RecipeDetails recept4 = new RecipeDetails();
            recept4.ID = 4;
            recept4.Name = "Pohovane tikvice";
            recept4.Description = "Tikvice očistimo nasečemo uzduž i posolimo sa obe strane po ukusu. Svaki komad prvo uvaljamo u brašno pa u umućena jaja. " +
                "Pržimo u dubokom ulju na umerenoj temperaturi sa obe strane. Pržene tikvice vadimo na tanjir sa ubrusom koje će upiti višak masnoće.";
            Klijent.loadRecipe(recept4);

            GroceryDetails namirnica22 = new GroceryDetails();
            namirnica22.Name = "Brašno";
            namirnica22.Unit = "Gram";
            namirnica22.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica22);

            GroceryDetails namirnica23 = new GroceryDetails();
            namirnica23.Name = "Tikvica";
            namirnica23.Unit = "Gram";
            namirnica23.Category = "Povrće";
            Klijent.loadGrocerie(namirnica23);

            /*    500 g tivica
    2 jajeta
    200 g brašna
    po ukusu so
    za prženje ulje*/
            RecipeDetails recept5 = new RecipeDetails();
            recept5.ID = 5;
            recept5.Name = "Piletina sa šampinjonima";
            recept5.Description = "Iseckati crni luk zajedno sa belim lukom i šargarepom (na kockice). Propržiti. U drugoj posudi pripremiti belo meso." +
                " Odvojiti ga od kostiju i iseći na manje šnicle. Svaku šniclu valjati u brašno pa poređati po izdinstanom luku. " +
                "Poredjati meso jedno pored drugog, a ako ima još mesa poredjati i odozgo. Naliti meso sa čašom vode 2 dl i dinstati na tihoj vatri 30 minuta. " +
                "Povremeno šerpu protresti. 10 minuta pred kraj dodati očišćene šampinjone isečene samo na pola. Posle desetak minuta dodati prvo razmućen gustin u malo vode, a odmah zatim i dve kašike pavlake. " +
                "Prokrčkati jedan minut i skloniti sa vatre i začiniti. Skuvati i pirinač kao prilog i aranžirati.";
            Klijent.loadRecipe(recept5);

            GroceryDetails namirnica24 = new GroceryDetails();
            namirnica24.Name = "Belo meso";
            namirnica24.Unit = "Gram";
            namirnica24.Category = "Meso";
            Klijent.loadGrocerie(namirnica24);

            GroceryDetails namirnica25 = new GroceryDetails();
            namirnica25.Name = "Šampinjoni";
            namirnica25.Unit = "Gram";
            namirnica25.Category = "Pečurke";
            Klijent.loadGrocerie(namirnica25);

            GroceryDetails namirnica26 = new GroceryDetails();
            namirnica26.Name = "Crni luk";
            namirnica26.Unit = "Komad";
            namirnica26.Category = "Povrće";
            Klijent.loadGrocerie(namirnica26);

            GroceryDetails namirnica27 = new GroceryDetails();
            namirnica27.Name = "Beli luk";
            namirnica27.Unit = "Komad";
            namirnica27.Category = "Povrće";
            Klijent.loadGrocerie(namirnica27);

            GroceryDetails namirnica28 = new GroceryDetails();
            namirnica28.Name = "Šargarepa";
            namirnica28.Unit = "Komad";
            namirnica28.Category = "Povrće";
            Klijent.loadGrocerie(namirnica28);

            GroceryDetails namirnica29 = new GroceryDetails();
            namirnica29.Name = "Kisela pavlaka";
            namirnica29.Unit = "Gram";
            namirnica29.Category = "Mlečni proizvod";
            Klijent.loadGrocerie(namirnica29);

            GroceryDetails namirnica30 = new GroceryDetails();
            namirnica30.Name = "Gustin";
            namirnica30.Unit = "Gram";
            namirnica30.Category = "dodatak";
            Klijent.loadGrocerie(namirnica30);

            GroceryDetails namirnica31 = new GroceryDetails();
            namirnica31.Name = "Pirinač";
            namirnica31.Unit = "Gram";
            namirnica31.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica31);

            GroceryDetails namirnica32 = new GroceryDetails();
            namirnica32.Name = "Kurkuma";
            namirnica32.Unit = "Gram";
            namirnica32.Category = "Začin";
            Klijent.loadGrocerie(namirnica32);

            ContainsDetails sadrzaj24 = new ContainsDetails();
            sadrzaj24.RecipeID = 5;
            sadrzaj24.Grocery = namirnica24;
            sadrzaj24.Amount = 500;
            Klijent.loadContains(sadrzaj24);

            ContainsDetails sadrzaj25 = new ContainsDetails();
            sadrzaj25.RecipeID = 5;
            sadrzaj25.Grocery = namirnica25;
            sadrzaj25.Amount = 500;
            Klijent.loadContains(sadrzaj25);

            ContainsDetails sadrzaj26 = new ContainsDetails();
            sadrzaj26.RecipeID = 5;
            sadrzaj26.Grocery = namirnica26;
            sadrzaj26.Amount = 1;
            Klijent.loadContains(sadrzaj26);

            ContainsDetails sadrzaj27 = new ContainsDetails();
            sadrzaj27.RecipeID = 5;
            sadrzaj27.Grocery = namirnica27;
            sadrzaj27.Amount = 2;
            Klijent.loadContains(sadrzaj27);

            ContainsDetails sadrzaj28 = new ContainsDetails();
            sadrzaj28.RecipeID = 5;
            sadrzaj28.Grocery = namirnica28;
            sadrzaj28.Amount = 1;
            Klijent.loadContains(sadrzaj28);

            ContainsDetails sadrzaj29 = new ContainsDetails();
            sadrzaj29.RecipeID = 5;
            sadrzaj29.Grocery = namirnica29;
            sadrzaj29.Amount = 30;
            Klijent.loadContains(sadrzaj29);

            ContainsDetails sadrzaj30 = new ContainsDetails();
            sadrzaj30.RecipeID = 5;
            sadrzaj30.Grocery = namirnica30;
            sadrzaj30.Amount = 15;
            Klijent.loadContains(sadrzaj30);

            ContainsDetails sadrzaj31 = new ContainsDetails();
            sadrzaj31.RecipeID = 5;
            sadrzaj31.Grocery = namirnica31;
            sadrzaj31.Amount = 200;
            Klijent.loadContains(sadrzaj31);

            ContainsDetails sadrzaj32 = new ContainsDetails();
            sadrzaj32.RecipeID = 5;
            sadrzaj32.Grocery = namirnica32;
            sadrzaj32.Amount = 5;
            Klijent.loadContains(sadrzaj32);
            /*    500 g belog mesa//
    500 g šampinjona//
    1 veća glavica crnog luka//
    2 česne belog luka//
    1 veća šargarepa//
    1 kašika začina
    po želji biber
    2 kašike kisele pavlake//
    1 kašika gustina//
        200 g pirinča//
    1 kašičica kurkume//
    1 kašičica začina*/
            RecipeDetails recept6 = new RecipeDetails();
            recept6.ID = 6;
            recept6.Name = "Zapečena piletina sa spanaćem";
            recept6.Description = "Pileće grudi isečemo na kocke (ili na šnicle), posolimo, začinimo vegetom, " +
                "pobiberimo i pržimo u tiganju sa zagrejanim uljem. U tiganj nalijemo 100 mililitara vode. " +
                "Glavicu luka isečemo na tanke šnite i dodamo u tiganj na šporetu. Još jednom začinimo vegetom. " +
                "Dodamo crvenu mlevenu papriku i sipamo još 100 mililitara vode. Keramičku posudu poprskamo uljem i stavimo pola od prethodno opranih listova spanaća. " +
                "Pola sadržine iz tiganja nanesemo u keramičku posudu. Potom preko stavimo preostale listove spanaća, pa preostalu sadržinu iz tiganja dodamo u posudu. " +
                "Poklopimo poklopcem i stavimo u rernu. Pečemo 60 minuta na 220 stepeni. Izvadimo posudu iz rerne i kašikom izvadimo jelo na posude za serviranje.";
            Klijent.loadRecipe(recept6);

            GroceryDetails namirnica34 = new GroceryDetails();
            namirnica34.Name = "Mlevena paprika";
            namirnica34.Unit = "Gram";
            namirnica34.Category = "Meso";
            Klijent.loadGrocerie(namirnica34);

            GroceryDetails namirnica35 = new GroceryDetails();
            namirnica35.Name = "Mleveni crni biber";
            namirnica35.Unit = "Gram";
            namirnica35.Category = "Začin";
            Klijent.loadGrocerie(namirnica35);

            GroceryDetails namirnica307 = new GroceryDetails();
            namirnica307.Name = "Spanać";
            namirnica307.Unit = "Gram";
            namirnica307.Category = "Bilje";
            Klijent.loadGrocerie(namirnica307);

            /*600 grama pilećih grudi (filea), //
             * 1 kilogram spanaća, //
             * 2 kašike vegeta, 
             * 1 glavica luka, //
             * 1 kašika mlevene paprike,// 
             * ulje, 
             * so, 
             * mleveni crni biber*///
            ContainsDetails sadrzaj1020 = new ContainsDetails();
            sadrzaj1020.RecipeID = 6;
            sadrzaj1020.Grocery = namirnica20;
            sadrzaj1020.Amount = 30;
            Klijent.loadContains(sadrzaj1020);

            ContainsDetails sadrzaj1026 = new ContainsDetails();
            sadrzaj1026.RecipeID = 6;
            sadrzaj1026.Grocery = namirnica26;
            sadrzaj1026.Amount = 1;
            Klijent.loadContains(sadrzaj1026);

            ContainsDetails sadrzaj1024 = new ContainsDetails();
            sadrzaj1024.RecipeID = 6;
            sadrzaj1024.Grocery = namirnica24;
            sadrzaj1024.Amount = 600;
            Klijent.loadContains(sadrzaj1024);

            ContainsDetails sadrzaj34 = new ContainsDetails();
            sadrzaj34.RecipeID = 6;
            sadrzaj34.Grocery = namirnica34;
            sadrzaj34.Amount = 15;
            Klijent.loadContains(sadrzaj34);

            ContainsDetails sadrzaj35 = new ContainsDetails();
            sadrzaj35.RecipeID = 6;
            sadrzaj35.Grocery = namirnica35;
            sadrzaj35.Amount = 1;
            Klijent.loadContains(sadrzaj35);

            ContainsDetails sadrzaj307 = new ContainsDetails();
            sadrzaj307.RecipeID = 6;
            sadrzaj307.Grocery = namirnica307;
            sadrzaj307.Amount = 1000;
            Klijent.loadContains(sadrzaj307);

            RecipeDetails recept7 = new RecipeDetails();
            recept7.ID = 7;
            recept7.Name = "Musaka";
            recept7.Description = "Šargarepu očistiti i izrendati. Luk očistiti i iseći na sitne komade. " +
                "Na zagrejanom ulju propržiti luk, dodati mleveno meso (ja sam stavila mešavinu svinjskog i junećeg), posoliti, začiniti po ukusu, dodati šargarepu pa šoljicu vode i prodinstati. " +
                "Krompir skuvati, oljuštiti i iseći na kolutove. Malo ga posoliti i začiniti. U pouljanu tepsiju ili u vatrostalnu činiju ređati red krompira, red mesa, zatim red krompira, red mesa i završiti krompirom. " +
                "Usuti malo (pola šoljice) vode. Peći oko pola sata u rerni zagrejanoj na 180 C. Izvaditi iz rerne. " +
                "Ulupati jaja, dodati jogurt, začine i izmešati i preliti musaku. Vratiti u rernu i peći još oko 15 minuta. Poslužiti toplo.";
            Klijent.loadRecipe(recept7);

            GroceryDetails namirnica36 = new GroceryDetails();
            namirnica36.Name = "Krompir";
            namirnica36.Unit = "Gram";
            namirnica36.Category = "Povrće";
            Klijent.loadGrocerie(namirnica36);

            GroceryDetails namirnica37 = new GroceryDetails();
            namirnica37.Name = "Mleveno meso";
            namirnica37.Unit = "Gram";
            namirnica37.Category = "Meso";
            Klijent.loadGrocerie(namirnica37);

            /*    1 kg krompira//
    500 g mlevenog mesa//
    1 glavica crnog luka//
    2 šargarepe//
    2 jajeta//
    200 ml jogurta*/

            ContainsDetails sadrzaj2009 = new ContainsDetails();
            sadrzaj2009.RecipeID = 7;
            sadrzaj2009.Grocery = namirnica9;
            sadrzaj2009.Amount = 200;
            Klijent.loadContains(sadrzaj2009);

            ContainsDetails sadrzaj2028 = new ContainsDetails();
            sadrzaj2028.RecipeID = 7;
            sadrzaj2028.Grocery = namirnica28;
            sadrzaj2028.Amount = 2;
            Klijent.loadContains(sadrzaj2028);

            ContainsDetails sadrzaj2026 = new ContainsDetails();
            sadrzaj2026.RecipeID = 7;
            sadrzaj2026.Grocery = namirnica26;
            sadrzaj2026.Amount = 1;
            Klijent.loadContains(sadrzaj2026);

            ContainsDetails sadrzaj0710 = new ContainsDetails();
            sadrzaj0710.RecipeID = 7;
            sadrzaj0710.Grocery = namirnica10;
            sadrzaj0710.Amount = 2;
            Klijent.loadContains(sadrzaj0710);

            ContainsDetails sadrzaj36 = new ContainsDetails();
            sadrzaj36.RecipeID = 7;
            sadrzaj36.Grocery = namirnica36;
            sadrzaj36.Amount = 1000;
            Klijent.loadContains(sadrzaj36);

            ContainsDetails sadrzaj37 = new ContainsDetails();
            sadrzaj37.RecipeID = 7;
            sadrzaj37.Grocery = namirnica37;
            sadrzaj37.Amount = 500;
            Klijent.loadContains(sadrzaj37);


            RecipeDetails recept8 = new RecipeDetails();
            recept8.ID = 8;
            recept8.Name = "Punjene tikvice";
            recept8.Description = "Meso izmešati sa jednim jajetom, malo brašna i svim začinima, pa napraviti male ćufte i propržiti na ulju. " +
                "Tikvice preseći po dužini i izdubiti ih da se dobiju lađice i posoliti. Na tikvice ređati naizmenično ćufte i kačkavalj isečen na kocke. " +
                "Tikvice preliti sa malo paradajz sosa. Jedno jaje umutiti sa malo mleka i dodati so, biber i peršun, pa preliti preko tikvica. " +
                "Tikvice preliti sa malo ulja i staviti da se peku na 180 stepeni, dok ne porumene.";
            Klijent.loadRecipe(recept8);

            GroceryDetails namirnica38 = new GroceryDetails();
            namirnica38.Name = "Kačkavalj";
            namirnica38.Unit = "Gram";
            namirnica38.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica38);

            GroceryDetails namirnica39 = new GroceryDetails();
            namirnica39.Name = "Mleko";
            namirnica39.Unit = "Mililitar";
            namirnica39.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica39);

            GroceryDetails namirnica40 = new GroceryDetails();
            namirnica40.Name = "Paradajz pelat";
            namirnica40.Unit = "Mililitar";
            namirnica40.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica40);

            /*  3 tikvice//
                300 g mlevenog mesa//
                2 jajeta//
                100 g kačkavalja//
                4 kašike mleka//
                4 kašike paradajz pelata//
                1 kašika brašna//
                po ukusu so
                po ukusu biber
                po ukusu suvi biljni začin*/

            ContainsDetails sadrzaj822 = new ContainsDetails();
            sadrzaj822.RecipeID = 8;
            sadrzaj822.Grocery = namirnica22;
            sadrzaj822.Amount = 15;
            Klijent.loadContains(sadrzaj822);

            ContainsDetails sadrzaj837 = new ContainsDetails();
            sadrzaj837.RecipeID = 8;
            sadrzaj837.Grocery = namirnica37;
            sadrzaj837.Amount = 300;
            Klijent.loadContains(sadrzaj837);

            ContainsDetails sadrzaj823 = new ContainsDetails();
            sadrzaj823.RecipeID = 8;
            sadrzaj823.Grocery = namirnica23;
            sadrzaj823.Amount = 500;
            Klijent.loadContains(sadrzaj823);

            ContainsDetails sadrzaj810 = new ContainsDetails();
            sadrzaj810.RecipeID = 8;
            sadrzaj810.Grocery = namirnica10;
            sadrzaj810.Amount = 2;
            Klijent.loadContains(sadrzaj810);

            ContainsDetails sadrzaj38 = new ContainsDetails();
            sadrzaj38.RecipeID = 8;
            sadrzaj38.Grocery = namirnica38;
            sadrzaj38.Amount = 100;
            Klijent.loadContains(sadrzaj38);

            ContainsDetails sadrzaj39 = new ContainsDetails();
            sadrzaj39.RecipeID = 8;
            sadrzaj39.Grocery = namirnica39;
            sadrzaj39.Amount = 60;
            Klijent.loadContains(sadrzaj39);

            ContainsDetails sadrzaj40 = new ContainsDetails();
            sadrzaj40.RecipeID = 8;
            sadrzaj40.Grocery = namirnica40;
            sadrzaj40.Amount = 100;
            Klijent.loadContains(sadrzaj40);

            RecipeDetails recept9 = new RecipeDetails();
            recept9.ID = 9;
            recept9.Name = "Rolat od krompira sa slaninom";
            recept9.Description = "U plitki pleh staviti papir za pečenje pa ga posuti sa polovinom izrendanog sira. " +
                "Po siru poređati tanje kolutove očišćenog krompira. Kolutovi treba da naležu jedan na drugi. Posuti začine po krompiru. " +
                "Narendati drugi deo sira i posuti susam. Staviti da se peče oko 25-30 minuta na 180'C da nlago krompir porumeni. " +
                "Onda izvaditi pleh pa uz ivicu staviti dve veće lente slanine. Lagano uz pomoć papira uviti rolat. Vratiti u rernu i peći još 15 minuta na 180'C. " +
                "Pečen rolat izvaditi, iseći na željene komade i poslužiti uz salatu i sveži sir.";
            Klijent.loadRecipe(recept9);

            GroceryDetails namirnica41 = new GroceryDetails();
            namirnica41.Name = "Slanina";
            namirnica41.Unit = "Gram";
            namirnica41.Category = "Meso";
            Klijent.loadGrocerie(namirnica41);

            /*        3 krompira--
                        70 g tvrdog sira--
                        po ukusu soli
                        po ukusu bibera
                        po ukusu dimljene aleve paprike
                        malo susama
                        2 lente dimljene slanine--*/

            ContainsDetails sadrzaj41 = new ContainsDetails();
            sadrzaj41.RecipeID = 9;
            sadrzaj41.Grocery = namirnica41;
            sadrzaj41.Amount = 50;
            Klijent.loadContains(sadrzaj41);

            ContainsDetails sadrzaj936 = new ContainsDetails();
            sadrzaj936.RecipeID = 9;
            sadrzaj936.Grocery = namirnica36;
            sadrzaj936.Amount = 400;
            Klijent.loadContains(sadrzaj936);

            ContainsDetails sadrzaj916 = new ContainsDetails();
            sadrzaj916.RecipeID = 9;
            sadrzaj916.Grocery = namirnica16;
            sadrzaj916.Amount = 70;
            Klijent.loadContains(sadrzaj916);


            RecipeDetails recept10 = new RecipeDetails();
            recept10.ID = 10;
            recept10.Name = "Svinjska džigerica";
            recept10.Description = "U pleh staviti džigericu. Stavite u predhodno zagrejanu rernu i peći 10 minuta na 200 stepeni. " +
                "Za to vreme u tiganju dinstati iseckan crni luk. Nakon 10 minuta, džigericu izvaditi iseckati na kockice i sa sve uljem ubaciti u tiganj. " +
                "Dodati začine i nastaviti sa dinstanjem 15-ak minuta. Kuvati do željene gustine sosa.";
            Klijent.loadRecipe(recept10);

            GroceryDetails namirnica42 = new GroceryDetails();
            namirnica42.Name = "Džigerica";
            namirnica42.Unit = "Gram";
            namirnica42.Category = "Meso";
            Klijent.loadGrocerie(namirnica42);

            /*    500 g svinjske džigerice--
    3 glavice crnog luka--
    malo soli
    2 kašičice suvog biljnog začina
    */

            ContainsDetails sadrzaj320 = new ContainsDetails();
            sadrzaj320.RecipeID = 10;
            sadrzaj320.Grocery = namirnica20;
            sadrzaj320.Amount = 30;
            Klijent.loadContains(sadrzaj320);

            ContainsDetails sadrzaj326 = new ContainsDetails();
            sadrzaj326.RecipeID = 10;
            sadrzaj326.Grocery = namirnica26;
            sadrzaj326.Amount = 3;
            Klijent.loadContains(sadrzaj326);

            ContainsDetails sadrzaj42 = new ContainsDetails();
            sadrzaj42.RecipeID = 10;
            sadrzaj42.Grocery = namirnica42;
            sadrzaj42.Amount = 500;
            Klijent.loadContains(sadrzaj42);


            RecipeDetails recept11 = new RecipeDetails();
            recept11.ID = 11;
            recept11.Name = "Sarmice od blitve";
            recept11.Description = "Listove blitve lepo oprati. Drške iseći. 600 ml vode posoliti i staviti na ringlu da provri. " +
                "Kad provri smanjiti temperaturu i kroz vodu pažljivo provlačiti listove blitve, samon koliko da omekšaju. " +
                "Listove stavljati sa strane da se malo prohlade. Saseckati crni luk i šargarepu i propržiti na malo ulja. Dodati meso kratko upržiti, dodati začine i pirinač. " +
                "Izmešati i jos malo upržiti i fil je spreman. Na listu blitve staviti kašiku fila. Bočne strane lista saviti ka unutra. I smotati sarmicu. Blago je stisnuti. " +
                "Sarmice ređati u vatrostalnoj posudi. Preliv: Umutiti jaje, malo posoliti dodati kiselo mleko, ulje i obično mleko. Izmešati i preliti preko sarmica. " +
                "Peći sarmice na 200 C oko 20 minuta.";
            Klijent.loadRecipe(recept11);


            GroceryDetails namirnica43 = new GroceryDetails();
            namirnica43.Name = "Blitva";
            namirnica43.Unit = "Gram";
            namirnica43.Category = "Bilje";
            Klijent.loadGrocerie(namirnica43);

            GroceryDetails namirnica44 = new GroceryDetails();
            namirnica44.Name = "Peršun";
            namirnica44.Unit = "Gram";
            namirnica44.Category = "Začin";
            Klijent.loadGrocerie(namirnica44);

            GroceryDetails namirnica45 = new GroceryDetails();
            namirnica45.Name = "Kiselo mleko";
            namirnica45.Unit = "Mililitar";
            namirnica45.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica45);

            /*10 većih listova blitve--
malo soli
oko 600 ml vode--
300 g mešanog mlevenog mesa--
1 glavica crvenog luka--
1 srednja šargarepa--
30 g kuvanog pirinča--
1 kašika seckanog peršuna--
    4 kašike ulja
    1 jaje--
    1/2 čaše (180 ml) kiselog mleka--
    50 ml mleka*/


            ContainsDetails sadrzaj1114 = new ContainsDetails();
            sadrzaj1114.RecipeID = 11;
            sadrzaj1114.Grocery = namirnica14;
            sadrzaj1114.Amount = 60;
            Klijent.loadContains(sadrzaj1114);

            ContainsDetails sadrzaj1128 = new ContainsDetails();
            sadrzaj1128.RecipeID = 11;
            sadrzaj1128.Grocery = namirnica28;
            sadrzaj1128.Amount = 1;
            Klijent.loadContains(sadrzaj1128);

            ContainsDetails sadrzaj1110 = new ContainsDetails();
            sadrzaj1110.RecipeID = 11;
            sadrzaj1110.Grocery = namirnica10;
            sadrzaj1110.Amount = 1;
            Klijent.loadContains(sadrzaj1110);

            ContainsDetails sadrzaj1131 = new ContainsDetails();
            sadrzaj1131.RecipeID = 11;
            sadrzaj1131.Grocery = namirnica31;
            sadrzaj1131.Amount = 30;
            Klijent.loadContains(sadrzaj1131);

            ContainsDetails sadrzaj1137 = new ContainsDetails();
            sadrzaj1137.RecipeID = 11;
            sadrzaj1137.Grocery = namirnica37;
            sadrzaj1137.Amount = 300;
            Klijent.loadContains(sadrzaj1137);

            ContainsDetails sadrzaj1126 = new ContainsDetails();
            sadrzaj1126.RecipeID = 11;
            sadrzaj1126.Grocery = namirnica26;
            sadrzaj1126.Amount = 1;
            Klijent.loadContains(sadrzaj1126);

            ContainsDetails sadrzaj43 = new ContainsDetails();
            sadrzaj43.RecipeID = 11;
            sadrzaj43.Grocery = namirnica43;
            sadrzaj43.Amount = 50;
            Klijent.loadContains(sadrzaj43);

            ContainsDetails sadrzaj44 = new ContainsDetails();
            sadrzaj44.RecipeID = 11;
            sadrzaj44.Grocery = namirnica44;
            sadrzaj44.Amount = 15;
            Klijent.loadContains(sadrzaj44);

            ContainsDetails sadrzaj45 = new ContainsDetails();
            sadrzaj45.RecipeID = 11;
            sadrzaj45.Grocery = namirnica43;
            sadrzaj45.Amount = 180;
            Klijent.loadContains(sadrzaj45);

            RecipeDetails recept12 = new RecipeDetails();
            recept12.ID = 12;
            recept12.Name = "Pasta karbonara";
            recept12.Description = "U slanoj vodi prokuvati testeninu i dodati malo maslinovog ulja, zatim dobro iscediti. " +
                "Blago ispržiti pančetu u tiganju, a u posebnoj posudi izmešati pavlaku i jaja. Dodati isprženu pančetu. " +
                "Sjediniti testeninu sa umakom.";
            Klijent.loadRecipe(recept12);

            GroceryDetails namirnica46 = new GroceryDetails();
            namirnica46.Name = "Testenina";
            namirnica46.Unit = "Komad";
            namirnica46.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica46);

            GroceryDetails namirnica47 = new GroceryDetails();
            namirnica47.Name = "Pančeta";
            namirnica47.Unit = "Gram";
            namirnica47.Category = "Meso";
            Klijent.loadGrocerie(namirnica47);
            /*pakovanje testenine po izboru, --
             * 3 jaja, --
             * 3 čaše punomasne pavlake, --
             * 300 g pančete (ili nečeg drugog suvomesnatog), --
             * origano, 
             * maslinovo ulje, --
             * so, 
             * začin po izboru, 
             * parmezan i 
             * prstohvat peršuna*/

            ContainsDetails sadrzaj1221 = new ContainsDetails();
            sadrzaj1221.RecipeID = 12;
            sadrzaj1221.Grocery = namirnica21;
            sadrzaj1221.Amount = 5;
            Klijent.loadContains(sadrzaj1221);

            ContainsDetails sadrzaj46 = new ContainsDetails();
            sadrzaj46.RecipeID = 12;
            sadrzaj46.Grocery = namirnica46;
            sadrzaj46.Amount = 1;
            Klijent.loadContains(sadrzaj46);

            ContainsDetails sadrzaj47 = new ContainsDetails();
            sadrzaj47.RecipeID = 12;
            sadrzaj47.Grocery = namirnica47;
            sadrzaj47.Amount = 300;
            Klijent.loadContains(sadrzaj47);

            ContainsDetails sadrzaj1229 = new ContainsDetails();
            sadrzaj1229.RecipeID = 12;
            sadrzaj1229.Grocery = namirnica10;
            sadrzaj1229.Amount = 400;
            Klijent.loadContains(sadrzaj1229);

            ContainsDetails sadrzaj1210 = new ContainsDetails();
            sadrzaj1210.RecipeID = 12;
            sadrzaj1210.Grocery = namirnica10;
            sadrzaj1210.Amount = 3;
            Klijent.loadContains(sadrzaj1210);

            RecipeDetails recept13 = new RecipeDetails();
            recept13.ID = 13;
            recept13.Name = "Francuski krompir sa slaninom";
            recept13.Description = "Krompir u ljusci skuvajte u jednoj posudi, 4 jaja u drugoj. Kada su gotovi, oljuštite ih i nasecite na kolutove. " +
                "Slaninu i luk isecite na manje komade. Na dno posude za pečenje stavite malo ulja pa ređajte  sastojke – luk, krompir, jaja, " +
                "slanina i tako sve dok ih ne potrošite. Na kraju krompir prelijte mešavinom umućenog jaja i pavlake. Pecite na 200 °C dok krompir ne dobije hrskavu koricu. ";
            Klijent.loadRecipe(recept13);


            /*1 kg krompira, --
             * 1 luk, --
             * 5 jaja, --
             * slanina, --
             * 1 čašica kisele pavlake, --
             * so, 
             * biber, 
             * bosiljak*/

            ContainsDetails sadrzaj1329 = new ContainsDetails();
            sadrzaj1329.RecipeID = 13;
            sadrzaj1329.Grocery = namirnica29;
            sadrzaj1329.Amount = 180;
            Klijent.loadContains(sadrzaj1329);

            ContainsDetails sadrzaj1341 = new ContainsDetails();
            sadrzaj1341.RecipeID = 13;
            sadrzaj1341.Grocery = namirnica41;
            sadrzaj1341.Amount = 300;
            Klijent.loadContains(sadrzaj1341);

            ContainsDetails sadrzaj1336 = new ContainsDetails();
            sadrzaj1336.RecipeID = 13;
            sadrzaj1336.Grocery = namirnica36;
            sadrzaj1336.Amount = 1000;
            Klijent.loadContains(sadrzaj1336);

            ContainsDetails sadrzaj1326 = new ContainsDetails();
            sadrzaj1326.RecipeID = 13;
            sadrzaj1326.Grocery = namirnica26;
            sadrzaj1326.Amount = 1;
            Klijent.loadContains(sadrzaj1326);

            ContainsDetails sadrzaj1310 = new ContainsDetails();
            sadrzaj1310.RecipeID = 13;
            sadrzaj1310.Grocery = namirnica10;
            sadrzaj1310.Amount = 5;
            Klijent.loadContains(sadrzaj1310);

            RecipeDetails recept14 = new RecipeDetails();
            recept14.ID = 14;
            recept14.Name = "Krilca sa krompirima";
            recept14.Description = "Krilca očistiti i oprati pre nego što ih namažemo sa malo ulja i začinom. Što duže tako odstoje sve su bolja. " +
                "Može i do sutradan. Pripremiti vodu sa dve kašike soli i staviti da provri.U tiganj sipati oko 1 dl ulja i malo vode. Krilca staviti na unutrašnju stranu, poklopiti i dinstati. " +
                "Kada donja strana dobije braon boju, okrenuti i bez poklopca završiti prženje. Krompire staviti u ključalu vodu sa 2 pune kašike soli. Samo 5 minuta. " +
                "U pripremljeno vruće ulje oko 1 dl sipati probarene krompiriće iz kojih ste samo prosuli vodu i odmah sipajte. Za svaki slučaj par sekundi zaštiti sa poklopcem i onda bez njega završiti prženje. " +
                "Često ih okrećite ili mrdajte da se izjednači boja. Spolja su sa koricom, a iznutra kao pire.";
            Klijent.loadRecipe(recept14);

            GroceryDetails namirnica48 = new GroceryDetails();
            namirnica48.Name = "Pileća krilca";
            namirnica48.Unit = "Gram";
            namirnica48.Category = "Meso";
            Klijent.loadGrocerie(namirnica48);
            /*    6 većih krilaca--
    1/2 kg krompirića--
    2 dl ulja--
    1 kašika suvog biljnog začina/vegeta--
    2 kašiike soli*/

            ContainsDetails sadrzaj1415 = new ContainsDetails();
            sadrzaj1415.RecipeID = 14;
            sadrzaj1415.Grocery = namirnica15;
            sadrzaj1415.Amount = 30;
            Klijent.loadContains(sadrzaj1415);

            ContainsDetails sadrzaj48 = new ContainsDetails();
            sadrzaj48.RecipeID = 14;
            sadrzaj48.Grocery = namirnica48;
            sadrzaj48.Amount = 750;
            Klijent.loadContains(sadrzaj48);

            ContainsDetails sadrzaj1436 = new ContainsDetails();
            sadrzaj1436.RecipeID = 14;
            sadrzaj1436.Grocery = namirnica36;
            sadrzaj1436.Amount = 500;
            Klijent.loadContains(sadrzaj1436);

            ContainsDetails sadrzaj1414 = new ContainsDetails();
            sadrzaj1414.RecipeID = 14;
            sadrzaj1414.Grocery = namirnica20;
            sadrzaj1414.Amount = 200;
            Klijent.loadContains(sadrzaj1414);

            ContainsDetails sadrzaj1420 = new ContainsDetails();
            sadrzaj1420.RecipeID = 14;
            sadrzaj1420.Grocery = namirnica20;
            sadrzaj1420.Amount = 15;
            Klijent.loadContains(sadrzaj1420);

            RecipeDetails recept15 = new RecipeDetails();
            recept15.ID = 15;
            recept15.Name = "Poširano jaje";
            recept15.Description = "Stavite veliku šerpu s vodom na ringlu i pustite da voda proključa. " +
                "Dodajte malo sirćeta (1 supena kašika na litar vode), jer sirće pomaže da se jaje stegne. " +
                "Pustite da se temperatura vode u šerpi snizi na 70 do 80°C. Tada kašikom zamešajte vodu da napravite vir. " +
                "Vir je važan, jer će upravo njegova sila navesti belance da se obmota oko žumanceta. Jaje izručite u šolju ili kutlaču, i pustite ga da polako sklizne u centar vira. " +
                "Jaje je gotovo nakon 3-5 minuta. Rupičastom kutlačom pažljivo izvadite jaje iz vode i pustite ga da se ocedi. Odmah poslužiti, jer se poširana jaja brzo hlade.";
            Klijent.loadRecipe(recept15);

            ContainsDetails sadrzaj1510 = new ContainsDetails();
            sadrzaj1510.RecipeID = 15;
            sadrzaj1510.Grocery = namirnica10;
            sadrzaj1510.Amount = 1;
            Klijent.loadContains(sadrzaj1510);

            GroceryDetails namirnica49 = new GroceryDetails();
            namirnica49.Name = "Sirće";
            namirnica49.Unit = "Mililitar";
            namirnica49.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica49);

            ContainsDetails sadrzaj49 = new ContainsDetails();
            sadrzaj49.RecipeID = 15;
            sadrzaj49.Grocery = namirnica49;
            sadrzaj49.Amount = 1;
            Klijent.loadContains(sadrzaj49);
            /*jaje, sirće*/
            RecipeDetails recept16 = new RecipeDetails();
            recept16.ID = 16;
            recept16.Name = "Zapečeni krompir sa jogurtom";
            recept16.Description = "Oljuštite krompir, isecite na kriške i prelijte jogurtom izmešanim sa začinima. " +
                "Pecite u podmazanom plehu ili na papiru za pečenje, oko 40 minuta, na temperaturi od 200 stepeni.";
            Klijent.loadRecipe(recept16);
            /*
    4-5 većih krompira
    2 kašike ulja
    2 kašike jogurta
    1 kašičica soli
    1/4 kašičice bibera
    1/2 kašičice mente
    1/2 kašičice timijana
*/

            ContainsDetails sadrzaj1535 = new ContainsDetails();
            sadrzaj1535.RecipeID = 16;
            sadrzaj1535.Grocery = namirnica35;
            sadrzaj1535.Amount = 1.5F;
            Klijent.loadContains(sadrzaj1535);

            ContainsDetails sadrzaj1515 = new ContainsDetails();
            sadrzaj1515.RecipeID = 16;
            sadrzaj1515.Grocery = namirnica15;
            sadrzaj1515.Amount = 5;
            Klijent.loadContains(sadrzaj1515);

            ContainsDetails sadrzaj1536 = new ContainsDetails();
            sadrzaj1536.RecipeID = 16;
            sadrzaj1536.Grocery = namirnica36;
            sadrzaj1536.Amount = 1000;
            Klijent.loadContains(sadrzaj1536);

            ContainsDetails sadrzaj1514 = new ContainsDetails();
            sadrzaj1514.RecipeID = 16;
            sadrzaj1514.Grocery = namirnica14;
            sadrzaj1514.Amount = 30;
            Klijent.loadContains(sadrzaj1514);

            ContainsDetails sadrzaj1509 = new ContainsDetails();
            sadrzaj1509.RecipeID = 16;
            sadrzaj1509.Grocery = namirnica9;
            sadrzaj1509.Amount = 30;
            Klijent.loadContains(sadrzaj1509);

            RecipeDetails recept17 = new RecipeDetails();
            recept17.ID = 17;
            recept17.Name = "Koh";
            recept17.Description = "Umutite penasto belanca, dodajte šećer (120 g) i žumanca. Zatim griz i brašno pomešano sa praškom za pecivo. Tepsiju podmažite margarinom i pospite brašnom. " +
                "Sipajte masu i pecite u zagrejanoj rerni na 200 stepeni oko 15 minuta. Mleko, šećer (80g) i vanil šećer stavite da provri. " +
                "Vruć koh prelijte prokuvanim mlekom, ostavite da se ohladi i secite na kocke.";
            Klijent.loadRecipe(recept17);

            GroceryDetails namirnica50 = new GroceryDetails();
            namirnica50.Name = "Šećer";
            namirnica50.Unit = "Gram";
            namirnica50.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica50);

            GroceryDetails namirnica51 = new GroceryDetails();
            namirnica51.Name = "Griz";
            namirnica51.Unit = "Gram";
            namirnica51.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica51);

            GroceryDetails namirnica52 = new GroceryDetails();
            namirnica52.Name = "Vanilin šećer";
            namirnica52.Unit = "Komad";
            namirnica52.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica52);
            /*    8 jaja--
    8 kašika šećera--
    14 kašika griza--
    3 kašike brašna--
    1 kesica praška za pecivo--
                 1 l mleka--
    6 kašika šećera--
    1 kesica vanil šećera*/

            ContainsDetails sadrzaj52 = new ContainsDetails();
            sadrzaj52.RecipeID = 17;
            sadrzaj52.Grocery = namirnica52;
            sadrzaj52.Amount = 1;
            Klijent.loadContains(sadrzaj52);

            ContainsDetails sadrzaj1739 = new ContainsDetails();
            sadrzaj1739.RecipeID = 17;
            sadrzaj1739.Grocery = namirnica39;
            sadrzaj1739.Amount = 1000;
            Klijent.loadContains(sadrzaj1739);

            ContainsDetails sadrzaj1711 = new ContainsDetails();
            sadrzaj1711.RecipeID = 17;
            sadrzaj1711.Grocery = namirnica11;
            sadrzaj1711.Amount = 1;
            Klijent.loadContains(sadrzaj1711);

            ContainsDetails sadrzaj1722 = new ContainsDetails();
            sadrzaj1722.RecipeID = 17;
            sadrzaj1722.Grocery = namirnica22;
            sadrzaj1722.Amount = 50;
            Klijent.loadContains(sadrzaj1722);

            ContainsDetails sadrzaj51 = new ContainsDetails();
            sadrzaj51.RecipeID = 17;
            sadrzaj51.Grocery = namirnica51;
            sadrzaj51.Amount = 100;
            Klijent.loadContains(sadrzaj51);

            ContainsDetails sadrzaj50 = new ContainsDetails();
            sadrzaj50.RecipeID = 17;
            sadrzaj50.Grocery = namirnica15;
            sadrzaj50.Amount = 200;
            Klijent.loadContains(sadrzaj50);

            ContainsDetails sadrzaj1710 = new ContainsDetails();
            sadrzaj1710.RecipeID = 17;
            sadrzaj1710.Grocery = namirnica10;
            sadrzaj1710.Amount = 8;
            Klijent.loadContains(sadrzaj1710);

            RecipeDetails recept18 = new RecipeDetails();
            recept18.ID = 18;
            recept18.Name = "Oreo torta";
            recept18.Description = "Pripremite petit beure i oreo keks. Obe vrste keksa krupnije izmrvite. Mikserom čvrsto umutiti šlag sa kiselom vodom. " +
                "Dodajte kiselu pavlaku, šećer u prahu i sve zajedno umutite u glatku masu. Dodajte mrvljeni keks i sve sjedinite mešanjem. " +
                "Posudu u kojoj će biti torta obložite streč folijom. Sipajte polovinu mase, poravnajte, a potom poređajte ceo oreo keks iz druge kutije. " +
                "Potom premažite ostatkom mase od pavlake i poravnajte. Tortu stavite u frižider preko noći da se ohladi i stegne, a keks omekša. Pre služenja tortu držite dva sata u zamrzivaču. " +
                "Okrenite je na veći tanjir, skinite foliju pa mokrom špatulom poravnajte da površina postane fina i glatka. " +
                "Čokoladu otopite na pari, pa gotovu tortu prelijte glazurom. Kada se glazura stegne tortu poslužite.";
            Klijent.loadRecipe(recept18);

            GroceryDetails namirnica53 = new GroceryDetails();
            namirnica53.Name = "Šlag";
            namirnica53.Unit = "Gram";
            namirnica53.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica53);

            GroceryDetails namirnica54 = new GroceryDetails();
            namirnica54.Name = "Petit beure keks";
            namirnica54.Unit = "Gram";
            namirnica54.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica54);

            GroceryDetails namirnica55 = new GroceryDetails();
            namirnica55.Name = "Oreo keks";
            namirnica55.Unit = "Gram";
            namirnica55.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica55);

            GroceryDetails namirnica56 = new GroceryDetails();
            namirnica56.Name = "Kisela voda";
            namirnica56.Unit = "Mililitar";
            namirnica56.Category = "Pića";
            Klijent.loadGrocerie(namirnica56);

            GroceryDetails namirnica57 = new GroceryDetails();
            namirnica57.Name = "Šećer u prahu";
            namirnica57.Unit = "Gram";
            namirnica57.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica57);

            GroceryDetails namirnica58 = new GroceryDetails();
            namirnica58.Name = "Čokolada";
            namirnica58.Unit = "Gram";
            namirnica58.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica58);
            /*    400 g šlaga
    500 ml kisele vode.
    200 g petit beure keksa.
    400 g kisele pavlake--
    350 g (1 kutija) oreo keksa.
    200 g šećera u prahu
        100 g čokolade
    3 kašike ulja--
    */
            ContainsDetails sadrzaj53 = new ContainsDetails();
            sadrzaj53.RecipeID = 18;
            sadrzaj53.Grocery = namirnica53;
            sadrzaj53.Amount = 400;
            Klijent.loadContains(sadrzaj53);

            ContainsDetails sadrzaj54 = new ContainsDetails();
            sadrzaj54.RecipeID = 18;
            sadrzaj54.Grocery = namirnica54;
            sadrzaj54.Amount = 200;
            Klijent.loadContains(sadrzaj54);

            ContainsDetails sadrzaj55 = new ContainsDetails();
            sadrzaj55.RecipeID = 18;
            sadrzaj55.Grocery = namirnica55;
            sadrzaj55.Amount = 350;
            Klijent.loadContains(sadrzaj55);

            ContainsDetails sadrzaj56 = new ContainsDetails();
            sadrzaj56.RecipeID = 18;
            sadrzaj56.Grocery = namirnica56;
            sadrzaj56.Amount = 500;
            Klijent.loadContains(sadrzaj56);

            ContainsDetails sadrzaj57 = new ContainsDetails();
            sadrzaj57.RecipeID = 18;
            sadrzaj57.Grocery = namirnica57;
            sadrzaj57.Amount = 200;
            Klijent.loadContains(sadrzaj57);

            ContainsDetails sadrzaj58 = new ContainsDetails();
            sadrzaj58.RecipeID = 18;
            sadrzaj58.Grocery = namirnica58;
            sadrzaj58.Amount = 100;
            Klijent.loadContains(sadrzaj58);

            ContainsDetails sadrzaj1814 = new ContainsDetails();
            sadrzaj1814.RecipeID = 18;
            sadrzaj1814.Grocery = namirnica14;
            sadrzaj1814.Amount = 50;
            Klijent.loadContains(sadrzaj1814);

            ContainsDetails sadrzaj1829 = new ContainsDetails();
            sadrzaj1829.RecipeID = 18;
            sadrzaj1829.Grocery = namirnica29;
            sadrzaj1829.Amount = 400;
            Klijent.loadContains(sadrzaj1829);

            RecipeDetails recept19 = new RecipeDetails();
            recept19.ID = 19;
            recept19.Name = "Oslić u sosu od mirođije";
            recept19.Description = "Filete uvaljati u mesavinu kukuruznog i pšeničnog brašna (100 g), pa ispržiti na vrelom ulju sa obe strane. " +
                "Pržene filete poređati na papirnatom ubrusu, kako bi upilo višak masnoće, začiniti i ostaviti po strani. " +
                "U tiganju stavite margarin, pa kad se otopi dodajte brašno (30 g) i mirođiju pa ih propržite." +
                "Nalijte mlekom i mešajte da se malo zgusne i vri nekoliko minuta. Dodajte so i biber i sos je gotov. " +
                "Poslužite filete oslića prelivene ovim sosom i po želji i krompirom.";
            Klijent.loadRecipe(recept19);

            GroceryDetails namirnica59 = new GroceryDetails();
            namirnica59.Name = "Margarin";
            namirnica59.Unit = "Gram";
            namirnica59.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica59);


            GroceryDetails namirnica60 = new GroceryDetails();
            namirnica60.Name = "Kukuruzno brašno";
            namirnica60.Unit = "Gram";
            namirnica60.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica60);

            GroceryDetails namirnica61 = new GroceryDetails();
            namirnica61.Name = "Mirođija";
            namirnica61.Unit = "Gram";
            namirnica61.Category = "Začin";
            Klijent.loadGrocerie(namirnica61);
            /*
            /5-6 fileti oslića//
            100 g kukuruznog brašna
100 g pšeničnog brašna//

            400 ml mleka//
1 kašika margarina//
2 kašike brašna//
1-2 kašičice mirođije 
             */

            ContainsDetails sadrzaj59 = new ContainsDetails();
            sadrzaj59.RecipeID = 19;
            sadrzaj59.Grocery = namirnica59;
            sadrzaj59.Amount = 15;
            Klijent.loadContains(sadrzaj59);

            ContainsDetails sadrzaj1939 = new ContainsDetails();
            sadrzaj1939.RecipeID = 19;
            sadrzaj1939.Grocery = namirnica39;
            sadrzaj1939.Amount = 400;
            Klijent.loadContains(sadrzaj1939);

            ContainsDetails sadrzaj1922 = new ContainsDetails();
            sadrzaj1922.RecipeID = 19;
            sadrzaj1922.Grocery = namirnica22;
            sadrzaj1922.Amount = 130;
            Klijent.loadContains(sadrzaj1922);

            ContainsDetails sadrzaj1901 = new ContainsDetails();
            sadrzaj1901.RecipeID = 19;
            sadrzaj1901.Grocery = namirnica1;
            sadrzaj1901.Amount = 600;
            Klijent.loadContains(sadrzaj1901);

            ContainsDetails sadrzaj1960 = new ContainsDetails();
            sadrzaj1960.RecipeID = 19;
            sadrzaj1960.Grocery = namirnica60;
            sadrzaj1960.Amount = 100;
            Klijent.loadContains(sadrzaj1960);

            ContainsDetails sadrzaj1961 = new ContainsDetails();
            sadrzaj1961.RecipeID = 19;
            sadrzaj1961.Grocery = namirnica61;
            sadrzaj1961.Amount = 10;
            Klijent.loadContains(sadrzaj1961);



            RecipeDetails recept20 = new RecipeDetails();
            recept20.ID = 20;
            recept20.Name = "Punjena jaja";
            recept20.Description = "Skuvana jaja pažljivo preseći preko pola ili po dužini i izvaditi žumance. " +
                "Žumanca pomešati sa 2-3 kašike majoneza, 1 kašikom senfa, malo soli, malo mlevenog belog ili crnog bibera. " +
                "Napuniti jaja i ukrasiti tankim i malim kriškicama slanine i mladog luka.";
            Klijent.loadRecipe(recept20);

            GroceryDetails namirnica62 = new GroceryDetails();
            namirnica62.Name = "Majonez";
            namirnica62.Unit = "Gram";
            namirnica62.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica62);

            GroceryDetails namirnica63 = new GroceryDetails();
            namirnica63.Name = "Senf";
            namirnica63.Unit = "Gram";
            namirnica63.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica63);

            GroceryDetails namirnica64 = new GroceryDetails();
            namirnica64.Name = "Mladi luk";
            namirnica64.Unit = "Gram";
            namirnica64.Category = "Povrće";
            Klijent.loadGrocerie(namirnica64);

            /*
            /    6 skuvanih jaja
            2 - 3 kašike majoneza
    1 kašika senfa
    na vrh noža mlevenog bibera
    po ukusu soli
    jedno pero mladog luka
    tanko isečeni listići slanine
            / */

            ContainsDetails sadrzaj2010 = new ContainsDetails();
            sadrzaj2010.RecipeID = 20;
            sadrzaj2010.Grocery = namirnica10;
            sadrzaj2010.Amount = 6;
            Klijent.loadContains(sadrzaj2010);

            ContainsDetails sadrzaj2062 = new ContainsDetails();
            sadrzaj2062.RecipeID = 20;
            sadrzaj2062.Grocery = namirnica62;
            sadrzaj2062.Amount = 50;
            Klijent.loadContains(sadrzaj2062);

            ContainsDetails sadrzaj2063 = new ContainsDetails();
            sadrzaj2063.RecipeID = 20;
            sadrzaj2063.Grocery = namirnica63;
            sadrzaj2063.Amount = 15;
            Klijent.loadContains(sadrzaj2063);

            ContainsDetails sadrzaj2064 = new ContainsDetails();
            sadrzaj2064.RecipeID = 20;
            sadrzaj2064.Grocery = namirnica64;
            sadrzaj2064.Amount = 1;
            Klijent.loadContains(sadrzaj2064);

            ContainsDetails sadrzaj2041 = new ContainsDetails();
            sadrzaj2041.RecipeID = 20;
            sadrzaj2041.Grocery = namirnica41;
            sadrzaj2041.Amount = 30;
            Klijent.loadContains(sadrzaj2041);

            RecipeDetails recept21 = new RecipeDetails();
            recept21.ID = 21;
            recept21.Name = "Čorba sa šargarepom i đumbirom";
            recept21.Description = "Šargarepu očistiti i iseći na kolutove. Beli luk i đumbir očistiti i iseći na listiće. " +
                "U šerpu sipati maslinovo ulje, zagrejati na umerenoj temeperaturi, pa dodati beli luk i đumbir. " +
                "Pržiti kratko, tek da pusti aromu i sve vreme mešati. Dodati šargarepu i sipati malo vode. Smanjiti temperaturu i ostaviti da se dinsta dok ne omekša. " +
                "Po potrebi dolivati vode. Kada je povrće lepo omekšalo, usitniti ga štapnim mikserom. Dodati još malo vode (po želji). Vratiti na šporet, dodati soli i bibera po ukusu i kuvati dok ne provri. " +
                "Služiti uz kiselo mleko ili jogurt.";
            Klijent.loadRecipe(recept21);

            GroceryDetails namirnica65 = new GroceryDetails();
            namirnica65.Name = "Đumbir";
            namirnica65.Unit = "Komad";
            namirnica65.Category = "Povrće";
            Klijent.loadGrocerie(namirnica65);

            /*
            /2 čena belog luka
            1 komadić đumbira
4 veće šargarepe
60 ml maslinovog ulja
            / */
            ContainsDetails sadrzaj2165 = new ContainsDetails();
            sadrzaj2165.RecipeID = 21;
            sadrzaj2165.Grocery = namirnica65;
            sadrzaj2165.Amount = 1;
            Klijent.loadContains(sadrzaj2165);

            ContainsDetails sadrzaj2121 = new ContainsDetails();
            sadrzaj2121.RecipeID = 21;
            sadrzaj2121.Grocery = namirnica21;
            sadrzaj2121.Amount = 60;
            Klijent.loadContains(sadrzaj2121);

            ContainsDetails sadrzaj2127 = new ContainsDetails();
            sadrzaj2127.RecipeID = 21;
            sadrzaj2127.Grocery = namirnica27;
            sadrzaj2127.Amount = 2;
            Klijent.loadContains(sadrzaj2127);

            ContainsDetails sadrzaj2128 = new ContainsDetails();
            sadrzaj2128.RecipeID = 21;
            sadrzaj2128.Grocery = namirnica28;
            sadrzaj2128.Amount = 4;
            Klijent.loadContains(sadrzaj2128);

            RecipeDetails recept22 = new RecipeDetails();
            recept22.ID = 22;
            recept22.Name = "Rolnice sa ajvarom i sirom";
            recept22.Description = "Tanko razvucite lisnato testo i isecite ga na kocke željene veličine. " +
                "Svaki kocku premažite ajvarom i raporedite sir preko ajvara. " +
                "Umotajte u rolnice, premažite umućenim jajetom i stavite da se peče oko 15 minuta na 200 stepeni.";
            Klijent.loadRecipe(recept22);

            GroceryDetails namirnica66 = new GroceryDetails();
            namirnica66.Name = "Lisnato testo";
            namirnica66.Unit = "Komad";
            namirnica66.Category = "Žitarice";
            Klijent.loadGrocerie(namirnica66);

            GroceryDetails namirnica67 = new GroceryDetails();
            namirnica67.Name = "Ajvar";
            namirnica67.Unit = "Gram";
            namirnica67.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica67);
            /*
                 500 g lisnatog testa
    nekoliko kašika ajvara
    100 g sira
    1 jaje
             */
            ContainsDetails sadrzaj2216 = new ContainsDetails();
            sadrzaj2216.RecipeID = 22;
            sadrzaj2216.Grocery = namirnica16;
            sadrzaj2216.Amount = 100;
            Klijent.loadContains(sadrzaj2216);

            ContainsDetails sadrzaj2210 = new ContainsDetails();
            sadrzaj2210.RecipeID = 22;
            sadrzaj2210.Grocery = namirnica10;
            sadrzaj2210.Amount = 1;
            Klijent.loadContains(sadrzaj2210);

            ContainsDetails sadrzaj2266 = new ContainsDetails();
            sadrzaj2266.RecipeID = 22;
            sadrzaj2266.Grocery = namirnica66;
            sadrzaj2266.Amount = 500;
            Klijent.loadContains(sadrzaj2266);

            ContainsDetails sadrzaj2267 = new ContainsDetails();
            sadrzaj2267.RecipeID = 22;
            sadrzaj2267.Grocery = namirnica67;
            sadrzaj2267.Amount = 60;
            Klijent.loadContains(sadrzaj2267);

            RecipeDetails recept23 = new RecipeDetails();
            recept23.ID = 23;
            recept23.Name = "Prebranac";
            recept23.Description = "Pasulj oprati naliti vodom i ostaviti da stoji preko noći. " +
                "Sutradan ocediti tu vodu, pasulj opet naliti vodom i kuvati 10-15 minuta. " +
                "Baciti vodu, dobro oprati pasulj, naliti ga hladnom vodom, dodati kasicicu soli i lovorov list. " +
                "Kuvati da omeksa. Potom ga ocediti od vode. Očistiti crni luk i staviti ga u hladnu vodu da odstoji desetak minuta. " +
                "Zatim ga iseći na tanke kolutove. Jedan deo ulja zagrejati u šerpi i ispržiti crni luk da porumeni. " +
                "Skloniti sa ringle i dodati sitno seckan beli luk, malo mlevenog bibera, aleve paprike i soli. " +
                "U keramičku ili vatrostalnu posudu stavljati red pasulja, red luka. Svaki red luka preliti kasikom ulja. " +
                "Poslednji red mora da bude pasulj. Na kraju naliti vodom gde se kuvao pasulj,da ogrezne, i peći u rerni zagrejanoj na 200C dok voda ne ispari i uhvati se korica (oko pola sata)";
            Klijent.loadRecipe(recept23);

            GroceryDetails namirnica68 = new GroceryDetails();
            namirnica68.Name = "Pasulj";
            namirnica68.Unit = "Gram";
            namirnica68.Category = "Povrće";
            Klijent.loadGrocerie(namirnica68);
            /*
                 500 g belog pasulja
    500 g crnog luka
    2-3 čena belog luka
    200 ml ulja
    1 lovorov list
    1 kašika aleve paprike
    so
    biber
             */
            ContainsDetails sadrzaj2334 = new ContainsDetails();
            sadrzaj2334.RecipeID = 23;
            sadrzaj2334.Grocery = namirnica34;
            sadrzaj2334.Amount = 15;
            Klijent.loadContains(sadrzaj2334);

            ContainsDetails sadrzaj2314 = new ContainsDetails();
            sadrzaj2314.RecipeID = 23;
            sadrzaj2314.Grocery = namirnica14;
            sadrzaj2314.Amount = 200;
            Klijent.loadContains(sadrzaj2314);

            ContainsDetails sadrzaj2327 = new ContainsDetails();
            sadrzaj2327.RecipeID = 23;
            sadrzaj2327.Grocery = namirnica27;
            sadrzaj2327.Amount = 3;
            Klijent.loadContains(sadrzaj2327);

            ContainsDetails sadrzaj2326 = new ContainsDetails();
            sadrzaj2326.RecipeID = 23;
            sadrzaj2326.Grocery = namirnica26;
            sadrzaj2326.Amount = 5;
            Klijent.loadContains(sadrzaj2326);

            ContainsDetails sadrzaj2368 = new ContainsDetails();
            sadrzaj2368.RecipeID = 23;
            sadrzaj2368.Grocery = namirnica68;
            sadrzaj2368.Amount = 500;
            Klijent.loadContains(sadrzaj2368);

            Klijent.deleteRecipe(24);
            RecipeDetails recept24 = new RecipeDetails();
            recept24.ID = 24;
            recept24.Name = "Svinjski gulaš";
            recept24.Description = "Zagrejati mast, dodati na kockice iseckano meso na sitne kockice i iseckan crni luk." +
                " U poklopljenoj šerpi na tihoj vatri dinstati. Po potrebi povremeno dolivati pomalo vode. " +
                "Kad meso omekša, sipati brašno, propržite pa dodati mlevenu papriku, " +
                "list lovora, seckani ili sok od paradajeza. Krčkati na tihoj vatri još oko pola sata, uz povremeno mešanje. ";
            Klijent.loadRecipe(recept24);



            GroceryDetails namirnica69 = new GroceryDetails();
            namirnica69.Name = "Svinjsko meso";
            namirnica69.Unit = "Gram";
            namirnica69.Category = "Meso";
            Klijent.loadGrocerie(namirnica69);

            GroceryDetails namirnica70 = new GroceryDetails();
            namirnica70.Name = "Mast";
            namirnica70.Unit = "Gram";
            namirnica70.Category = "Ulja";
            Klijent.loadGrocerie(namirnica70);
            /*    500 g svinjskog mesa
    2 glavice crnog luka
    2 veća seckana paradajza ili sok od paradajza
    1 kašika brašna
    1 kašičica crvene slatke ili ljute paprike
    po ukusu lovorov list
    po ukusu so
    po ukusu suvi biljni zacin
    2-3 kašike masti*/

            ContainsDetails sadrzaj2470 = new ContainsDetails();
            sadrzaj2470.RecipeID = 24;
            sadrzaj2470.Grocery = namirnica70;
            sadrzaj2470.Amount = 50;
            Klijent.loadContains(sadrzaj2470);

            ContainsDetails sadrzaj2434 = new ContainsDetails();
            sadrzaj2434.RecipeID = 24;
            sadrzaj2434.Grocery = namirnica34;
            sadrzaj2434.Amount = 5;
            Klijent.loadContains(sadrzaj2434);

            ContainsDetails sadrzaj2422 = new ContainsDetails();
            sadrzaj2422.RecipeID = 24;
            sadrzaj2422.Grocery = namirnica22;
            sadrzaj2422.Amount = 15;
            Klijent.loadContains(sadrzaj2422);

            ContainsDetails sadrzaj2402 = new ContainsDetails();
            sadrzaj2402.RecipeID = 24;
            sadrzaj2402.Grocery = namirnica2;
            sadrzaj2402.Amount = 2;
            Klijent.loadContains(sadrzaj2402);

            ContainsDetails sadrzaj2426 = new ContainsDetails();
            sadrzaj2426.RecipeID = 24;
            sadrzaj2426.Grocery = namirnica26;
            sadrzaj2426.Amount = 2;
            Klijent.loadContains(sadrzaj2426);

            ContainsDetails sadrzaj2469 = new ContainsDetails();
            sadrzaj2469.RecipeID = 24;
            sadrzaj2469.Grocery = namirnica69;
            sadrzaj2469.Amount = 500;
            Klijent.loadContains(sadrzaj2469);

            RecipeDetails recept25 = new RecipeDetails();
            recept25.ID = 25;
            recept25.Name = "Proja";
            recept25.Description = "Umutiti jaja, dodati jogurt, kiselu vodu i ulje. " +
                "Pomešati kukuruzno brašno, belo brašno, prašak za pecivo i so, pa dodati prethodnoj smesi. " +
                "Sve sjediniti, dodati izmrvljen sir i lepo izmešati. Sipati u podmazan pleh i posuti susamom. Peći 20 minuta na 220°C.";
            Klijent.loadRecipe(recept25);

            /*3 jajeta
1 čaša jogurta
300 ml kisele vode
1/2 jogurtske čaše ulja
250 g kukuruznog brašna
150 g belog brašna
1 kašičica soli
1 kesica praška za pecivo
250 g sira*/
            ContainsDetails sadrzaj2516 = new ContainsDetails();
            sadrzaj2516.RecipeID = 25;
            sadrzaj2516.Grocery = namirnica16;
            sadrzaj2516.Amount = 250;
            Klijent.loadContains(sadrzaj2516);

            ContainsDetails sadrzaj2515 = new ContainsDetails();
            sadrzaj2515.RecipeID = 25;
            sadrzaj2515.Grocery = namirnica15;
            sadrzaj2515.Amount = 5;
            Klijent.loadContains(sadrzaj2515);

            ContainsDetails sadrzaj2511 = new ContainsDetails();
            sadrzaj2511.RecipeID = 25;
            sadrzaj2511.Grocery = namirnica11;
            sadrzaj2511.Amount = 1;
            Klijent.loadContains(sadrzaj2511);

            ContainsDetails sadrzaj2522 = new ContainsDetails();
            sadrzaj2522.RecipeID = 25;
            sadrzaj2522.Grocery = namirnica22;
            sadrzaj2522.Amount = 150;
            Klijent.loadContains(sadrzaj2522);

            ContainsDetails sadrzaj2560 = new ContainsDetails();
            sadrzaj2560.RecipeID = 25;
            sadrzaj2560.Grocery = namirnica60;
            sadrzaj2560.Amount = 250;
            Klijent.loadContains(sadrzaj2560);

            ContainsDetails sadrzaj2514 = new ContainsDetails();
            sadrzaj2514.RecipeID = 25;
            sadrzaj2514.Grocery = namirnica14;
            sadrzaj2514.Amount = 100;
            Klijent.loadContains(sadrzaj2514);

            ContainsDetails sadrzaj2556 = new ContainsDetails();
            sadrzaj2556.RecipeID = 25;
            sadrzaj2556.Grocery = namirnica56;
            sadrzaj2556.Amount = 300;
            Klijent.loadContains(sadrzaj2556);

            ContainsDetails sadrzaj2509 = new ContainsDetails();
            sadrzaj2509.RecipeID = 25;
            sadrzaj2509.Grocery = namirnica9;
            sadrzaj2509.Amount = 200;
            Klijent.loadContains(sadrzaj2509);

            ContainsDetails sadrzaj2510 = new ContainsDetails();
            sadrzaj2510.RecipeID = 25;
            sadrzaj2510.Grocery = namirnica10;
            sadrzaj2510.Amount = 3;
            Klijent.loadContains(sadrzaj2510);

            RecipeDetails recept26 = new RecipeDetails();
            recept26.ID = 26;
            recept26.Name = "Pilav";
            recept26.Description = "Komade piletine skuvati. Na zagrejanom ulju ili masti, propržiti glavicu crnog luka, dodati seckanu šargarepu i očišćeni i oprani pirinač. " +
                "Tako još malo prodinstati pa zatim naliti polako vodom (ne preterati sa vodom jer će se morati duž kuvati, " +
                "a zrna pirinača će se raspati neka ostanu fina zrna) u kojoj se kuvalo mese posoliti i začiniti pa dodati kuvano meso i staviti da se peče.";
            Klijent.loadRecipe(recept26);

            GroceryDetails namirnica71 = new GroceryDetails();
            namirnica71.Name = "Piletina";
            namirnica71.Unit = "Gram";
            namirnica71.Category = "Meso";
            Klijent.loadGrocerie(namirnica71);
            /*
                 po želji komadi piletine
    1 šolja (2,5 dl) pirinča
    1 glavica crnog luka
    1 šargarepa
    po ukusu so
    po ukusu začin
    50 ml ulja ili masti
             */
            ContainsDetails sadrzaj2670 = new ContainsDetails();
            sadrzaj2670.RecipeID = 26;
            sadrzaj2670.Grocery = namirnica70;
            sadrzaj2670.Amount = 50;
            Klijent.loadContains(sadrzaj2670);

            ContainsDetails sadrzaj2628 = new ContainsDetails();
            sadrzaj2628.RecipeID = 26;
            sadrzaj2628.Grocery = namirnica28;
            sadrzaj2628.Amount = 1;
            Klijent.loadContains(sadrzaj2628);


            ContainsDetails sadrzaj2626 = new ContainsDetails();
            sadrzaj2626.RecipeID = 26;
            sadrzaj2626.Grocery = namirnica26;
            sadrzaj2626.Amount = 1;
            Klijent.loadContains(sadrzaj2626);

            ContainsDetails sadrzaj2671 = new ContainsDetails();
            sadrzaj2671.RecipeID = 26;
            sadrzaj2671.Grocery = namirnica71;
            sadrzaj2671.Amount = 300;
            Klijent.loadContains(sadrzaj2671);

            ContainsDetails sadrzaj2631 = new ContainsDetails();
            sadrzaj2631.RecipeID = 26;
            sadrzaj2631.Grocery = namirnica31;
            sadrzaj2631.Amount = 250;
            Klijent.loadContains(sadrzaj2631);

            RecipeDetails recept27 = new RecipeDetails();
            recept27.ID = 27;
            recept27.Name = "Zapečene palačinke";
            recept27.Description = "Na svaku palačinku staviti listove šunke i posuti rendanim kačkavaljem. Palačinke slagati u odgovarajući pleh koji smo podmazali. " +
                "Sjediniti jaja, neutralnu i kiselu pavlaku, posoliti i preliti preko palačinki. Peći u rerni zagrejanoj na 200 stepeni oko 30 minuta. ";
            Klijent.loadRecipe(recept27);

            GroceryDetails namirnica72 = new GroceryDetails();
            namirnica72.Name = "Palačinka";
            namirnica72.Unit = "Komad";
            namirnica72.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica72);

            GroceryDetails namirnica73 = new GroceryDetails();
            namirnica73.Name = "Šunka";
            namirnica73.Unit = "Gram";
            namirnica73.Category = "Meso";
            Klijent.loadGrocerie(namirnica73);

            GroceryDetails namirnica74 = new GroceryDetails();
            namirnica74.Name = "Neutralna pavlaka";
            namirnica74.Unit = "Mililitar";
            namirnica74.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica74);
            /*    10 kom palačinaka
    200 g kačkavalja
    400 g šunkarice
    180 ml kisele pavlake
    200 ml neutralne pavlake
    1 kašičica soli
    3 jajeta*/
            ContainsDetails sadrzaj2715 = new ContainsDetails();
            sadrzaj2715.RecipeID = 27;
            sadrzaj2715.Grocery = namirnica15;
            sadrzaj2715.Amount = 5;
            Klijent.loadContains(sadrzaj2715);

            ContainsDetails sadrzaj2774 = new ContainsDetails();
            sadrzaj2774.RecipeID = 27;
            sadrzaj2774.Grocery = namirnica74;
            sadrzaj2774.Amount = 200;
            Klijent.loadContains(sadrzaj2774);

            ContainsDetails sadrzaj2729 = new ContainsDetails();
            sadrzaj2729.RecipeID = 27;
            sadrzaj2729.Grocery = namirnica29;
            sadrzaj2729.Amount = 180;
            Klijent.loadContains(sadrzaj2729);

            ContainsDetails sadrzaj2772 = new ContainsDetails();
            sadrzaj2772.RecipeID = 27;
            sadrzaj2772.Grocery = namirnica72;
            sadrzaj2772.Amount = 10;
            Klijent.loadContains(sadrzaj2772);

            ContainsDetails sadrzaj2773 = new ContainsDetails();
            sadrzaj2773.RecipeID = 27;
            sadrzaj2773.Grocery = namirnica73;
            sadrzaj2773.Amount = 400;
            Klijent.loadContains(sadrzaj2773);

            ContainsDetails sadrzaj2738 = new ContainsDetails();
            sadrzaj2738.RecipeID = 27;
            sadrzaj2738.Grocery = namirnica38;
            sadrzaj2738.Amount = 200;
            Klijent.loadContains(sadrzaj2738);

            ContainsDetails sadrzaj2710 = new ContainsDetails();
            sadrzaj2710.RecipeID = 27;
            sadrzaj2710.Grocery = namirnica10;
            sadrzaj2710.Amount = 3;
            Klijent.loadContains(sadrzaj2710);

            RecipeDetails recept28 = new RecipeDetails();
            recept28.ID = 28;
            recept28.Name = "Punjeni šampinjoni";
            recept28.Description = "Šampinjone oprati i skinuti im drške. Šampinjone malo posoliti, a drške iseckati. U tiganj staviti dve kašike ulja pa propržiti iseckane drske šampinjona. " +
                "Kada omekšaju dodati iseckanu šunku i sve zajedno pržiti oko 3-4 minuta. Začiniti po ukusu. Ostaviti malo da se prohladi pa umešati pavlaku. " +
                "Napuniti udubljenja u šampinjonima pa staviti u zagrejanu rernu oko 20 minuta da se peče na 180 stepeni. Nakon 20 minuta izvaditi iz rerne, isključiti rernu. Izrenadti kačkavalj pa staviti po malo preko svakog šampinjona. " +
                "Vratiti u vruću rernu i ostaviti tamo dok se kačkavalj ne istopi.";
            Klijent.loadRecipe(recept28);


            /*
                 200 g većih šampinjona
    100 g šunkarice
    100 g kačkavalja
    po potrebi začini
    3 kašike pavlake
             */

            ContainsDetails sadrzaj2825 = new ContainsDetails();
            sadrzaj2825.RecipeID = 28;
            sadrzaj2825.Grocery = namirnica25;
            sadrzaj2825.Amount = 200;
            Klijent.loadContains(sadrzaj2825);

            ContainsDetails sadrzaj2873 = new ContainsDetails();
            sadrzaj2873.RecipeID = 28;
            sadrzaj2873.Grocery = namirnica73;
            sadrzaj2873.Amount = 100;
            Klijent.loadContains(sadrzaj2873);

            ContainsDetails sadrzaj2838 = new ContainsDetails();
            sadrzaj2838.RecipeID = 28;
            sadrzaj2838.Grocery = namirnica38;
            sadrzaj2838.Amount = 100;
            Klijent.loadContains(sadrzaj2838);

            ContainsDetails sadrzaj2874 = new ContainsDetails();
            sadrzaj2874.RecipeID = 28;
            sadrzaj2874.Grocery = namirnica74;
            sadrzaj2874.Amount = 50;
            Klijent.loadContains(sadrzaj2874);

            RecipeDetails recept29 = new RecipeDetails();
            recept29.ID = 29;
            recept29.Name = "Kafanska pogača";
            recept29.Description = "U sud sipati toplu vodu, dodati kvasac, ulje, šećer, so i dobro promešati. " +
                "Dodati odmah brašno pa umesiti mekano testo. " +
                "Prebaciti ga na radnu površinu, oblikujte jufku rukama pa dlanovima pritiskajte dok ne dobijete željenu debljinu pogače. " +
                "Trebalo bi da je tanka zato što u toku pečenja naraste. Prebaciti je na papir za pečenje, staviti u tepsiju i izbockati viljuškom. " +
                "Uključiti rernu na 250 stepeni, posle 15 minuta staviti pogaču da se peče. " +
                "Peći pogaću dok se ne zapeče, pa onda smanjiti temperaturu na 180 stepeni i dopecite je do kraja (ukupno pečenje oko 20 minuta). " +
                "Kad izvadite pogaču iz rerne poprskajte je sa malo vode, umotajte u pamučnu krpu i ostavite da se malo prohladi.";
            Klijent.loadRecipe(recept29);

            GroceryDetails namirnica75 = new GroceryDetails();
            namirnica75.Name = "Kvasac";
            namirnica75.Unit = "Komad";
            namirnica75.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica75);

            /*
                 1 kesica suvog kvasca
    1 kašičica šećera
    1 kašičica soli
    2 kašike ulja
    200 ml tople vode
    300 g brašna
             */
            ContainsDetails sadrzaj2922 = new ContainsDetails();
            sadrzaj2922.RecipeID = 29;
            sadrzaj2922.Grocery = namirnica22;
            sadrzaj2922.Amount = 300;
            Klijent.loadContains(sadrzaj2922);

            ContainsDetails sadrzaj2914 = new ContainsDetails();
            sadrzaj2914.RecipeID = 29;
            sadrzaj2914.Grocery = namirnica14;
            sadrzaj2914.Amount = 30;
            Klijent.loadContains(sadrzaj2914);

            ContainsDetails sadrzaj2915 = new ContainsDetails();
            sadrzaj2915.RecipeID = 29;
            sadrzaj2915.Grocery = namirnica15;
            sadrzaj2915.Amount = 5;
            Klijent.loadContains(sadrzaj2915);

            ContainsDetails sadrzaj2950 = new ContainsDetails();
            sadrzaj2950.RecipeID = 29;
            sadrzaj2950.Grocery = namirnica50;
            sadrzaj2950.Amount = 5;
            Klijent.loadContains(sadrzaj2950);

            ContainsDetails sadrzaj2975 = new ContainsDetails();
            sadrzaj2975.RecipeID = 29;
            sadrzaj2975.Grocery = namirnica75;
            sadrzaj2975.Amount = 1;
            Klijent.loadContains(sadrzaj2975);

            RecipeDetails recept30 = new RecipeDetails();
            recept30.ID = 30;
            recept30.Name = "Pasulj sa suvim rebrima";
            recept30.Description = "Pasulji, potopi uveče i ostaviti da nabubri da bi se brže skuvao, a kuvati sutradan. " +
                "Prosipati vodu u kojoj je bio potopljen naliti drugom vodom staviti da se kuva, pa kad provri, prosipati prvu vodu i naliti pasulj drugom, vrelom vodom. " +
                "Dodati isečen crni, beli luk, i rebra pa kuvati na tihoj vatri dok zrna pasulja budu mekana. " +
                "Posoliti i začiniti po ukusu. U tiganj staviti kašiku masti ili ulja, zagrejati, dodati još 1-2 kašike brašna i napraviti zapršku. " +
                "Kad zaprška postane rumena, dodati alevu papriku sve dobro promešati i sipati u pasulj i ostaviti da krčka još 5 minuta.";
            Klijent.loadRecipe(recept30);

            GroceryDetails namirnica76 = new GroceryDetails();
            namirnica76.Name = "Suva rebra";
            namirnica76.Unit = "Gram";
            namirnica76.Category = "Meso";
            Klijent.loadGrocerie(namirnica76);
            /*
                 400 g pasulja
    1 čen belog luka
    1 glavica crnog luka
    po ukusu so
    po ukusu suvi biljni začina
    po ukusu suva rebra

                2 kašike brašna
    1 kašika masti ili ulja
    1/2 kašičice aleve paprike slatke ili ljute 
             */
            ContainsDetails sadrzaj3034 = new ContainsDetails();
            sadrzaj3034.RecipeID = 30;
            sadrzaj3034.Grocery = namirnica34;
            sadrzaj3034.Amount = 5;
            Klijent.loadContains(sadrzaj3034);

            ContainsDetails sadrzaj3022 = new ContainsDetails();
            sadrzaj3022.RecipeID = 30;
            sadrzaj3022.Grocery = namirnica22;
            sadrzaj3022.Amount = 30;
            Klijent.loadContains(sadrzaj3022);

            ContainsDetails sadrzaj3070 = new ContainsDetails();
            sadrzaj3070.RecipeID = 30;
            sadrzaj3070.Grocery = namirnica70;
            sadrzaj3070.Amount = 15;
            Klijent.loadContains(sadrzaj3070);

            ContainsDetails sadrzaj3076 = new ContainsDetails();
            sadrzaj3076.RecipeID = 30;
            sadrzaj3076.Grocery = namirnica76;
            sadrzaj3076.Amount = 400;
            Klijent.loadContains(sadrzaj3076);

            ContainsDetails sadrzaj3026 = new ContainsDetails();
            sadrzaj3026.RecipeID = 30;
            sadrzaj3026.Grocery = namirnica26;
            sadrzaj3026.Amount = 1;
            Klijent.loadContains(sadrzaj3026);

            ContainsDetails sadrzaj3027 = new ContainsDetails();
            sadrzaj3027.RecipeID = 30;
            sadrzaj3027.Grocery = namirnica27;
            sadrzaj3027.Amount = 1;
            Klijent.loadContains(sadrzaj3027);

            ContainsDetails sadrzaj3068 = new ContainsDetails();
            sadrzaj3068.RecipeID = 30;
            sadrzaj3068.Grocery = namirnica68;
            sadrzaj3068.Amount = 400;
            Klijent.loadContains(sadrzaj3068);

            RecipeDetails recept31 = new RecipeDetails();
            recept31.ID = 31;
            recept31.Name = "Salata sa cveklom";
            recept31.Description = "Cveklu obariti sa malo soli. Ohladiti. Belo meso skuvati sa malo soli i ohladiti. " +
                "Hladno belo meso iseći na sitne kockice, a cveklu izrendati i spojiti sa mesom. Dodati majonez, pavlaku, seckanu šunku i rendan kačkavalj. " +
                "Sve sjediniti kašikom i dobro rashladiti.";
            Klijent.loadRecipe(recept31);

            GroceryDetails namirnica77 = new GroceryDetails();
            namirnica77.Name = "Cvekla";
            namirnica77.Unit = "Gram";
            namirnica77.Category = "Povrće";
            Klijent.loadGrocerie(namirnica77);
            /*
                 200 g cvekle
    400 g belog mesa
    200 g majoneza
    200 g šunkarice
    300 g pavlake
    200 g kačkavalja
             */
            ContainsDetails sadrzaj3173 = new ContainsDetails();
            sadrzaj3173.RecipeID = 31;
            sadrzaj3173.Grocery = namirnica73;
            sadrzaj3173.Amount = 200;
            Klijent.loadContains(sadrzaj3173);

            ContainsDetails sadrzaj3138 = new ContainsDetails();
            sadrzaj3138.RecipeID = 31;
            sadrzaj3138.Grocery = namirnica38;
            sadrzaj3138.Amount = 200;
            Klijent.loadContains(sadrzaj3138);

            ContainsDetails sadrzaj3129 = new ContainsDetails();
            sadrzaj3129.RecipeID = 31;
            sadrzaj3129.Grocery = namirnica29;
            sadrzaj3129.Amount = 300;
            Klijent.loadContains(sadrzaj3129);

            ContainsDetails sadrzaj3162 = new ContainsDetails();
            sadrzaj3162.RecipeID = 31;
            sadrzaj3162.Grocery = namirnica62;
            sadrzaj3162.Amount = 200;
            Klijent.loadContains(sadrzaj3162);

            ContainsDetails sadrzaj3124 = new ContainsDetails();
            sadrzaj3124.RecipeID = 31;
            sadrzaj3124.Grocery = namirnica24;
            sadrzaj3124.Amount = 400;
            Klijent.loadContains(sadrzaj3124);

            ContainsDetails sadrzaj3177 = new ContainsDetails();
            sadrzaj3177.RecipeID = 31;
            sadrzaj3177.Grocery = namirnica77;
            sadrzaj3177.Amount = 200;
            Klijent.loadContains(sadrzaj3177);

            RecipeDetails recept32 = new RecipeDetails();
            recept32.ID = 32;
            recept32.Name = "Pileća salata";
            recept32.Description = "Meso obariti i kada se ohladi iseći ga u secku. Susam propržiti u tiganju a kikiriki iseckati. " +
                "Sjediniti meso, susam i kikiriki pa dodati pavlaku i sir, po zelji posoliti i sve dobro izmešati da se sastojci povežu. " +
                "Smesu sipati u činiju i po želji ukrasiti sa malo mlevenog kikirikija.";
            Klijent.loadRecipe(recept32);

            GroceryDetails namirnica78 = new GroceryDetails();
            namirnica78.Name = "Susam";
            namirnica78.Unit = "Gram";
            namirnica78.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica78);

            GroceryDetails namirnica79 = new GroceryDetails();
            namirnica79.Name = "Kikiriki";
            namirnica79.Unit = "Gram";
            namirnica79.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica79);

            /*
                 500 g pilećeg belog mesa
    100 g susama
    100 g pečenog kikirikija
    300 g kisele pavlake
    150 g sitnog sira
             */
            ContainsDetails sadrzaj3279 = new ContainsDetails();
            sadrzaj3279.RecipeID = 32;
            sadrzaj3279.Grocery = namirnica79;
            sadrzaj3279.Amount = 100;
            Klijent.loadContains(sadrzaj3279);

            ContainsDetails sadrzaj3278 = new ContainsDetails();
            sadrzaj3278.RecipeID = 32;
            sadrzaj3278.Grocery = namirnica78;
            sadrzaj3278.Amount = 100;
            Klijent.loadContains(sadrzaj3278);

            ContainsDetails sadrzaj3229 = new ContainsDetails();
            sadrzaj3229.RecipeID = 32;
            sadrzaj3229.Grocery = namirnica29;
            sadrzaj3229.Amount = 300;
            Klijent.loadContains(sadrzaj3229);

            ContainsDetails sadrzaj3216 = new ContainsDetails();
            sadrzaj3216.RecipeID = 32;
            sadrzaj3216.Grocery = namirnica16;
            sadrzaj3216.Amount = 150;
            Klijent.loadContains(sadrzaj3216);

            ContainsDetails sadrzaj3224 = new ContainsDetails();
            sadrzaj3224.RecipeID = 32;
            sadrzaj3224.Grocery = namirnica24;
            sadrzaj3224.Amount = 500;
            Klijent.loadContains(sadrzaj3224);

            RecipeDetails recept33 = new RecipeDetails();
            recept33.ID = 33;
            recept33.Name = "Pogačice sa kozijim sirom";
            recept33.Description = "U mleko udrobimo kvasac, izmešamo, posolimo. Stavimo sir i mast i postepeno dodavajući brašno umesimo testo. " +
                "Ostavimo da miruje oko sat vremena, stavimo na radnu površinu koje smo pobrasnjavili, premesimo razvučemo oklagijom na debljinu oko 1cm i vadimo modlom pogačice. " +
                "Ređamo u tepsiju obložen pek papirom, premažemo razmućenim jajetom i pospemo semenjem lana ili već po svom izboru. " +
                "Pečemo na 180C oko 20 minuta.";
            Klijent.loadRecipe(recept33);

            GroceryDetails namirnica80 = new GroceryDetails();
            namirnica80.Name = "Koziji sir";
            namirnica80.Unit = "Gram";
            namirnica80.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica80);

            /*
             *     500 g kozijeg sitnog sira
    350 g masti
    1 kockica kvasca
    3 kašičice soli
    1,5 dl mleka
    1 kg brašna
    1 jaja
    malo lanenog semena za posipanje
             */
            ContainsDetails sadrzaj3310 = new ContainsDetails();
            sadrzaj3310.RecipeID = 33;
            sadrzaj3310.Grocery = namirnica10;
            sadrzaj3310.Amount = 1;
            Klijent.loadContains(sadrzaj3310);

            ContainsDetails sadrzaj3322 = new ContainsDetails();
            sadrzaj3322.RecipeID = 33;
            sadrzaj3322.Grocery = namirnica22;
            sadrzaj3322.Amount = 1000;
            Klijent.loadContains(sadrzaj3322);

            ContainsDetails sadrzaj3339 = new ContainsDetails();
            sadrzaj3339.RecipeID = 33;
            sadrzaj3339.Grocery = namirnica39;
            sadrzaj3339.Amount = 150;
            Klijent.loadContains(sadrzaj3339);

            ContainsDetails sadrzaj3315 = new ContainsDetails();
            sadrzaj3315.RecipeID = 33;
            sadrzaj3315.Grocery = namirnica15;
            sadrzaj3315.Amount = 15;
            Klijent.loadContains(sadrzaj3315);

            ContainsDetails sadrzaj3375 = new ContainsDetails();
            sadrzaj3375.RecipeID = 33;
            sadrzaj3375.Grocery = namirnica75;
            sadrzaj3375.Amount = 1;
            Klijent.loadContains(sadrzaj3375);

            ContainsDetails sadrzaj3370 = new ContainsDetails();
            sadrzaj3370.RecipeID = 33;
            sadrzaj3370.Grocery = namirnica70;
            sadrzaj3370.Amount = 350;
            Klijent.loadContains(sadrzaj3370);

            ContainsDetails sadrzaj3380 = new ContainsDetails();
            sadrzaj3380.RecipeID = 33;
            sadrzaj3380.Grocery = namirnica80;
            sadrzaj3380.Amount = 500;
            Klijent.loadContains(sadrzaj3380);

            RecipeDetails recept34 = new RecipeDetails();
            recept34.ID = 34;
            recept34.Name = "Salata sa pirinčem";
            recept34.Description = "Šunku i kisele krastavce isecite na sitne kocke i dodajte ih u sud sa prethodno skuvanim pirinčem. " +
                "U sud krupno narendajte dva kuvana jajeta, dodajte majonez i kiselu pavlaku. Posolite, pobiberite i promešajte salatu. " +
                "Preostalo jaje isecite na deblje krugove. Na tanjih za serviranje servirajte salatu u formi tri kupa, na svaki kup salate stavite po jedan krug jajeta. " +
                "Dekorišite po želji.";
            Klijent.loadRecipe(recept34);

            GroceryDetails namirnica81 = new GroceryDetails();
            namirnica81.Name = "Kiseli krastavci";
            namirnica81.Unit = "Gram";
            namirnica81.Category = "Povrće";
            Klijent.loadGrocerie(namirnica81);
            /*
                 200 g kuvanog pirinča
    200 g šunke
    200 g kiselih krastavaca
    3 kuvana oljuštena jajeta
    200 g majoneza
    200 g kisele pavlake
    po ukusu so
    po ukusu mleveni crni biber*/
            ContainsDetails sadrzaj3429 = new ContainsDetails();
            sadrzaj3429.RecipeID = 34;
            sadrzaj3429.Grocery = namirnica29;
            sadrzaj3429.Amount = 200;
            Klijent.loadContains(sadrzaj3429);

            ContainsDetails sadrzaj3462 = new ContainsDetails();
            sadrzaj3462.RecipeID = 34;
            sadrzaj3462.Grocery = namirnica62;
            sadrzaj3462.Amount = 200;
            Klijent.loadContains(sadrzaj3462);

            ContainsDetails sadrzaj3410 = new ContainsDetails();
            sadrzaj3410.RecipeID = 34;
            sadrzaj3410.Grocery = namirnica10;
            sadrzaj3410.Amount = 3;
            Klijent.loadContains(sadrzaj3410);

            ContainsDetails sadrzaj3481 = new ContainsDetails();
            sadrzaj3481.RecipeID = 34;
            sadrzaj3481.Grocery = namirnica81;
            sadrzaj3481.Amount = 200;
            Klijent.loadContains(sadrzaj3481);

            ContainsDetails sadrzaj3473 = new ContainsDetails();
            sadrzaj3473.RecipeID = 34;
            sadrzaj3473.Grocery = namirnica73;
            sadrzaj3473.Amount = 200;
            Klijent.loadContains(sadrzaj3473);

            ContainsDetails sadrzaj3431 = new ContainsDetails();
            sadrzaj3431.RecipeID = 34;
            sadrzaj3431.Grocery = namirnica31;
            sadrzaj3431.Amount = 200;
            Klijent.loadContains(sadrzaj3431);

            RecipeDetails recept35 = new RecipeDetails();
            recept35.ID = 35;
            recept35.Name = "Piletina sa pečurkama";
            recept35.Description = "Na zagrejanom ulju propržiti sitno seckan crni luk, zatim dodati meso pa dinstati dolivajući vodu po potrebi. " +
                "Kad je meso gotovo dodati začine po ukusu i kiselu pavlaku. Šampinjone očistiti, napuniti kačkavaljem i peći u rerni 15 - ak minuta. " +
                "Piletinu posuti rendanim kačkavaljem i poslužiti sa pečurkama.";
            Klijent.loadRecipe(recept35);

            /*
             *     400 g pilećeg belog mesa
    1 glavica crnog luka
    1 čaša kisele pavlake
    200 g šampinjona
    200 g kačkavalja
    po ukusu soli
    po ukusu bibera
    po potrebi ulja
             */
            ContainsDetails sadrzaj3538 = new ContainsDetails();
            sadrzaj3538.RecipeID = 35;
            sadrzaj3538.Grocery = namirnica38;
            sadrzaj3538.Amount = 200;
            Klijent.loadContains(sadrzaj3538);

            ContainsDetails sadrzaj3525 = new ContainsDetails();
            sadrzaj3525.RecipeID = 35;
            sadrzaj3525.Grocery = namirnica25;
            sadrzaj3525.Amount = 200;
            Klijent.loadContains(sadrzaj3525);

            ContainsDetails sadrzaj3529 = new ContainsDetails();
            sadrzaj3529.RecipeID = 35;
            sadrzaj3529.Grocery = namirnica29;
            sadrzaj3529.Amount = 200;
            Klijent.loadContains(sadrzaj3529);

            ContainsDetails sadrzaj3526 = new ContainsDetails();
            sadrzaj3526.RecipeID = 35;
            sadrzaj3526.Grocery = namirnica26;
            sadrzaj3526.Amount = 1;
            Klijent.loadContains(sadrzaj3526);

            ContainsDetails sadrzaj3524 = new ContainsDetails();
            sadrzaj3524.RecipeID = 35;
            sadrzaj3524.Grocery = namirnica24;
            sadrzaj3524.Amount = 400;
            Klijent.loadContains(sadrzaj3524);

            RecipeDetails recept36 = new RecipeDetails();
            recept36.ID = 36;
            recept36.Name = "Salata od tikvica ";
            recept36.Description = "Tikvice oprati, oljuštiti, iseći na kocke i obariti u posoljenoj vodi. " +
                "Obarene tikvice procediti i ostaviti ih u cediljki kako bi se ocedio višak vode. " +
                "Beli luk sitno iseckati, pa ga dodati prohlađenim i oceđenim tikvicama. " +
                "Posoliti po ukusu, dodati ulje i sirće, dobro promešati da staviti u frižider da se ohladi pre služenja.";
            Klijent.loadRecipe(recept36);
            /*
             *     2 mlade tikvice
    1 glavica belog luka
    po potrebi ulja
    po ukusu soli
    po ukusu sirćeta
             *
             */
            ContainsDetails sadrzaj3614 = new ContainsDetails();
            sadrzaj3614.RecipeID = 36;
            sadrzaj3614.Grocery = namirnica14;
            sadrzaj3614.Amount = 5;
            Klijent.loadContains(sadrzaj3614);

            ContainsDetails sadrzaj3649 = new ContainsDetails();
            sadrzaj3649.RecipeID = 36;
            sadrzaj3649.Grocery = namirnica49;
            sadrzaj3649.Amount = 10;
            Klijent.loadContains(sadrzaj3649);

            ContainsDetails sadrzaj3627 = new ContainsDetails();
            sadrzaj3627.RecipeID = 36;
            sadrzaj3627.Grocery = namirnica27;
            sadrzaj3627.Amount = 1;
            Klijent.loadContains(sadrzaj3627);

            ContainsDetails sadrzaj3623 = new ContainsDetails();
            sadrzaj3623.RecipeID = 36;
            sadrzaj3623.Grocery = namirnica23;
            sadrzaj3623.Amount = 400;
            Klijent.loadContains(sadrzaj3623);

            RecipeDetails recept37 = new RecipeDetails();
            recept37.ID = 37;
            recept37.Name = "Milka torta";
            recept37.Description = "I fil: Umutiti 300 g šlaga u prahu sa 2 dl hladne kisele vode. Dodati jednu pavlaku i 300 g keksa sve sjediniti. " +
                "Na tepsiju ili pleh nanijeti fil. Fil II: Čvrsto umutiti 300 g šlaga u prahu sa 2 dl kisele vode, polako mešajući varjačom dodati pavlaku i 300 g rendane čokolade. " +
                "Drugom smesom premazati prvu smesu. Umutiti preosatali šlag sa kiselom vodom i premazati cijelu tortu";
            Klijent.loadRecipe(recept37);

            GroceryDetails namirnica86 = new GroceryDetails();
            namirnica86.Name = "Mleveni keks";
            namirnica86.Unit = "Gram";
            namirnica86.Category = "Dodatak";
            Klijent.loadGrocerie(namirnica86);
            /*
             *     800 g šlaga
    300 g mljevenog keksa
    300 g milka čokolade sa jagodama
    2 čaše pavlake
    5 dl kisele vode
    Glazura:
    150 g čokolade
    malo vode
    malo ulja
             */
            ContainsDetails sadrzaj3756 = new ContainsDetails();
            sadrzaj3756.RecipeID = 37;
            sadrzaj3756.Grocery = namirnica56;
            sadrzaj3756.Amount = 500;
            Klijent.loadContains(sadrzaj3756);

            ContainsDetails sadrzaj3774 = new ContainsDetails();
            sadrzaj3774.RecipeID = 37;
            sadrzaj3774.Grocery = namirnica74;
            sadrzaj3774.Amount = 400;
            Klijent.loadContains(sadrzaj3774);

            ContainsDetails sadrzaj3758 = new ContainsDetails();
            sadrzaj3758.RecipeID = 37;
            sadrzaj3758.Grocery = namirnica58;
            sadrzaj3758.Amount = 450;
            Klijent.loadContains(sadrzaj3758);

            ContainsDetails sadrzaj3786 = new ContainsDetails();
            sadrzaj3786.RecipeID = 37;
            sadrzaj3786.Grocery = namirnica86;
            sadrzaj3786.Amount = 300;
            Klijent.loadContains(sadrzaj3786);

            ContainsDetails sadrzaj3753 = new ContainsDetails();
            sadrzaj3753.RecipeID = 37;
            sadrzaj3753.Grocery = namirnica53;
            sadrzaj3753.Amount = 800;
            Klijent.loadContains(sadrzaj3753);

            RecipeDetails recept38 = new RecipeDetails();
            recept38.ID = 38;
            recept38.Name = "Srpski suši";
            recept38.Description = "Prvo pomešati krem sir i kajmak. Dodati soli po ukusu. " +
                "Na papir za pečenje ređajte pršutu, ali tako da se preklapa. Tako ćete lakše moći da uvijete u rolat. " +
                "Iseckajte na tanke trakice krastavac sa korom, kačkavalj i papriku. Pršutu premažite već pripremljenom smesom od krem sira i kajmaka, " +
                "a onda po širini redjajte trakice kačkavalja, paprike i krastavca. Na sve to dodajte čvarke, ali ne previše. " +
                "Urolajte pršutu uz pomoć papira za pečenje i ostavite u frižideru na 3 sata.";
            Klijent.loadRecipe(recept38);

            GroceryDetails namirnica82 = new GroceryDetails();
            namirnica82.Name = "Pršuta";
            namirnica82.Unit = "Gram";
            namirnica82.Category = "Meso";
            Klijent.loadGrocerie(namirnica82);

            GroceryDetails namirnica83 = new GroceryDetails();
            namirnica83.Name = "Krastavac";
            namirnica83.Unit = "Komad";
            namirnica83.Category = "Povrće";
            Klijent.loadGrocerie(namirnica83);

            GroceryDetails namirnica84 = new GroceryDetails();
            namirnica84.Name = "Duvan čvarci";
            namirnica84.Unit = "Gram";
            namirnica84.Category = "Meso";
            Klijent.loadGrocerie(namirnica84);
            /*
             *     200 g njeguške pršute
    250 g krem sira
    150 g kajmaka
    100 g dimljeni kačkavalj
    1 krastavac sa koricom
    1 crvena paprika
    50 g duvan čvaraka
             */
            ContainsDetails sadrzaj3882 = new ContainsDetails();
            sadrzaj3882.RecipeID = 38;
            sadrzaj3882.Grocery = namirnica82;
            sadrzaj3882.Amount = 200;
            Klijent.loadContains(sadrzaj3882);

            ContainsDetails sadrzaj3884 = new ContainsDetails();
            sadrzaj3884.RecipeID = 38;
            sadrzaj3884.Grocery = namirnica84;
            sadrzaj3884.Amount = 50;
            Klijent.loadContains(sadrzaj3884);

            ContainsDetails sadrzaj3883 = new ContainsDetails();
            sadrzaj3883.RecipeID = 38;
            sadrzaj3883.Grocery = namirnica83;
            sadrzaj3883.Amount = 1;
            Klijent.loadContains(sadrzaj3883);

            ContainsDetails sadrzaj3819 = new ContainsDetails();
            sadrzaj3819.RecipeID = 38;
            sadrzaj3819.Grocery = namirnica19;
            sadrzaj3819.Amount = 1;
            Klijent.loadContains(sadrzaj3819);

            ContainsDetails sadrzaj3838 = new ContainsDetails();
            sadrzaj3838.RecipeID = 38;
            sadrzaj3838.Grocery = namirnica38;
            sadrzaj3838.Amount = 100;
            Klijent.loadContains(sadrzaj3838);

            ContainsDetails sadrzaj3807 = new ContainsDetails();
            sadrzaj3807.RecipeID = 38;
            sadrzaj3807.Grocery = namirnica7;
            sadrzaj3807.Amount = 150;
            Klijent.loadContains(sadrzaj3807);

            ContainsDetails sadrzaj3808 = new ContainsDetails();
            sadrzaj3808.RecipeID = 38;
            sadrzaj3808.Grocery = namirnica8;
            sadrzaj3808.Amount = 250;
            Klijent.loadContains(sadrzaj3808);



            RecipeDetails recept39 = new RecipeDetails();
            recept39.ID = 39;
            recept39.Name = "Punjeni krompir ";
            recept39.Description = "Krompir u ljusci kuvati 20 minuta, da ne bude kuvan skroz. Polukuvan krompir iseći uzduž i pažljivo kašičicom izdubiti svaku polovinu. " +
                "Ređati na pleh obložen papirom za pečenje. Fil za punjenje: U tanjiru umutiti maslac i krem sir, zatim dodati ostatak krompira, slaninu i začin. " +
                "Sve dobro izmešati i napuniti izdubljen krompir. Peći na 200 C 20 minuta.";
            Klijent.loadRecipe(recept39);

            GroceryDetails namirnica85 = new GroceryDetails();
            namirnica85.Name = "Maslac";
            namirnica85.Unit = "Gram";
            namirnica85.Category = "Mlečni_proizvod";
            Klijent.loadGrocerie(namirnica85);
            /*
                 6 krompira srednje veličine
    1 kašika sirnog namaza
    20 g maslaca
    50-100 g slanine
    1 kašika suvog biljnog začina
             */
            ContainsDetails sadrzaj3920 = new ContainsDetails();
            sadrzaj3920.RecipeID = 39;
            sadrzaj3920.Grocery = namirnica20;
            sadrzaj3920.Amount = 15;
            Klijent.loadContains(sadrzaj3920);

            ContainsDetails sadrzaj3941 = new ContainsDetails();
            sadrzaj3941.RecipeID = 39;
            sadrzaj3941.Grocery = namirnica41;
            sadrzaj3941.Amount = 20;
            Klijent.loadContains(sadrzaj3941);

            ContainsDetails sadrzaj3985 = new ContainsDetails();
            sadrzaj3985.RecipeID = 39;
            sadrzaj3985.Grocery = namirnica85;
            sadrzaj3985.Amount = 20;
            Klijent.loadContains(sadrzaj3985);

            ContainsDetails sadrzaj3908 = new ContainsDetails();
            sadrzaj3908.RecipeID = 39;
            sadrzaj3908.Grocery = namirnica8;
            sadrzaj3908.Amount = 15;
            Klijent.loadContains(sadrzaj3908);

            ContainsDetails sadrzaj3936 = new ContainsDetails();
            sadrzaj3936.RecipeID = 39;
            sadrzaj3936.Grocery = namirnica36;
            sadrzaj3936.Amount = 600;
            Klijent.loadContains(sadrzaj3936);

            RecipeDetails recept40 = new RecipeDetails();
            recept40.ID = 40;
            recept40.Name = "Pita sa sirom";
            recept40.Description = "Sir izmrviti, pa mu dodati jaja, jogurt, pecivo i so. Sve lepo sjediniti. " +
                "Svaku koru prvo nauljiti, pa filovati sa 2 kašike fila, pa prekalupiti obe strane ka sredini. " +
                "Sipati još 1 kašiku fila, razmazati, pa prekalupiti na pola. Uviti kao kiflicu. U nauljen pleh slagati uvijene kore i premazati ih sa ostatkom fila. " +
                "Peći u zagrejanoj rerni na 250 stepeni, dok lepo ne porumene.";
            Klijent.loadRecipe(recept40);

            /*
                 500 g sira
    4 jajeta
    400 ml jogurta
    1 kesica praška za pecivo
    500 g kora za pitu
    ulje
    so
             */
            ContainsDetails sadrzaj4014 = new ContainsDetails();
            sadrzaj4014.RecipeID = 40;
            sadrzaj4014.Grocery = namirnica14;
            sadrzaj4014.Amount = 100;
            Klijent.loadContains(sadrzaj4014);

            ContainsDetails sadrzaj4015 = new ContainsDetails();
            sadrzaj4015.RecipeID = 40;
            sadrzaj4015.Grocery = namirnica15;
            sadrzaj4015.Amount = 5;
            Klijent.loadContains(sadrzaj4015);

            ContainsDetails sadrzaj4011 = new ContainsDetails();
            sadrzaj4011.RecipeID = 40;
            sadrzaj4011.Grocery = namirnica11;
            sadrzaj4011.Amount = 1;
            Klijent.loadContains(sadrzaj4011);

            ContainsDetails sadrzaj4006 = new ContainsDetails();
            sadrzaj4006.RecipeID = 40;
            sadrzaj4006.Grocery = namirnica6;
            sadrzaj4006.Amount = 500;
            Klijent.loadContains(sadrzaj4006);

            ContainsDetails sadrzaj4009 = new ContainsDetails();
            sadrzaj4009.RecipeID = 40;
            sadrzaj4009.Grocery = namirnica9;
            sadrzaj4009.Amount = 400;
            Klijent.loadContains(sadrzaj4009);

            ContainsDetails sadrzaj4010 = new ContainsDetails();
            sadrzaj4010.RecipeID = 40;
            sadrzaj4010.Grocery = namirnica10;
            sadrzaj4010.Amount = 4;
            Klijent.loadContains(sadrzaj4010);

            ContainsDetails sadrzaj4016 = new ContainsDetails();
            sadrzaj4016.RecipeID = 40;
            sadrzaj4016.Grocery = namirnica16;
            sadrzaj4016.Amount = 500;
            Klijent.loadContains(sadrzaj4016);

            System.IO.FileStream fs;
            byte[] imageBytes;

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/1.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 1);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/2.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 2);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/3.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 3);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/4.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 4);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/5.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 5);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/6.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 6);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/7.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 7);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/8.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 8);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/9.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 9);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/10.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 10);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/11.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 11);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/12.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 12);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/13.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 13);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/14.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 14);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/15.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 15);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/16.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 16);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/17.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 17);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/18.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 18);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/19.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 19);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/20.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 20);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/21.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 21);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/22.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 22);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/23.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 23);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/24.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 24);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/25.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 25);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/26.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 26);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/27.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 27);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/28.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 28);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/29.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 29);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/30.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 30);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/31.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 31);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/32.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 32);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/33.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 33);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/34.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 34);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/35.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 35);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/36.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 36);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/37.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 37);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/38.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 38);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/39.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 39);

            fs = new FileStream("C:/Users/user/Downloads/recepti slike/40.jpg", FileMode.Open, FileAccess.ReadWrite);
            imageBytes = new byte[fs.Length];
            fs.Read(imageBytes, 0, Convert.ToInt32(fs.Length));
            fs.Dispose();
            Klijent.dbInsertImageRecipe(imageBytes, 40);
        }
    }
}