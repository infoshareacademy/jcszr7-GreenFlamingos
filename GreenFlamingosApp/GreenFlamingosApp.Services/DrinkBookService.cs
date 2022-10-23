using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace GreenFlamingosApp.Services
{
    public class DrinkBookService
    {

        public List<Drink> DrinkList = new List<Drink>();
        public List<AlcoDrink> DrinkList1 = new List<AlcoDrink>();
        //public List<string> PreparationStepsList = new List<string>();
        public AlcoDrink alcoDrink = new AlcoDrink();
        public DrinkBookService() 
        {
            var json = File.ReadAllText(@"..\..\..\..\DrinkBook.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            DrinkList = JsonConvert.DeserializeObject<List<Drink>>(json,settings);
        }
        public void ChangeDrink(Drink drink, User user)
        {
            Console.Clear();
            ShowAllDrinks(drink);
            Console.WriteLine("Podaj nazwe drinka, jakiego chcesz zmienic: ");
            var drinkName = Console.ReadLine();
            Console.Clear();
            var drinkToChange = DrinkList.FirstOrDefault(d=>string.Equals(d.Name,drinkName,StringComparison.OrdinalIgnoreCase));
            if(drinkToChange != null)
            {
                drinkToChange.ShowDrink();
                Console.WriteLine("Co chcialbyś zmienić w drinku ? Mozliwe opcje: ");
                DrinkProperites.ShowAllDrinkProperites();
                var userInput = Console.ReadLine();
                Console.Clear();
                if (userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.nazwa).ToLower())
                {
                    Console.WriteLine("Podaj nową nazwe drinka: ");
                    var newName = Console.ReadLine();
                    drinkToChange.Name = newName;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.glownySkladnik).ToLower())
                {
                    Console.WriteLine("Podaj nowy glowny skladnik");
                    var newMainIngredient = Console.ReadLine();
                    drinkToChange.MainIngredient = newMainIngredient;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.pojemnosc).ToLower())
                {
                    Console.WriteLine("Podaj nową objetosc napoju: ");
                    var newCapacity = ValidateCapacity(drink);
                    drinkToChange.Capacity = newCapacity;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.kalorie).ToLower())
                {
                    Console.WriteLine("Podaj ilosc kalori:");
                    var newCalories = int.Parse(Console.ReadLine());
                    drinkToChange.Calories = newCalories;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.skladniki).ToLower())
                {
                    Console.WriteLine("Ile składników chcesz dodać?");
                    var ingredientamount = int.Parse(Console.ReadLine()); // Validation needed(int.TryParse)
                    var IngredientsList = new List<string>();
                    for (int i = 0; i < ingredientamount; i++)
                    {
                        Console.WriteLine("Podaj składnik: ");
                        var ingredient = Console.ReadLine();
                        IngredientsList.Add(ingredient);
                    }
                    drinkToChange.Ingredients = IngredientsList;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.przepis).ToLower())
                {
                    Console.WriteLine("Ile kroków potrzeba do przygotowania drinka?");
                    var stepsAmount = int.Parse(Console.ReadLine()); // Validation needed(int.TryParse)
                    var PreparationStepsList = new List<string>();
                    for (int i = 0; i < stepsAmount; i++)
                    {
                        Console.WriteLine("Podaj krok: ");
                        var step = Console.ReadLine();
                        PreparationStepsList.Add(step);
                    }
                    drinkToChange.Preparation = PreparationStepsList;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else
                {
                    Console.WriteLine("Podałes błędną informacje.");
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono napoju o takiej nazwie");
            }
        }
        public void AddDrink(Drink drink)
        {

            DrinkList.Add(drink);
            Console.WriteLine("Drink dodany do książki.\n");
        }
        public void RemoveDrink(Drink drink)
        {
            Console.Clear();
            ShowAllDrinks(drink);
            Console.WriteLine("Podaj nazwe Drinka, którego chcesz usunąć?");
            var drinkName = Console.ReadLine();
            var drinkToRemove = DrinkList.FirstOrDefault(d => string.Equals(d.Name,drinkName,StringComparison.OrdinalIgnoreCase));

            if(drinkToRemove != null)
            {
                DrinkList.Remove(drinkToRemove);
                Console.WriteLine("Drink usunięty z książki.\n");
                ShowAllDrinks(drink);
            }
            else
            {
                Console.WriteLine("Nie ma drinka o podanej nazwie");
            }  
        }
        private int ValidateCapacity(Drink drink)
        {
            var capacity = 0;
            var capacityOk = false;
            do
            {
                Console.WriteLine("Podaj Pojemność:");

                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    if (drink.DrinkType == "Drink")
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
                    else if(drink.DrinkType == "Shot")
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
            newDrink.Capacity = ValidateCapacity(newDrink);
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
            var PreparationStepsList = new List<string>();
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
        public void ShowAllDrinks(Drink drink)
        {
            var drinkList = DrinkList.Where(d => d.DrinkType == drink.DrinkType);

            if (drinkList.Count() > 0)
            {
                foreach (var item in drinkList)
                    item.ShowDrink();
            }
            else
            {
                Console.WriteLine($"W książce nie ma żadnego napoju typu: {drink.DrinkType}");
            }
        }
    }
}
