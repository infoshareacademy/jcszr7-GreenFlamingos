using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
namespace GreenFlamingos.Model.Drinks
{
    public class Shot : Drink
    {
        public Shot()
        {
            DrinkType = "Shot";
        }
        public Shot(string name, User owner, string mainIgredient, int capacity, float alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparations, string imageUrl)
        {
            DrinkType = "Shot";
            Name = name;
            Owner = owner;
            MainIngredient = new MainIngredinet { DrinkMainIngredient = mainIgredient };
            Capacity = capacity;
            AlcoholContent = alcoholContent;
            Calories = calories;
            Ingredients = ingriedients.Select(i => new Ingredient { DrinkIngredient = i}).ToList();
            Description = description;
            Preparations = preparations.Select(p => new Preparation {DrinkPreparations = p }).ToList();
            ImageUrl = imageUrl;
            Ratings = new List<float>();
            AverageRating = 0;
        }
    }
}
