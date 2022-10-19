using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services.MenuServices
{
    public class DrinksMenu
    {
        DrinkBookService drinkBook = new DrinkBookService();
        public void DrinkService(Drink newDrink,User user,int MenuIndex)
        {
            var userInput = 0;
            do
            {
                DefaultMenu.DrinkOptions();
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                                drinkBook.CreateDrink(newDrink, user, MenuIndex);

                                //Validation of drink name - if in DrinkBookService exists drink with the same name as user set - do not add.
                                var drinkToAdd = drinkBook.DrinkList.Find(d => string.Equals(d.Name.ToUpper(), newDrink.Name.ToUpper()));
                                if (drinkToAdd != null)
                                {
                                    Console.WriteLine("Drink o podanej nazwie istnieje");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    switch (MenuIndex)
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
                                    drinkBook.AddDrink(drinkToAdd);
                                    Console.WriteLine($"Brawo, Pomyslnie stworzyłeś {drinkToAdd.DrinkType} !");
                                    Console.ReadKey();
                                }
                            Console.ReadKey();
                            break;
                        case 2:
                                drinkBook.ShowAllDrinks(MenuIndex);
                                Console.ReadKey();
                            break;
                        case 3:
                                drinkBook.RemoveDrink(MenuIndex);
                                Console.ReadKey();
                            break;
                        case 4:
                            drinkBook.DirnkMatch();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("Edycja Drinka");
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
