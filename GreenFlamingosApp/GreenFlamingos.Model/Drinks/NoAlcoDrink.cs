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
        public NoAlcoDrink(string name, User owner, string mainIgredient, int capacity, int calories, List<string> ingriedients, string description, List<string> preparations, string imageUrl)
        {
            DrinkType = "Drink bezalkoholowy";
            Name = name;
            Owner = owner;
            MainIngredient = new MainIngredinet { DrinkMainIngredient = mainIgredient };
            Capacity = capacity;
            Calories = calories;
            Ingredients = ingriedients.Select(i => new Ingredient { DrinkIngredient = i }).ToList();
            Description = description;
            Preparations = preparations.Select(p => new Preparation { DrinkPreparations = p }).ToList();
            ImageUrl = imageUrl;
            Ratings = new List<float>();
            AverageRating = 0;
        }
    }
}
