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
        public static void MenuStatus(bool userStatus, int userInput)
        {
            if (!userStatus)
            {
                switch (userInput)
                {
                    case 1:
                      //  MainMenu.LoginIn();
                        break;
                    case 2:
                    //    MainMenu.SignUp();
                        break;
                    case 3:
                    //    MainMenu.Drinks();
                        break;
                    case 4:
                    //   MainMenu.Shots();
                        break;
                    case 5:
                    //    MainMenu.Coctails();
                        break;
                    case 6:
                        MainMenu.Exit();
                        break;
                   
                }
            }
        }
    }
}
