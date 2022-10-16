namespace GreenFlamingos.Model.Drinks
{
    public class NoAlcoDrink : Drink
    {
        public NoAlcoDrink(string name, User owner, string mainIgredient, int capacity, double alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparation)
        {
            Random rnd = new Random();
            DrinkID = rnd.Next(300000, 599999);
            //Here is needed a condition to check if created number is already used by other NoAlcoDrink

            DrinkType = "Drink bezalkoholowy";
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
