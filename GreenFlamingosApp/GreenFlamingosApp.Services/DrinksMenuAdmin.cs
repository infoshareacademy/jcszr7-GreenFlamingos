﻿using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services
{
    public class DrinksMenuAdmin
    {
        DrinkBookService drinkBook = new DrinkBookService();

        public void DrinkService()
        {
            int userInput;
            do
            {
                DefaultMenu.DrinkOptions();
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            var newAlcoDrink = new AlcoDrink();
                            drinkBook.CreateAlcoDrink(newAlcoDrink);

                            //Validation of drink name - if in DrinkBookService exists drink with the same name as user set - do not add.
                            var drinkToAdd = drinkBook.DrinkList.Find(d => string.Equals(d.Name.ToUpper(), newAlcoDrink.Name.ToUpper()));
                            if (drinkToAdd != null)
                            {
                                Console.WriteLine("Drink o podanej nazwie istnieje");
                                Console.ReadKey();
                            }
                            else
                            {
                                drinkToAdd = new AlcoDrink(newAlcoDrink.Name,
                                                           newAlcoDrink.Owner,
                                                           newAlcoDrink.MainIngredient,
                                                           newAlcoDrink.Capacity,
                                                           newAlcoDrink.AlcoholContent,
                                                           newAlcoDrink.Calories,
                                                           newAlcoDrink.Ingredients,
                                                           newAlcoDrink.Description,
                                                           newAlcoDrink.Preparation);
                                drinkBook.AddDrink(drinkToAdd);
                                Console.WriteLine("Brawo, Pomyslnie stworzyłeś drinka !");
                                Console.ReadKey();
                            }

                            Console.ReadKey();
                            break;
                        case 2:
                            drinkBook.ShowAllDrinks();
                            Console.ReadKey();
                            break;
                        case 3:
                            drinkBook.RemoveDrink();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Znajdz Drinka");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("Edycja Drinka");
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.WriteLine("Bye");
                            break;
                        case 7:
                            drinkBook.ShowingDrinksWithIngredient();
                            Console.ReadKey();
                            break;
                        case 8:
                            drinkBook.SortByName();
                            Console.ReadKey();
                            break;
                        case 9:
                            drinkBook.ShowingDrinksWithBiggerCapacityThen();
                            Console.ReadKey();
                            break;
                    }
                }
            } while (userInput != 6);
        }

    }
}