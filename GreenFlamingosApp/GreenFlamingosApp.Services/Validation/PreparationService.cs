using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services.Validation
{
    public class PreparationService : IngredientsService
    {
        public override List<string> GetStringList(int amount)
        {
            var IngredientsList = new List<string>();
            for (int i = 0; i < amount; i++) //replace this by function
            {
                Console.WriteLine("Podaj krok: ");
                var ingredient = Console.ReadLine();
                IngredientsList.Add(ingredient);
            }
            return IngredientsList;
        }
    }
}
