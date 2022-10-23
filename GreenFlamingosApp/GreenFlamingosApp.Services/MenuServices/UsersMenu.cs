using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace GreenFlamingosApp.Services.MenuServices
{
    public class UsersMenu
    {
        public virtual void UnloggedMenuService(int menuIndex,User user,Drink drink, DrinkBookService drinkBookService)
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
                            drinkBookService.ShowAllDrinks(drink);
                            Console.ReadKey();
                            break;
                        case 2:
                            drinkBookService.DirnkMatch();
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userInput != 3);
        }
    }
    public class LoggedUserMenu
    {
        public void UserMenuService(int menuIndex,Drink newDrink,User user, DrinkBookService drinkBookService)
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
                            drinkBookService.CreateDrink(newDrink, user, menuIndex);
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
                                //drinkBookService.AddDrink(drinkToAdd);

                                drinkBookService.DrinkList.Add(drinkToAdd);
                                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                                var json = JsonConvert.SerializeObject(drinkBookService.DrinkList, Formatting.Indented, settings);
                                File.WriteAllText(@"..\..\..\..\DrinkBook.json", json);
                                Console.WriteLine($"Brawo, Pomyslnie stworzyłeś {drinkToAdd.DrinkType} !");
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            drinkBookService.ShowAllDrinks(newDrink);
                            Console.ReadKey();
                            break;
                        case 3:
                            drinkBookService.RemoveDrink(newDrink);
                            Console.ReadKey();
                            break;
                        case 4:
                            drinkBookService.DirnkMatch();
                            Console.ReadKey();
                            break;
                        case 5:
                            drinkBookService.ChangeDrink(newDrink,user);
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("Bye");
                            break;
                    }
                }
            } while (userInput != 6);
        }
    }
}
