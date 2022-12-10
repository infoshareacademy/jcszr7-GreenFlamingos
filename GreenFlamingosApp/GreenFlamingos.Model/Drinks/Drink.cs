namespace GreenFlamingos.Model.Drinks
{
    public abstract class Drink
    {
        private int _drinkID;
        public int DrinkID { get { return _drinkID; } set { _drinkID = value; } }
        public User Owner { get; set; }
        public double AlcoholContent { get; set; }
        public int Calories { get; set; }
        public string DrinkType { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public double AlcoholContent { get; set; }
        public int Calories { get; set; }
        public string MainIngredient { get; set; }
        public int Capacity { get; set; }
        public List<string> Ingredients { get; set; }
        public string Description { get; set; }
        public List<string> Preparation { get; set; }

        public virtual void ShowIngredients()
        {
            Console.WriteLine($"Oto moj {DrinkType} + {Name}");
            Console.WriteLine("Składniki:");
            Console.WriteLine($"Głowny składnik: {MainIngredient}");
            Console.WriteLine($"Pojemnosc: {Capacity}");

            ////// Below is checking that drink has optional igredients///////////
            if (!string.IsNullOrEmpty(Ingredient1))
            {
                Console.WriteLine($"Skladnik 1: {Ingredient1}");
            }
            if (!string.IsNullOrEmpty(Ingredient2))
            {
                Console.WriteLine($"Skladnik 2: {Ingredient2}");
            }
            if (!string.IsNullOrEmpty(Ingredient3))
            {
                Console.WriteLine($"Skladnik 3: {Ingredient3}");
            }
        }

        virtual public void ShowDrinkWithIngredient()
        {
            Console.WriteLine("Przygotowanie: ");
            Console.WriteLine("Jakis przepis");         /////Here will show recipe from user
        }

        public void ShowDrink()
        {
            ShowIngredients();
            ShowRecipe();
        }

    }
}
