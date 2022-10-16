namespace GreenFlamingos.Model.Drinks
{
    public class AlcoDrink : Drink
    {
        public AlcoDrink() { }
        public AlcoDrink(string name, string mainIgredient, int capacity)
        {
            DrinkType = "Drink";
            Name = name;
            MainIngredient = mainIgredient;

            if (capacity < 100 || capacity > 500)
                throw new ArgumentOutOfRangeException();
            else
                Capacity = capacity;
        }

        public AlcoDrink(string name, string mainIgredient, int capacity, string igredient1) : this(name, mainIgredient, capacity)
        {
            Ingredient1 = igredient1;
        }
        public AlcoDrink(string name, string mainIgredient, int capacity, string igredient1, string igredient2) : this(name, mainIgredient, capacity, igredient1)
        {
            Ingredient2 = igredient2;
        }
        public AlcoDrink(string name, string mainIgredient, int capacity, string igredient1, string igredient2, string igredient3) : this(name, mainIgredient, capacity, igredient1, igredient2)
        {
            Ingredient3 = igredient3;
        }
    }
}
