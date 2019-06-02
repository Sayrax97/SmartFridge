using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartFridge.WebReference;

namespace SmartFridge.Model
{
    public enum Unit
    {
        Komad,
        Kilogram,
        Gram,
        Litar,
        Mililitar,
        Nema,

    }

    public enum Category
    {
        None,
        Riba,
        Povrce,
        Pica,
        Zacin,
        Žitarice,
        Mlecni_proizvod,
        Životinjski_proizvod,
        Dodatak,
        Ulja,
        Bilje,
        Pecurke,
        Meso
    }

    public class Grocery
    {
        public string Name { get; set; }
        public Unit MeasurementUnit { get; set; }
        public Category Type { get; set; }
        public double Amount { get; set; }
        public double Bought { get; set; }
        public byte[] Image { get; set; }
        public bool Checked { get; set; }
        public bool IsInList { get; set; }
        public bool IsCategorized { get; set; }

        public static List<string> Categories =Enum.GetNames(typeof(Category)).ToList();

        public Grocery()
        {
        }

        public Grocery(string name, Unit measurementUnit, Category type, double amount)
        {
            Name = name;
            MeasurementUnit = measurementUnit;
            Type = type;
            Amount = amount;
            Bought = 0;
            Checked = false;
            IsInList = false;
            IsCategorized = false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Grocery grocery && Name == grocery.Name)
                    return true;
            return false;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        
        public void Default()
        {
            IsInList = true;
            IsCategorized = true;
        }

        public GroceryDetails GetGroceryDetails()
        {
            return new GroceryDetails()
            {
                Name = Name,
                Category = Type.ToString(),
                Unit = MeasurementUnit.ToString(),
                Image = null
            };
        }
    }
}