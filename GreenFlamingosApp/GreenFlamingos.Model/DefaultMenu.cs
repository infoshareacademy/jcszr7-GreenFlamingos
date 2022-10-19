using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model
{
    public class DefaultMenu
    {
        public static void Menu(User user)
        {
            Console.Clear();
            Console.WriteLine("Witaj w aplikacji GreenFlamingos! Wybierz jedną z opcji");
            if (!user.UserStatus)
            {

                Console.WriteLine("1.Zaloguj sie");
                Console.WriteLine("2.Zarejestruj konto");
                Console.WriteLine("3.Drinki z alkoholem");
                Console.WriteLine("4.Shoty");
                Console.WriteLine("5.Koktajle");
                Console.WriteLine("6.Wyjście");
            }
            else
            {
                Console.WriteLine($"Witaj {user.UserMail}");
                Console.WriteLine("1.Drinki z alkoholem");
                Console.WriteLine("2.Shoty");
                Console.WriteLine("3.Koktajle");
                Console.WriteLine("4.Wylogowanie");
                Console.WriteLine("5.Dane Konta");
                Console.WriteLine("6.Wyjście");
            }
        }

        //Niezalogowany uzytkownik nie moze dodac/usunac/edytowac drinka
        public static void DrinkOptions()
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
    }
}
