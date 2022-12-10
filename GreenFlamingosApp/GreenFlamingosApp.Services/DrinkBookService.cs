using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;
using GreenFlamingos.Model;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using GreenFlamingosApp.Services.Validation;
using System.Windows.Input;
using GreenFlamingosApp.DataBase;

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
            DrinkList = GreenFlamingosDataBaseService.ReadAllDrinks();
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
            ShowAllDrinks(drink, DrinkList);
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
                    var DrinkCheck = DrinkList.FirstOrDefault(d => string.Equals(d.Name, newName, StringComparison.OrdinalIgnoreCase));
                    if(DrinkCheck != null)
                    {
                        Console.WriteLine("Drink o takiej nazwie już istnieję. Nie udało sie zmienić drinka.");
                    }
                    else
                    {
                        drinkToChange.Name = newName;
                        drinkToChange.Owner = user;
                        Console.WriteLine("Pomyslnie zmieniles napoj !");
                    }  
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
            ShowAllDrinks(drink, DrinkList);
            Console.WriteLine("Podaj nazwe Drinka, którego chcesz usunąć?");
            var drinkName = Console.ReadLine();
            var drinkToRemove = DrinkList.FirstOrDefault(d => string.Equals(d.Name,drinkName,StringComparison.OrdinalIgnoreCase));

            if(drinkToRemove != null)
            {
                DrinkList.Remove(drinkToRemove);
                Console.Clear();
                Console.WriteLine("Drink usunięty z książki.\n");
                Console.ReadKey();
                Console.Clear();
                ShowAllDrinks(drink, DrinkList);
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
            if (string.Equals(newDrink.Name, "x", StringComparison.OrdinalIgnoreCase))
                return false;
            Console.WriteLine("Podaj główny składnik drinka:");
            newAlcoDrink.MainIngredient = Console.ReadLine();
            newAlcoDrink.Capacity = Capacity_Check();

            //////Extra Ingredients Service//////////
            newAlcoDrink.Ingredient1 = AdditionalIgredient();
            if (newAlcoDrink.Ingredient1 is null)
                return;
            else
                newAlcoDrink.Ingredient2 = AdditionalIgredient();
            if (newAlcoDrink.Ingredient2 is null)
                return;
            else
                newAlcoDrink.Ingredient3 = AdditionalIgredient();
            return;
        }

        public void ClearDrinkBook()
        {
            DrinkList.Clear();
            Console.WriteLine("Wszystkie drinki z książki zostały usunięte.\n");
        }

        public void SortBy(Drink drink)
        {
            DrinkList.Sort();
        }
        public void ShowAllDrinks(Drink drink, List<Drink> drinkListToShow)
        {
            Console.Clear();
            var drinkList = drinkListToShow.Where(d => d.DrinkType == drink.DrinkType);

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
