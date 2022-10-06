using GreenFlamingosApp.Services;

int userInput;
bool userStatus = true;  // false - not logged, true - logged in 
do
{
    MainMenu.Menu(userStatus);

    if (int.TryParse(Console.ReadLine(), out userInput))
    {
       MainMenu.MenuService(userStatus,userInput);
    }
    else
    {
        Console.WriteLine("Twoj wybor nie jest liczbą, Wybierz opcję z przedziału 1-6");
        Console.ReadKey();
    }
} while (userInput != 6);
