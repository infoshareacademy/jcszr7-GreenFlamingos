using GreenFlamingosApp.DataBase;


namespace GreenFlamingosApp.Services
{
    public class MainMenu
    {
        UsersBook userBook = new UsersBook();
        
        public void Menu(bool userStatus)
        {
            Console.Clear();
            Console.WriteLine("Witaj w aplikacji GreenFlamingos! Wybierz jedną z opcji");
            if (!userStatus)
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
                Console.WriteLine("1.Drinki z alkoholem");
                Console.WriteLine("2.Shoty");
                Console.WriteLine("3.Koktajle");
                Console.WriteLine("4.Wylogowanie");
                Console.WriteLine("5.Dane Konta");
                Console.WriteLine("6.Wyjście");
            }
        }

        public void MenuStatus(ref bool userStatus, int userInput)
        {
            if (!userStatus)
            {
                switch (userInput)
                {
                    case 1:
                        userStatus = userBook.LogIn();
                        break;
                    case 2:
                        userBook.AddUser();
                        Console.ReadKey();
                        break;
                    case 3:
                        MainMenu.Drinks();
                        break;
                    case 4:
                        MainMenu.Shots();
                        break;
                    case 5:
                        MainMenu.Coctails();
                        break;
                    case 6:
                        MainMenu.Exit();
                        break;
                }
            }
            else
            {
                switch (userInput)
                {
                    case 1:
                        MainMenu.Drinks();
                        break;
                    case 2:
                        MainMenu.Shots();
                        break;
                    case 3:
                        MainMenu.Coctails();
                        break;
                    case 4:
                        userStatus = userBook.LogOut();
                        break;
                    case 5:
                        MainMenu.AccountService();
                        break;
                    case 6:
                        MainMenu.Exit();
                        break;
                }
            }

        }

        public void MenuService(ref bool userStatus, int userInput)
        {
                if (userInput > 0 && userInput <= 6)
                {
                    MenuStatus(ref userStatus, userInput);
                }
                else
                {
                    Console.WriteLine("Podałes liczbe z poza zakresu 1-6");
                    Console.ReadKey();
                }
        }

        public static void Drinks()
        {
            Console.Clear();
            Console.WriteLine("Drinks");
            DrinksMenu.DrinkOptions(true);
            Console.ReadKey();
        }
        public static void Shots()
        {
            Console.Clear();
            Console.WriteLine("Shots");
            DrinksMenu.DrinkOptions(true);
            Console.ReadKey();
        }

        public static void Coctails()
        {
            Console.Clear();
            Console.WriteLine("Cocktails");
            DrinksMenu.DrinkOptions(true);
            Console.ReadKey();
        }

        public static void LoginIn()
        {
            Console.Clear();
            Console.WriteLine("Zaloguj sie");
            Console.ReadKey();
        }

        public static void AccountService()
        {
            Console.Clear();
            Console.WriteLine("Dane Konta");
            Console.ReadKey();
        }

        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Bye!");
        }

    }
}