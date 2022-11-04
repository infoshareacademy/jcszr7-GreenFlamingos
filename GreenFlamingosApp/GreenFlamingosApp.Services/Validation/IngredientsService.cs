namespace GreenFlamingosApp.Services.Validation
{
    public class IngredientsService
    {
        private IngredientsListClass _ingredientsListClass = new IngredientsListClass();
        public virtual List<string> GetStringList(int amount)
        {
            var IngredientsList = new List<string>();
            for (int i = 0; i < amount; i++) 
            {
                Console.WriteLine("Podaj składnik: ");
                var ingredient = Console.ReadLine();
                if (string.Equals(ingredient, "x", StringComparison.OrdinalIgnoreCase))
                    break;
                IngredientsList.Add(ingredient);
            }
            return IngredientsList;
        }
    }
}
