using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    internal class DrinksMenu
    {
       
        public static void DrinkOptions(bool userStatus)
        {
            Console.Clear();
            Console.WriteLine("Menu dla drinków:");
            Console.WriteLine();
            Console.WriteLine("1.Dodaj drink");
            Console.WriteLine("2.Pokaż wszystkie drinki");
            Console.WriteLine("3.Usuń drinka");
            Console.WriteLine("4.Znajdź drinka");
            Console.WriteLine("5.Edycja drinka");
            Console.WriteLine("6.Wyjście");
            
        }
        int userInput2 = int.Parse(Console.ReadLine());
        public static void MenuStatus(int userInput2)
        {
                switch (userInput2)
                {
                    case 1:
                        Console.WriteLine("dodaj drink");
                        //DrinkBook.AddDrink(drink);
                        break;
                    case 2:
                        //DrinkBook.ShowAllDrinks();
                        break;
                    case 3:
                        //DrinkBook.RemoveDrink();
                        break;
                    case 4:
                       //DrinkBook.FindDrink(drink);
                        break;
                    case 5:
                       //DrinkBook.EditDrink(drink);
                        break;
                    case 6:
                        MainMenu.Exit();
                        break;
                    default: 
                        Console.WriteLine("Podano wartość spoza zakresu 1-6");
                        break;
                }
        
        }
    }
}
