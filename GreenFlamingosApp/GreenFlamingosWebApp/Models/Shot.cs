using GreenFlamingos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosWebApp.Models
{
    public class Shot : Drink
    {
        public Shot()
        {
            DrinkType = "Shot";
        }
        public Shot(string name, User owner, string mainIgredient, int capacity, int alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparation, string imageUrl)
        {
            DrinkType = "Shot";
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
