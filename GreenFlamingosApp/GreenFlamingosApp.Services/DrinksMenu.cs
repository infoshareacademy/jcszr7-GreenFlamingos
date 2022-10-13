using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    public class DrinksMenu
    {
        DrinkBook drinkBook = new DrinkBook();
        public void DrinkOptions()
        {
            Console.Clear();
            Console.WriteLine("Menu dla drinków i koktajli :");
            Console.WriteLine();
            Console.WriteLine("1.Dodaj");
            Console.WriteLine("2.Pokaż wszystkie ");
            Console.WriteLine("3.Usuń ");
            Console.WriteLine("4.Znajdź ");
            Console.WriteLine("5.Edycja ");
            Console.WriteLine("6.Wyjście");           
        }

        public void DrinkService()
        {
            int userInput;   
            do 
            {
                DrinkOptions();
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch(userInput)
                    {
                        case 1:
                            var newAlcoDrink = new AlcoDrink();
                            drinkBook.CreateAlcoDrink(newAlcoDrink);

                            //Validation of drink name - if in DrinkBook exists drink with the same name as user set - do not add.
                            var drinkToAdd = drinkBook.DrinkList.Find(d => string.Equals(d.Name.ToUpper(), newAlcoDrink.Name.ToUpper()));
                            if (drinkToAdd != null)
                            {
                                Console.WriteLine("Drink o podanej nazwie istnieje");
                                Console.ReadKey();
                            }
                            else
                            {
                                drinkToAdd = new AlcoDrink(newAlcoDrink.Name,
                                                           newAlcoDrink.MainIngredient,
                                                           newAlcoDrink.Capacity,
                                                           newAlcoDrink.Ingredient1,
                                                           newAlcoDrink.Ingredient2,
                                                           newAlcoDrink.Ingredient3);
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
                    }
                }
                }while (userInput!=6);
        }
        
    }
}
