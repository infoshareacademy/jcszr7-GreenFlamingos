using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model.Drinks
{
    public class Shot : Drink
    {
        public Shot()
        {
            DrinkType = "Shot";
        }
        public Shot(string name, User owner, string mainIgredient, int capacity, double alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparation)
        {
            Random rnd = new Random();
            DrinkID = rnd.Next(600000, 999999);
            //Here is needed a condition to check if created number is already used by other NoAlcoDrink

            DrinkType = "Shot";
            Name = name;
            Owner = owner;
            MainIngredient = mainIgredient;

            if (capacity < 25 || capacity > 100)
                throw new ArgumentOutOfRangeException();
            else
                Capacity = capacity;
            AlcoholContent = alcoholContent;
            Calories = calories;
            Ingredients = ingriedients;
            Description = description;
            Preparation = preparation;
        }
    }
}
