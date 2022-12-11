using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
namespace GreenFlamingos.Model.Drinks
{
    public class NoAlcoDrink : Drink
    {
        public NoAlcoDrink() 
        {
            DrinkType = "Drink bezalkoholowy";
        }
        public NoAlcoDrink(string name, User owner, string mainIgredient, int capacity, int calories, List<string> ingriedients, string description, List<string> preparation, string imageUrl)
        {
            DrinkType = "Drink bezalkoholowy";
            Name = name;
            Owner = owner;
            MainIngredient = mainIgredient;
            Capacity = capacity;
            AlcoholContent = 0;
            Calories = calories;
            Ingredients = ingriedients;
            Description = description;
            Preparation = preparation;
            ImageUrl = imageUrl;
        }
    }
}
