using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services
{
    internal class DrinkBookService
    {
        public List<Drink> DrinkList = new List<Drink>();
        public List<string> IngredientsList = new List<string>();
        public List<string> PreparationStepsList = new List<string>();
        AlcoDrink alcoDrink = new AlcoDrink();
        public DrinkBookService(){}
        public void AddDrink(Drink drink)
        {
            DrinkList.Add(drink);
            Console.WriteLine("Drink dodany do książki.\n");
        }

        public void RemoveDrink()
        {
            Console.WriteLine("Który drink z listy chcesz usunąć?");
            int drinkIndex = int.Parse(Console.ReadLine());
            DrinkList.RemoveAt(drinkIndex - 1);
            Console.WriteLine("Drink usunięty z książki.\n");
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
            int capacity;
            bool capacityOk = false;
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
        public void CreateAlcoDrink(AlcoDrink newAlcoDrink)
        {
            Console.WriteLine("Podaj nazwę drinka:");
            newAlcoDrink.Name = Console.ReadLine();
            Console.WriteLine("Podaj główny składnik drinka:");
            newAlcoDrink.MainIngredient = Console.ReadLine();
            newAlcoDrink.Capacity = Capacity_Check();
            newAlcoDrink.Owner = new User();
            Console.WriteLine("Podaj zawartość alkoholu w drinku w %: ");
            newAlcoDrink.AlcoholContent = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ilość kalorii drinka: ");
            newAlcoDrink.Calories = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj opis: ");
            newAlcoDrink.Description = Console.ReadLine();
            Console.WriteLine("Ile składników chcesz dodać?");
            var ingredientamount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ingredientamount; i++)
            {
                Console.WriteLine("Podaj składnik: ");
                var ingredient = Console.ReadLine();
                IngredientsList.Add(ingredient);
            }
            Console.WriteLine("Ile kroków potrzeba do przygotowania drinka?");
            var stepsAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < stepsAmount; i++)
            {
                Console.WriteLine("Podaj krok: ");
                var step = Console.ReadLine();
                PreparationStepsList.Add(step);
            }
            newAlcoDrink.Ingredients = IngredientsList;
            newAlcoDrink.Preparation = PreparationStepsList;
        }

        public void ClearDrinkBook()
        {
            DrinkList.Clear();
            Console.WriteLine("Wszystkie drinki z książki zostały usunięte.\n");
        }

        public void ShowingDrinksWithIngredient()
        {
            Console.WriteLine("Wprowadź składnik: ");
            var ingredient = Console.ReadLine();
            var listWithIngredient = DrinkList.Where(x => x.Ingredients.Any(y => y == ingredient)).ToList();
            if (listWithIngredient.Count == 0)
            {
                Console.WriteLine("żaden z drinków w książce nie zawiera podanego składnika");
            }
            else
            {
            Console.WriteLine("Lista drinków zawierająca podany składnik:");
                foreach (var item in listWithIngredient)
                {
                    item.ShowDrinkWithIngredient();
                }
            }
            Console.ReadKey();
        }


        public void ShowingDrinksWithBiggerCapacityThen()
        {
            Console.WriteLine("Podaj objętość a podam wszystkie większe");
            var capacity = int.Parse(Console.ReadLine());
            var listWithIBiggerCapacity = DrinkList.Where(x => x.Capacity > capacity).ToList();
            if (listWithIBiggerCapacity.Count == 0)
            {
                Console.WriteLine("w książce nie ma takich drinków");
            }
            else
            {
                Console.WriteLine("Lista drinków z większą objętością niż podana:");
                foreach (var item in listWithIBiggerCapacity)
                {
                    item.ShowDrinkWithIngredient();
                }
            }
            Console.ReadKey();
        }


        public void SortByName()
        {
            var orderedDrinksByName = DrinkList.OrderBy(o => o.Name);
            foreach (var item in orderedDrinksByName)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void SortByCapacity()
        {
            var orderedDrinksByName = DrinkList.OrderBy(o => o.Capacity);
            foreach (var item in orderedDrinksByName)
            {
                Console.WriteLine(item.Name);
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
