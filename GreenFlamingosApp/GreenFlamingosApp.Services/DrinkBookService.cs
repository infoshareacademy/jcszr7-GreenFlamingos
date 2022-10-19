using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
using System.Linq;
namespace GreenFlamingosApp.Services
{
    internal class DrinkBookService
    {
        public List<Drink> DrinkList = new List<Drink>();
        public List<string> PreparationStepsList = new List<string>();
        public AlcoDrink alcoDrink = new AlcoDrink();
        public DrinkBookService() { }
        public void AddDrink(Drink drink)
        {
            DrinkList.Add(drink);
            Console.WriteLine("Drink dodany do książki.\n");
        }

        public void RemoveDrink(int MenuIndex)
        {
            Console.Clear();
            ShowAllDrinks(MenuIndex);
            Console.WriteLine("Podaj nazwe Drinka, którego chcesz usunąć?");
            var drinkName = Console.ReadLine();
            var drinkToRemove = DrinkList.FirstOrDefault(d => string.Equals(d.Name,drinkName,StringComparison.OrdinalIgnoreCase));

            if(drinkToRemove != null)
            {
                DrinkList.Remove(drinkToRemove);
                Console.WriteLine("Drink usunięty z książki.\n");
                ShowAllDrinks(MenuIndex);
            }
            else
            {
                Console.WriteLine("Nie ma drinka o podanej nazwie");
            }

            
        }
        private int Capacity_Check(int MenuIndex)
        {
            Console.Clear();
            var capacity = 0;
            var capacityOk = false;
            do
            {
                Console.WriteLine("Podaj Pojemność:");

                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    if (MenuIndex == 1)
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
                    else if(MenuIndex == 2)
                    {
                        if (capacity >= 25 && capacity <= 100)
                        {
                            capacityOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 25 - 100 ml");
                        }
                    }
                    else
                    {
                        if (capacity >= 250 && capacity <= 1000)
                        {
                            capacityOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 250 - 1000 ml");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Podana przez ciebie objetosc nie jest liczba.");
                }
            } while (!capacityOk);

            return capacity;
        }
        public void CreateDrink(Drink newDrink,User user, int MenuIndex)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę drinka:");
            newDrink.Name = Console.ReadLine();
            Console.WriteLine("Podaj główny składnik drinka:");
            newDrink.MainIngredient = Console.ReadLine();
            newDrink.Capacity = Capacity_Check(MenuIndex);
            newDrink.Owner = user;
            if (MenuIndex != 3)
            {
                Console.WriteLine("Podaj zawartość alkoholu w drinku w %: ");
                newDrink.AlcoholContent = int.Parse(Console.ReadLine());  // Validation needed( int.TryParse)
            }
            else
            {
                newDrink.AlcoholContent = 0;
            }
            Console.WriteLine("Podaj ilość kalorii drinka: ");
            newDrink.Calories = int.Parse(Console.ReadLine());  // Validation needed( int.TryParse)
            Console.WriteLine("Podaj opis: ");
            newDrink.Description = Console.ReadLine();
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
            newDrink.Ingredients = IngredientsList;
            newDrink.Preparation = PreparationStepsList;
        }

        public void DirnkMatch()
        {
            Console.Clear();
            var foundStatus = false;
            Console.WriteLine("Witaj w funkcji znajdz drinka, podaj składniki:");
            Console.WriteLine("Główny składnik:");
            var mainIngredient = Console.ReadLine();

            // returns list of object with mainIngredient set by User
            var mainIngredientDrinks = DrinkList.Where(d => string.Equals(d.MainIngredient, mainIngredient, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Czy chcesz podać dodatkowe skladniki ? (y)");

            if (string.Equals(Console.ReadLine().ToLower(), "y"))
            {
                Console.WriteLine("Podaj ilosc dodatkowych skladników jakie chcesz mieć w swoim drinku");
                var ingredientsCount = 0;
                var ingredientsList = new List<string>();
                if (int.TryParse(Console.ReadLine(), out ingredientsCount))
                {

                    for (int i = 0; i < ingredientsCount; i++)
                    {
                        Console.WriteLine("Podaj skladnik: ");
                        ingredientsList.Add(Console.ReadLine());
                    }
                }
                if (mainIngredientDrinks != null)
                {
                    Console.Clear();
                    //Check list of ingredients contains ingredienst set by user.
                    foreach (var mainIngredientDrink in mainIngredientDrinks)
                        if (ingredientsList.All(ingredient => mainIngredientDrink.Ingredients.Contains(ingredient)))
                        {
                            mainIngredientDrink.ShowDrink();
                            foundStatus = true;
                        }
                }
            }
            else
            {
                if (mainIngredientDrinks != null)
                    foreach(var mainIngredientDrink in mainIngredientDrinks)
                    {
                        mainIngredientDrink.ShowDrink();
                        foundStatus = true;
                    }

            }
            if (!foundStatus)
            {
                Console.WriteLine("Nie znaleziono drinka");
            }
        }

        public void ShowAllDrinks(int MenuIndex)
        {

            switch(MenuIndex)
            {
                case 1:
                    var drinks = DrinkList.Where(d => d.DrinkType == "Drink");
                    if(drinks.Count() > 0)
                    {
                        foreach (var item in drinks)
                            item.ShowDrink();
                    }
                    else
                    {
                        Console.WriteLine("Nie ma drinków w książce");
                    }

                    break;
                case 2:
                    var shots = DrinkList.Where(s => s.DrinkType == "Shot");
                    if (shots.Count() > 0)
                    {
                        foreach (var item in shots)
                            item.ShowDrink();
                    }
                    else
                    {
                        Console.WriteLine("Nie ma shotów w książce");
                    }
                    break;
                case 3:
                    var coctails = DrinkList.Where(c => c.DrinkType == "Drink bezalkoholowy");
                    if(coctails.Count() > 0)
                    {
                        foreach (var item in coctails)
                            item.ShowDrink();
                    }
                    else
                    {
                        Console.WriteLine("Nie ma koktajli bezalkoholowych w książce");
                    }
                    break;
            }
        }
    }
}
