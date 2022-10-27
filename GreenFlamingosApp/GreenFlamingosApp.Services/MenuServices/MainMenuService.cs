using GreenFlamingos.Model;
using GreenFlamingos.Model.Drinks;
namespace GreenFlamingosApp.Services.MenuServices
{
    public class MainMenuService
    {
        public UserBookService userBook = new UserBookService();
        public User user = new User();
        public DrinksMenu drinkMenu = new DrinksMenu();
        public AlcoDrink alcoDrink = new AlcoDrink();
        public Shot shot = new Shot();
        public NoAlcoDrink noAlcoDrink = new NoAlcoDrink();
        public void MenuStatus(ref User user, int userInput)
        {
            if (user.UserLevel == UserLevel.unlogged)
            {
                switch (userInput)
                {
                    case 1:
                        user = userBook.LogIn();
                        break;
                    case 2:
                        userBook.AddUser();
                        break;
                    case 3:
                        drinkMenu.DrinkService(alcoDrink, user, userInput);
                        break;
                    case 4:
                        drinkMenu.DrinkService(shot, user, userInput);
                        break;
                    case 5:
                        drinkMenu.DrinkService(noAlcoDrink, user, userInput);
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
                        drinkMenu.DrinkService(alcoDrink,user,userInput);
                        break;
                    case 2:
                        drinkMenu.DrinkService(shot, user,userInput);
                        break;
                    case 3:
                        drinkMenu.DrinkService(noAlcoDrink, user, userInput);
                        break;
                    case 4:
                        userBook.LogOut(user);
                        break;
                    case 5:
                        userBook.AccountService(user);
                        break;
                    case 6:
                        Exit();
                        break;
                }
            }
        }
        public void MenuService(ref User user, int userInput)
        {
            if (userInput > 0 && userInput <= 6)
            {
                MenuStatus(ref user, userInput);
            }
            else
            {
                Console.WriteLine("Podałes liczbe z poza zakresu 1-6");
                Console.ReadKey();
            }
        }
        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Bye!");
        }

    }
}