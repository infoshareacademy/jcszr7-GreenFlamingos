using GreenFlamingosApp.Services;

int userInput;
bool userStatus = false;  // false - not logged, true - logged in 

var mainMenu = new MainMenu();
do
{
    mainMenu.Menu(userStatus);

    if (int.TryParse(Console.ReadLine(), out userInput))
    {
        mainMenu.MenuService(ref userStatus,userInput);
    }
    else
    {
        Console.WriteLine("Twoj wybor nie jest liczbą, Wybierz opcję z przedziału 1-6");
        Console.ReadKey();
    }
} while (userInput != 6);
