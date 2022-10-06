using GreenFlamingosApp.DataBase;


namespace GreenFlamingosApp.Services
{
    public class MainMenu
    {
        public static void Menu(bool userStatus)
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

        public static void MenuStatus(bool userStatus, int userInput)
        {
            if (!userStatus)
            {
                switch (userInput)
                {
                    case 1:
                        MainMenu.LoginIn();
                        break;
                    case 2:
                        MainMenu.SignUp();
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
                        MainMenu.LogOut();
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

        public static void MenuService(bool userStatus, int userInput)
        {
            

                if (userInput > 0 && userInput <= 6)
                {
                    MenuStatus(userStatus, userInput);
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
            Console.ReadKey();
        }
        public static void Shots()
        {
            Console.Clear();
            Console.WriteLine("Shots");
            Console.ReadKey();
        }

        public static void Coctails()
        {
            Console.Clear();
            Console.WriteLine("Cocktails");
            Console.ReadKey();
        }

        public static void LoginIn()
        {
            Console.Clear();
            Console.WriteLine("Zaloguj sie");
            Console.ReadKey();
        }

        public static void SignUp()
        {
            Console.Clear();
            Console.WriteLine("Zarejestruj sie");
            Console.ReadKey();
        }

        public static void LogOut()
        {
            Console.Clear();
            Console.WriteLine("Wyloguj sie");
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