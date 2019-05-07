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
    public enum Unit
    {
        Komad,
        Kilogram,
        Gram,
        Litar,
        Mililitar,

    }

    public enum Category
    {
        Food_additives‎,
        Cereals,
        Condiments,
        Cooking_oils,
        Flour,
        Herbs,
        Fruits,
        Sauces,
        Milky,
        Animal_product,
        Drink,
        Vegtables,
    }

    public class Grocery
    {
        public string Name { get; set; }
        public Unit MeasurementUnit { get; set; }
        public Category Type { get; set; }
        public double Amount { get; set; }
        public string Image { get; set; }

        public Grocery(string name, Unit measurementUnit, Category type, double amount)
        {
            Name = name;
            MeasurementUnit = measurementUnit;
            Type = type;
            Amount = amount;
        }

        public override bool Equals(object obj)
        {
            var grocery = obj as Grocery;
            if (Name == grocery.Name && Type == grocery.Type && MeasurementUnit == grocery.MeasurementUnit)
                return true;
            return false;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}