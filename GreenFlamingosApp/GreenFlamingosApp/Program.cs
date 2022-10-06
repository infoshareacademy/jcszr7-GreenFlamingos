using GreenFlamingosApp.Services;

int userInput;
bool userStatus = true;  // false - not logged, true - logged in 
do
{
    GreenFlamingosLibrary.Menu(userStatus);

    if (int.TryParse(Console.ReadLine(), out userInput))
    {
       GreenFlamingosLibrary.MenuService(userStatus,userInput);
    }
    else
    {
        Console.WriteLine("Twoj wybor nie jest liczbą, Wybierz opcję z przedziału 1-6");
        Console.ReadKey();
    }

    Console.WriteLine("Test");
} while (userInput != 6);
