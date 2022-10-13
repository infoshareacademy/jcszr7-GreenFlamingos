using GreenFlamingosApp.DataBase;


namespace GreenFlamingosApp.Services
{
    public class MainMenu
    {
        public UsersBook userBook = new UsersBook();
        public User user = new User();
        public DrinksMenu drinkMenu = new DrinksMenu();
        public void Menu(User user)
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

        public User MenuStatus(int userInput)
        {
            
            if (!user.UserStatus)
            {
                switch (userInput)
                {
                    case 1:
                        user  = userBook.LogIn();
                        break;
                    case 2:
                        userBook.AddUser();
                        break;
                    case 3:
                        Drinks();
                        break;
                    case 4:
                        Shots();
                        break;
                    case 5:
                        Coctails();
                        break;
                    case 6:
                        Exit();
                        break;
                }
            }
            else
            {
                switch (userInput)
                {
                    case 1:
                        Drinks();
                        break;
                    case 2:
                        Shots();
                        break;
                    case 3:
                        Coctails();
                        break;
                    case 4:
                        userBook.LogOut(user);
                        break;
                    case 5:
                        AccountService();
                        break;
                    case 6:
                        Exit();
                        break;
                }
            }
            return user;
        }

        public User MenuService(int userInput)
        {
                if (userInput > 0 && userInput <= 6)
                {
                    user = MenuStatus(userInput);
                }
                else
                {
                    Console.WriteLine("Podałes liczbe z poza zakresu 1-6");
                    Console.ReadKey();
                }
            return user;
        }

        public void Drinks()
        {
            Console.Clear();
            drinkMenu.DrinkService();
            Console.ReadKey();
        }
        public void Shots()
        {
            Console.Clear();
            Console.WriteLine("Shots");
            drinkMenu.DrinkOptions();
            Console.ReadKey();
        }

        public void Coctails()
        {
            Console.Clear();
            Console.WriteLine("Cocktails");
            drinkMenu.DrinkOptions();
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