using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using GreenFlamingosApp.Services.Validation;
using System.Windows.Input;

namespace GreenFlamingosApp.Services
{
    public class DrinkBookService
    {
        public List<Drink> DrinkList = new List<Drink>();
        private IngredientsService _ingredientsService = new IngredientsService();
        private PreparationService _preparationService = new PreparationService();
        private IngredientsListClass _ingredientsListClass = new IngredientsListClass();
        public DrinkBookService() 
        {
            var json = File.ReadAllText(@"..\..\..\..\DrinkBook.json");
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            DrinkList = JsonConvert.DeserializeObject<List<Drink>>(json,settings);
        }

        public void ShowDrinkByName(User user)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwe napoju, którego szukasz");
            var userInput = Console.ReadLine();
            var drinkToShow = DrinkList.FirstOrDefault(d=>d.Name == userInput);

            if(drinkToShow != null)
            {
                drinkToShow.ShowDrink();
                Console.WriteLine("Czy chcesz dodac ten napój do ulubionych ? (y)");
                if(Console.ReadLine().ToLower() == "y".ToLower())
                {
                    user.FavoriteDrinks.Add(drinkToShow);
                    Console.WriteLine("Napój dodano do ulubionych");
                }
            }
            else
            {
                Console.WriteLine("Nie ma takiego drinka w aplikacji");
            }    
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
                    if (_ingredientsListClass.CheckingIfListContainsIngredient(newMainIngredient))
                    {
                        drinkToChange.MainIngredient = newMainIngredient;
                    }
                    else
                    {
                        Console.WriteLine("Podany składnik nie znajduje się na liście dozwolonych składników. Składnik nie został zmieniony");
                    }
                    drinkToChange.MainIngredient = newMainIngredient;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.pojemnosc).ToLower())
                {
                    Console.WriteLine("Podaj nową objetosc napoju: ");
                    var newCapacity = ValidationClass.ValidateCapacity(drink);
                    drinkToChange.Capacity = newCapacity;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.kalorie).ToLower())
                {
                    Console.WriteLine("Podaj ilosc kalori:");
                    var newCalories = ValidationClass.ValidateCalories();
                    drinkToChange.Calories = newCalories;
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.skladniki).ToLower())
                {
                    Console.WriteLine("Ile składników chcesz dodać?");
                    var ingredientamount = ValidationClass.ValidateSteps(); // Validation needed(int.TryParse)
                    drinkToChange.Ingredients = _ingredientsService.GetStringList(ingredientamount);
                    drinkToChange.Owner = user;
                    Console.WriteLine("Pomyslnie zmieniles napoj !");
                }
                else if(userInput.ToLower() == nameof(DrinkProperites.DrinkProperties.przepis).ToLower())
                {
                    Console.WriteLine("Ile kroków potrzeba do przygotowania drinka?");
                    var stepsAmount = ValidationClass.ValidateSteps(); // Validation needed(int.TryParse)
                    drinkToChange.Preparation = _preparationService.GetStringList(stepsAmount);
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
                Console.Clear();
                Console.WriteLine("Drink usunięty z książki.\n");
                ShowAllDrinks(drink);
            }
            else
            {
                Console.WriteLine("Nie ma drinka o podanej nazwie");
            }  
        }
        public bool CreateDrink(Drink newDrink,User user, int MenuIndex)
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę drinka:");
            newDrink.Name = Console.ReadLine();
            Console.WriteLine("Podaj główny składnik drinka:");
            string ingredient = Console.ReadLine();
            if(_ingredientsListClass.CheckingIfListContainsIngredient(ingredient))
            {
                newDrink.MainIngredient = ingredient;
            }
            else
            {
                Console.WriteLine("Podany składnik nie znajduje się na liście dozwolonych składników. Zostaniesz przeniesiony do menu głównego");
                Console.WriteLine("Ponizej lista dostępnych składników: ");
                Console.WriteLine(_ingredientsListClass.IngredientList());
                Console.ReadKey();
                return false;
            }
            newDrink.Capacity = ValidationClass.ValidateCapacity(newDrink);
            newDrink.Owner = user;     
            newDrink.AlcoholContent = ValidationClass.ValidateAlcoholContent(newDrink);
            newDrink.Calories = ValidationClass.ValidateCalories();
            Console.WriteLine("Podaj opis: ");
            newDrink.Description = Console.ReadLine();
            Console.WriteLine("Ile składników chcesz dodać?");
            var ingredientamount = ValidationClass.ValidateSteps();
            newDrink.Ingredients = _ingredientsService.GetStringList(ingredientamount);
            Console.WriteLine("Ile kroków potrzeba do przygotowania drinka?");
            var stepsAmount = ValidationClass.ValidateSteps();
            newDrink.Preparation = _preparationService.GetStringList(stepsAmount);
            return true;
        }
        public void DirnkMatch()
        {
            Console.Clear();
            var foundStatus = false;
            Console.WriteLine("Witaj w funkcji znajdz drinka, podaj składniki:");
            Console.WriteLine("Główny składnik:");
            var mainIngredient = Console.ReadLine();
            if (!_ingredientsListClass.CheckingIfListContainsIngredient(mainIngredient))
            {
                Console.WriteLine("Podany składnik nie znajduje się na liście dozwolonych składników.");
                Console.WriteLine("Ponizej lista dostępnych składników: ");
                Console.WriteLine(_ingredientsListClass.IngredientList());
            }
            else
            {
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
                        {
                            if (ingredientsList.All(ingredient => mainIngredientDrink.Ingredients.Contains(ingredient)))
                            {
                                mainIngredientDrink.ShowDrink();
                                foundStatus = true;
                            }
                        }
                    }
                }
                else
                {
                    if (mainIngredientDrinks != null)
                        foreach (var mainIngredientDrink in mainIngredientDrinks)
                        {
                            mainIngredientDrink.ShowDrink();
                            foundStatus = true;
                        }
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
        public void ShowFavoriteDrinks(User user)
        {
            Console.Clear();
            if (user.FavoriteDrinks.Count() > 0)
            {
                foreach (var drink in user.FavoriteDrinks)
                {
                    Console.WriteLine("Moje ulubione napoje: ");
                    drink.ShowDrink();
                }
            }
            else
            {
                Console.WriteLine("Nie dodałes żadnego napoju do ulubionych. Aby dodać napój do ulubionychprzed do sekcji 2.Pokaż wybranego");
            }
        }
        public void EditDataBase(List<string> ingredientsDataBase)
        {
            var userInput = 0;
            do
            {
                DefaultMenu.AdminDataBaseOptions();
                if (int.TryParse(Console.ReadLine(),out userInput))
                {
                    switch(userInput)
                    {
                        case 1:
                            _ingredientsListClass.AddIngredientToListByAdmin();
                            break;
                        case 2:
                            _ingredientsListClass.RemoveIngredientFromListByAdmin();
                            break;
                        case 3:
                            Console.WriteLine($"{_ingredientsListClass.IngredientList()}");
                            Console.ReadLine();
                            break;
                    }
                }

            } while (userInput != 4);


        }
    }
}
