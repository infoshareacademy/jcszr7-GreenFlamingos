namespace GreenFlamingos.Model.Drinks
{
    public class AlcoDrink : Drink
    {
        public AlcoDrink() 
        {
          DrinkType = "Drink";
        }
        public AlcoDrink(string name, User owner, string mainIgredient, int capacity, double alcoholContent, int calories, List<string> ingriedients, string description, List<string> preparation)
        {
            Random rnd = new Random();
            DrinkID = rnd.Next(100000, 299999);
            //Here is needed a condition to check if created number is already used by other AlcoDrink

            DrinkType = "Drink";
            Name = name;
            Owner = owner;
            MainIngredient = mainIgredient;
            if (capacity < 100 || capacity > 500)
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
