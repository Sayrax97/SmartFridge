﻿using System;
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
    class Grocery
    {
        public string Name { get; set; }
        public string MeasurementUnit { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Image { get; set; }

        public Grocery(string name, string measurementUnit, string type, double amount)
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
    }
}