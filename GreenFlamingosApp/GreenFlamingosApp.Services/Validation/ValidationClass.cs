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
            do
            {
                Console.WriteLine("Podaj Pojemność:");
                if (int.TryParse(Console.ReadLine(), out capacity))
                {
                    if (drink.DrinkType == "Drink")
                    {
                        if (capacity >= 100 && capacity <= 500)
                        {
                            capacityOk = true;
                        }
                        else
                        {
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 100 - 500 ml");
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
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 25 - 100 ml");
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
                            Console.WriteLine("Podałes złą wartośc. Dozwolony przedzial to 250 - 1000 ml");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Podana informacja nie jest liczba");
                }
            } while (!capacityOk);

            return capacity;
        }

        public static int ValidateCalories()
        {
            var calories = 0;
            var caloriesOK = false;
            do
            {
                Console.WriteLine("Podaj ilość kalorii drinka: ");
                if (int.TryParse(Console.ReadLine(), out calories))
                {
                        if (calories >= 0 && calories <= 2000)
                        {
                            caloriesOK = true;
                        }
                }
                else
                {
                    Console.WriteLine("Podana informacja nie jest liczba");
                }
            } while (!caloriesOK);
            return calories;
        }

        public static double ValidateAlcoholContent(Drink drink)
        {
            var AlcoholContent = 0;
            var AlcoholContentOK = false;

            
            if (drink.DrinkType != "Drink bezalkoholowy")
            {
                do
                {
                    Console.WriteLine("Podaj zawartość alkoholu w drinku w %: ");
                    if (int.TryParse(Console.ReadLine(), out AlcoholContent))
                    {
                        if (AlcoholContent > 0 && AlcoholContent <= 100)
                        {
                            AlcoholContentOK = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Podana informacja nie jest liczba");
                    }
                } while (!AlcoholContentOK);
            }
            return AlcoholContent;
        }

        public static int ValidateSteps()
        {
            var stepsAmount = 0;
            var stepsAmountOK = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out stepsAmount))
                {
                    stepsAmountOK = true;
                }
                else
                {
                    Console.WriteLine("Podales bledna informacje. Sprobuj jeszcze raz");
                }
            } while (!stepsAmountOK);
            return stepsAmount;
        }
    }
}
