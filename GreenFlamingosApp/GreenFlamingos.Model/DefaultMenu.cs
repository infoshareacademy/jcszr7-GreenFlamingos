namespace GreenFlamingos.Model
{
    public class DefaultMenu
    {
        public static void Menu(User user)
        {
            Console.Clear();
            Console.WriteLine("Witaj w aplikacji GreenFlamingos! Wybierz jedną z opcji");
            if (user.UserLevel == UserLevel.unlogged)
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

        public static void DrinkOptions(User user)
        {
            if (user.UserLevel == UserLevel.logged)
            {
                Console.Clear();
                Console.WriteLine("Menu dla drinków i koktajli :");
                Console.WriteLine();
                Console.WriteLine("1.Dodaj");
                Console.WriteLine("2.Pokaż wybranego");
                Console.WriteLine("3.Pokaż wszystkie ");
                Console.WriteLine("4.Usuń ");
                Console.WriteLine("5.Dopasuj Drinka");
                Console.WriteLine("6.Edycja ");
                Console.WriteLine("7.Ulubione ");
                Console.WriteLine("8.Wyjście");
            }
            else if(user.UserLevel == UserLevel.admin)
            {
                Console.Clear();
                Console.WriteLine("Menu dla drinków i koktajli :");
                Console.WriteLine();
                Console.WriteLine("1.Dodaj");
                Console.WriteLine("2.Pokaż wszystkie ");
                Console.WriteLine("3.Usuń ");
                Console.WriteLine("4.Znajdź ");
                Console.WriteLine("5.Edycja ");
                Console.WriteLine("6.Edycja bazy danych");
                Console.WriteLine("7.Wyjście");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Menu dla drinków i koktajli :");
                Console.WriteLine();
                Console.WriteLine("1.Pokaż wszystkie ");
                Console.WriteLine("2.Znajdź ");
                Console.WriteLine("3.Wyjście");
            }

        }

        public static void AdminDataBaseOptions()
        {
            Console.Clear();
            Console.WriteLine("Co chcesz zrobić z bazą danych ? ");
            Console.WriteLine("1.Dodaj składnik");
            Console.WriteLine("2.Usun składnik");
            Console.WriteLine("3.Wyswietl dostępne składniki");
            Console.WriteLine("4.Wstecz");
        }

        public static void UserAccountService()
        {
            Console.WriteLine("1.Zmiana loginu");
            Console.WriteLine("2.Zmiana hasla");
            Console.WriteLine("3.Wstecz");
        }
    }
}
