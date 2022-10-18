using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
namespace GreenFlamingosApp.Services
{
    internal class DrinkBookService
    {
        public List<Drink> DrinkList = new List<Drink>();
        //public List<string> IngredientsList = new List<string>();
        public List<string> PreparationStepsList = new List<string>();
        AlcoDrink alcoDrink = new AlcoDrink();
        public DrinkBookService() { }
        public void AddDrink(Drink drink)
        {
            DrinkList.Add(drink);
            Console.WriteLine("Drink dodany do książki.\n");
        }

        public void RemoveDrink()
        {

            ShowAllDrinks();
            Console.WriteLine("Podaj nazwe Drinka, którego chcesz usunąć?");
            var drinkName = Console.ReadLine();
            var drinkToRemove = DrinkList.FirstOrDefault(d => string.Equals(d.Name,drinkName,StringComparison.OrdinalIgnoreCase));

            if(drinkToRemove != null)
            {
                DrinkList.Remove(drinkToRemove);
                Console.WriteLine("Drink usunięty z książki.\n");
                ShowAllDrinks();
            }
            else
            {
                Console.WriteLine("Nie ma drinka o podanej nazwie");
            }

            
        }

        //Function to add extra ingredients ( max cuantity of ingredients is 3 - can be more, but Drink class has to be changed)
        public string AdditionalIgredient()
        {
            string ingredient;
            Console.WriteLine("Czy chcesz podac dodatkowe skladniki ? (y)");
            string userInput = Console.ReadLine();
            if (string.Equals(userInput, "y"))
            {
                Console.WriteLine("Podaj dodatkowy skladnik:");
                ingredient = Console.ReadLine();
            }
            else
            {
                ingredient = null;
            }

            return ingredient;
        }
        public int Capacity_Check()
        {
            var capacity = 0;
            var capacityOk = false;
            do
            {
                Console.WriteLine("Podaj Pojemność:");

                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    if (capacity >= 100 && capacity <= 500)
                    {
                        capacityOk = true;
                    }
                    else
                    {
                        Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 100 - 500 ml");
                    }
                }
                else
                {
                    Console.WriteLine("Podana przez ciebie objetosc nie jest liczba.");
                }
            } while (!capacityOk);

            return capacity;
        }
        public void CreateAlcoDrink(AlcoDrink newAlcoDrink,User user)
        {
            Console.WriteLine("Podaj nazwę drinka:");
            newAlcoDrink.Name = Console.ReadLine();
            Console.WriteLine("Podaj główny składnik drinka:");
            newAlcoDrink.MainIngredient = Console.ReadLine();
            newAlcoDrink.Capacity = Capacity_Check();
            newAlcoDrink.Owner = user;
            Console.WriteLine("Podaj zawartość alkoholu w drinku w %: ");
            newAlcoDrink.AlcoholContent = int.Parse(Console.ReadLine());  // Validation needed( int.TryParse)
            Console.WriteLine("Podaj ilość kalorii drinka: ");
            newAlcoDrink.Calories = int.Parse(Console.ReadLine());  // Validation needed( int.TryParse)
            Console.WriteLine("Podaj opis: ");
            newAlcoDrink.Description = Console.ReadLine();
            Console.WriteLine("Ile składników chcesz dodać?");
            var ingredientamount = int.Parse(Console.ReadLine()); // Validation needed(int.TryParse)

            var IngredientsList = new List<string>();
            for (int i = 0; i < ingredientamount; i++)
            {
                Console.WriteLine("Podaj składnik: ");
                var ingredient = Console.ReadLine();
                IngredientsList.Add(ingredient);
            }
            Console.WriteLine("Ile kroków potrzeba do przygotowania drinka?");
            var stepsAmount = int.Parse(Console.ReadLine()); // Validation needed(int.TryParse)
            for (int i = 0; i < stepsAmount; i++)
            {
                Console.WriteLine("Podaj krok: ");
                var step = Console.ReadLine();
                PreparationStepsList.Add(step);
            }
            newAlcoDrink.Ingredients = IngredientsList;
            newAlcoDrink.Preparation = PreparationStepsList;
        }

        public void SortBy(Drink drink)
        {
            DrinkList.Sort();
        }
        public void DirnkMatch()
        {
            var foundStatus = false;
            Console.WriteLine("Witaj w funkcji znajdz drinka, podaj składniki:");
            Console.WriteLine("Główny składnik:");
            var mainIngredient = Console.ReadLine();
            Console.WriteLine("Podaj ilosc dodatkowych skladników jakie chcesz mieć w swoim drinku");
            var ingredientsCount = 0;
            var ingredientsList = new List<string>();
            if (int.TryParse(Console.ReadLine(), out ingredientsCount))
            {
                
                for(int i = 0; i < ingredientsCount; i++)
                {
                    Console.WriteLine("Podaj skladnik: ");
                    ingredientsList.Add(Console.ReadLine());
                }
            }
            // returns list of object with mainIngredient set by User
            var mainIngredientDrinks = DrinkList.Where(d =>string.Equals(d.MainIngredient, mainIngredient, StringComparison.OrdinalIgnoreCase));

            if (mainIngredientDrinks != null)
            {
                //Check list of ingredients contains ingredienst set by user.
                foreach (var mainIngredientDrink in mainIngredientDrinks)
                    if (ingredientsList.All(ingredient => mainIngredientDrink.Ingredients.Contains(ingredient)))
                    {
                        mainIngredientDrink.ShowDrink();
                        foundStatus = true;
                    }
            }
            if(!foundStatus)
            {
                Console.WriteLine("Nie znaleziono drinka");
            }
        }

        public void ShowAllDrinks()
        {
            if (DrinkList.Count == 0)
            {
                Console.WriteLine("Książka jest pusta!");
            }
       
            foreach (var drink in DrinkList)
            {
                drink.ShowDrink();
            }
        }
    }
}
