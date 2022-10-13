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
            Console.WriteLine("Menu dla drinków:");
            Console.WriteLine();
            Console.WriteLine("1.Dodaj drink");
            Console.WriteLine("2.Pokaż wszystkie drinki");
            Console.WriteLine("3.Usuń drinka");
            Console.WriteLine("4.Znajdź drinka");
            Console.WriteLine("5.Edycja drinka");
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
                            drinkBook.AddDrink(drinkBook.CreateAlcoDrink());
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
        //public static void MenuStatus(bool userStatus, int userInput)
        //{
        //    if (!userStatus)
        //    {
        //        switch (userInput)
        //        {
        //            case 1:
        //                //  MainMenu.LoginIn();
        //                break;
        //            case 2:
        //                //    MainMenu.SignUp();
        //                break;
        //            case 3:
        //                //    MainMenu.Drinks();
        //                break;
        //            case 4:
        //                //   MainMenu.Shots();
        //                break;
        //            case 5:
        //                //    MainMenu.Coctails();
        //                break;
        //            case 6:
        //                MainMenu.Exit();
        //                break;

        //        }
        //    }
    }
}
