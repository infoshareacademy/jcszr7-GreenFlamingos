using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    public static class DrinkProperites
    {
        public enum DrinkProperties
        {
            nazwa,
            glownySkladnik,
            pojemnosc,
            zawartoscAlkoholu,
            kalorie,
            skladniki,
            przepis
        }
        public static void ShowAllDrinkProperites()
        {
            foreach(var item in Enum.GetNames(typeof(DrinkProperties)))
            {
                Console.WriteLine(item);
            }
        }
    }
}
