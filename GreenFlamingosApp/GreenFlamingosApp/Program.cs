using GreenFlamingosApp.Services;

int userInput;
var mainMenu = new MainMenu();
var user = new User();
do
{
    mainMenu.Menu(user);

    if (int.TryParse(Console.ReadLine(), out userInput))
    {
        user = mainMenu.MenuService(userInput);
    }
    else
    {
        Console.WriteLine("Twoj wybor nie jest liczbą, Wybierz opcję z przedziału 1-6");
        Console.ReadKey();
    }
} while (userInput != 6);
