﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public List<DbDrink> Drinks { get; set; }
        public List<DbDrinkIngredient> DrinkIngredients { get; set; }


    }
}