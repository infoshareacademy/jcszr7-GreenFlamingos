using GreenFlamingos.Model;
using GreenFlamingosApp.Services.MenuServices;

int userInput;
var mainMenu = new MainMenuService();
//var user = new User("admin","admin");
//user.UserLevel = UserLevel.admin;
var user = new User();

do
{
    DefaultMenu.Menu(user);

    if (int.TryParse(Console.ReadLine(), out userInput))
    {
        mainMenu.MenuService(ref user,userInput);
    }
    else
    {
        Console.WriteLine("Twoj wybor nie jest liczbą, Wybierz opcję z przedziału 1-6");
        Console.ReadKey();
    }
} while (userInput != 6);
