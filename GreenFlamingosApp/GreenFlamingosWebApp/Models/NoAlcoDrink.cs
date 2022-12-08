﻿using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;

namespace GreenFlamingosWebApp.Models
{
    public class NoAlcoDrink : Drink
    {
        public NoAlcoDrink() 
        {
            DrinkType = "Drink bezalkoholowy";
        }
        public NoAlcoDrink(string name, User owner, string mainIgredient, int capacity, int alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparation, string imageUrl)
        {
            DrinkType = "Drink bezalkoholowy";
            Name = name;
            Owner = owner;
            MainIngredient = mainIgredient;
            Capacity = capacity;
            AlcoholContent = alcoholContent;
            Calories = calories;
            Ingredients = ingriedients;
            Description = description;
            Preparation = preparation;
            ImageUrl = imageUrl;
        }
    }
}