using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;

namespace GreenFlamingosWebApp.Models
{
    public class AlcoDrink : Drink
    {
        public AlcoDrink()
        {
            DrinkType = "Drink";
        }
        public AlcoDrink(string name, User owner, string mainIgredient, int capacity, float alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparation, string imageUrl)
        {

            DrinkType = "Drink";
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
