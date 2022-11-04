using GreenFlamingos.Model.Drinks;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GreenFlamingosApp.Services.Validation
{
    public static class ValidationClass
    {
        public static int ValidateCapacity(Drink drink)
        {
            var capacity = 0;
            var capacityOk = false;
            var userInput = "";
            do
            {
                Console.WriteLine("Podaj Pojemność:");
                userInput = Console.ReadLine();
                if(string.Equals(userInput,"x",StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (int.TryParse(userInput, out capacity))
                {
                    if (drink.DrinkType == "Drink")
                    {
                        if (capacity >= 100 && capacity <= 500)
                        {
                            capacityOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 100 - 500 ml. Spróbuj ponownie lub wcisnij 'x'");
                        }
                    }
                    else if (drink.DrinkType == "Shot")
                    {
                        if (capacity >= 25 && capacity <= 100)
                        {
                            capacityOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 25 - 100 ml. Spróbuj ponownie lub wcisnij 'x'");
                        }
                    }
                    else
                    {
                        if (capacity >= 250 && capacity <= 1000)
                        {
                            capacityOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 250 - 1000 ml. Spróbuj ponownie lub wcisnij 'x'");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Podana informacja nie jest liczba. Spróbuj ponownie lub wcisnij 'x'");
                }
            } while (!capacityOk);

            return capacity;
        }
        public static int ValidateCalories()
        {
            var calories = 0;
            var caloriesOK = false;
            var userInput = "";
            do
            {
                Console.WriteLine("Podaj ilość kalorii drinka: ");
                userInput = Console.ReadLine();
                if (string.Equals(userInput, "x", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (int.TryParse(userInput, out calories))
                {
                        if (calories >= 0 && calories <= 2000)
                        {
                            caloriesOK = true;
                        }
                        else
                        {
                        Console.WriteLine("Podałes liczbe z poza zakresu 0 - 2000 kcal. Spróbuj ponownie lub wcisnij 'x'");
                        }
                }
                else
                {
                    Console.WriteLine("Podana informacja nie jest liczba. Spróbuj ponownie lub wcisnij 'x'");
                }
            } while (!caloriesOK);
            return calories;
        }
        public static double ValidateAlcoholContent(Drink drink)
        {
            var AlcoholContent = 0.0;
            var AlcoholContentOK = false;
            var userInput = "";
            if (drink.DrinkType != "Drink bezalkoholowy")
            {
                do
                {
                    Console.WriteLine("Podaj zawartość alkoholu w drinku w %: ");
                    userInput = Console.ReadLine();
                    if (string.Equals(userInput, "x", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    if (double.TryParse(userInput, out AlcoholContent))
                    {
                        if (AlcoholContent > 0 && AlcoholContent < 100)
                        {
                            AlcoholContentOK = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes liczbe z poza zakresu 0 - 100%. Spróbuj ponownie lub wcisnij 'x'");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podana informacja nie jest liczba. Spróbuj ponownie lub wcisnij 'x'");
                    }
                } while (!AlcoholContentOK);
            }
            return AlcoholContent;
        }
        public static int ValidateSteps()
        {
            var stepsAmount = 0;
            var stepsAmountOK = false;
            var userInput = "";
            
            do
            {
                userInput = Console.ReadLine();
                if (string.Equals(userInput, "x", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (int.TryParse(userInput, out stepsAmount))
                {
                    if(stepsAmount <= 5)
                        stepsAmountOK = true;
                    else
                    {
                        stepsAmount = 0;
                        Console.WriteLine("Maksymalna ilosc to 5. Spróbuj ponownie lub wcisnij 'x'");
                    }
                        
                }
                else
                {
                    Console.WriteLine("Podales bledna informacje. Spróbuj ponownie lub wcisnij 'x'");
                }
            } while (!stepsAmountOK);
            return stepsAmount;
        }
    }
}
