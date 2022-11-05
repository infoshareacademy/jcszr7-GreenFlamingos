using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;
using GreenFlamingosApp.DataBase;
using Newtonsoft.Json;

namespace GreenFlamingosApp.Services.MenuServices
{
    public class UnloggedMenu
    {
        public virtual void UnloggedMenuService(int menuIndex, User user, Drink drink, DrinkBookService drinkBookService)
        {
            var userInput = 0;
            do
            {
                DefaultMenu.DrinkOptions(user);
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            drinkBookService.ShowAllDrinks(drink,drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 2:
                            drinkBookService.DirnkMatch(drink);
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userInput != 3);
        }
    }
    public class LoggedUserMenu
    {
        public void UserMenuService(int menuIndex, Drink newDrink, User user, DrinkBookService drinkBookService)
        {
            var userInput = 0;
            do
            {
                DefaultMenu.DrinkOptions(user);
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            if (drinkBookService.CreateDrink(newDrink, user, menuIndex))
                            {
                                //Validation of drink name - if in DrinkBookService exists drink with the same name as user set - do not add.
                                var drinkToAdd = drinkBookService.DrinkList.Find(d => string.Equals(d.Name.ToUpper(), newDrink.Name.ToUpper()));
                                if (drinkToAdd != null)
                                {
                                    Console.WriteLine("Drink o podanej nazwie istnieje");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    switch (menuIndex)
                                    {
                                        case 1:
                                            {
                                                drinkToAdd = new AlcoDrink(newDrink.Name,
                                                                 newDrink.Owner,
                                                                 newDrink.MainIngredient,
                                                                 newDrink.Capacity,
                                                                 newDrink.AlcoholContent,
                                                                 newDrink.Calories,
                                                                 newDrink.Ingredients,
                                                                 newDrink.Description,
                                                                 newDrink.Preparation);

                                                break;
                                            }
                                        case 2:
                                            {
                                                drinkToAdd = new Shot(newDrink.Name,
                                                                 newDrink.Owner,
                                                                 newDrink.MainIngredient,
                                                                 newDrink.Capacity,
                                                                 newDrink.AlcoholContent,
                                                                 newDrink.Calories,
                                                                 newDrink.Ingredients,
                                                                 newDrink.Description,
                                                                 newDrink.Preparation);
                                                break;
                                            }
                                        case 3:
                                            {
                                                drinkToAdd = new NoAlcoDrink(newDrink.Name,
                                                                 newDrink.Owner,
                                                                 newDrink.MainIngredient,
                                                                 newDrink.Capacity,
                                                                 newDrink.AlcoholContent,
                                                                 newDrink.Calories,
                                                                 newDrink.Ingredients,
                                                                 newDrink.Description,
                                                                 newDrink.Preparation);
                                                break;
                                            }
                                    }
                                    drinkBookService.DrinkList.Add(drinkToAdd);
                                    GreenFlamingosDataBaseService.WriteAllDrinks(drinkBookService.DrinkList);
                                    Console.WriteLine($"Brawo, Pomyslnie stworzyłeś {drinkToAdd.DrinkType} !");
                                }
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            drinkBookService.ShowDrinkByName(user);
                            Console.ReadKey();
                            break;
                        case 3:
                            drinkBookService.ShowAllDrinks(newDrink, drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 4:
                            drinkBookService.RemoveDrink(newDrink);
                            GreenFlamingosDataBaseService.WriteAllDrinks(drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 5:
                            drinkBookService.DirnkMatch(newDrink);
                            Console.ReadKey();
                            break;
                        case 6:
                            drinkBookService.ChangeDrink(newDrink, user);
                            GreenFlamingosDataBaseService.WriteAllDrinks(drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 7:
                            drinkBookService.ShowFavoriteDrinks(user);
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.WriteLine("Bye");
                            break;
                    }
                }
            } while (userInput != 8);
        }
    }
    public class AdminMenu
    {
        private IngredientsListClass _ingredientsListClass = new IngredientsListClass();
        public void AdminMenuService(int menuIndex, Drink newDrink, User user, DrinkBookService drinkBookService)
        {
            var userInput = 0;
            do
            {
                DefaultMenu.DrinkOptions(user);
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            if(drinkBookService.CreateDrink(newDrink, user, menuIndex))
                            {
                                //Validation of drink name - if in DrinkBookService exists drink with the same name as user set - do not add.
                                var drinkToAdd = drinkBookService.DrinkList.Find(d => string.Equals(d.Name.ToUpper(), newDrink.Name.ToUpper()));
                                if (drinkToAdd != null)
                                {
                                    Console.WriteLine("Drink o podanej nazwie istnieje");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    switch (menuIndex)
                                    {
                                        case 1:
                                            {
                                                drinkToAdd = new AlcoDrink(newDrink.Name,
                                                                 newDrink.Owner,
                                                                 newDrink.MainIngredient,
                                                                 newDrink.Capacity,
                                                                 newDrink.AlcoholContent,
                                                                 newDrink.Calories,
                                                                 newDrink.Ingredients,
                                                                 newDrink.Description,
                                                                 newDrink.Preparation);
                                                break;
                                            }
                                        case 2:
                                            {
                                                drinkToAdd = new Shot(newDrink.Name,
                                                                 newDrink.Owner,
                                                                 newDrink.MainIngredient,
                                                                 newDrink.Capacity,
                                                                 newDrink.AlcoholContent,
                                                                 newDrink.Calories,
                                                                 newDrink.Ingredients,
                                                                 newDrink.Description,
                                                                 newDrink.Preparation);
                                                break;
                                            }
                                        case 3:
                                            {
                                                drinkToAdd = new NoAlcoDrink(newDrink.Name,
                                                                 newDrink.Owner,
                                                                 newDrink.MainIngredient,
                                                                 newDrink.Capacity,
                                                                 newDrink.AlcoholContent,
                                                                 newDrink.Calories,
                                                                 newDrink.Ingredients,
                                                                 newDrink.Description,
                                                                 newDrink.Preparation);
                                                break;
                                            }
                                    }
                                    drinkBookService.DrinkList.Add(drinkToAdd);
                                    GreenFlamingosDataBaseService.WriteAllDrinks(drinkBookService.DrinkList);
                                    Console.WriteLine($"Brawo, Pomyslnie stworzyłeś {drinkToAdd.DrinkType} !");
                                }
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            drinkBookService.ShowAllDrinks(newDrink, drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 3:
                            drinkBookService.RemoveDrink(newDrink);
                            GreenFlamingosDataBaseService.WriteAllDrinks(drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 4:
                            drinkBookService.DirnkMatch(newDrink);
                            Console.ReadKey();
                            break;
                        case 5:
                            drinkBookService.ChangeDrink(newDrink, user);
                            GreenFlamingosDataBaseService.WriteAllDrinks(drinkBookService.DrinkList);
                            Console.ReadKey();
                            break;
                        case 6:
                            drinkBookService.EditDataBase(_ingredientsListClass.AllIngredientsList);
                            break;
                        case 7:
                            Console.WriteLine("Bye");
                            break;
                    }
                }
            } while (userInput != 7);
        }
    }

}
