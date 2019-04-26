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
    class Group
    {
        public int Id { get; set; }
        public AvailableGroceries AvailableGroceries { get; set; }
        public List<string> MyGroupMembers { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Group()
        {
            Recipes= new List<Recipe>();
            MyGroupMembers= new List<string>();
        }

        public Group(int id, AvailableGroceries availableGroceries, List<string> myGroupMembers, ShoppingCart shoppingCart, List<Recipe> recipes)
        {
            Id = id;
            AvailableGroceries = availableGroceries;
            MyGroupMembers = myGroupMembers;
            ShoppingCart = shoppingCart;
            Recipes = recipes;
        }
    }
}