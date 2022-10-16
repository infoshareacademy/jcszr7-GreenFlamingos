using GreenFlamingos.Model;
using GreenFlamingosApp.DataBase;


namespace GreenFlamingosApp.Services
{
    public class MainMenuService
    {
        public UserBookService userBook = new UserBookService();
        public User user = new User();
        public DrinksMenu drinkMenu = new DrinksMenu();
        //UserInterface userInterface = new UserInterface();

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
            UserInterface.DrinkOptions();
            Console.ReadKey();
        }

        public void Coctails()
        {
            Console.Clear();
            Console.WriteLine("Cocktails");
            UserInterface.DrinkOptions();
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