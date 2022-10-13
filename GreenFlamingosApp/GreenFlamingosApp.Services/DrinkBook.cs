using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    internal class DrinkBook
    {
        public static List<Drink> DrinkList = new List<Drink>();
        AlcoDrink alcoDrink = new AlcoDrink();
        public DrinkBook(){}
        public void AddDrink(Drink drink)
        {
            DrinkList.Add(drink);
            Console.WriteLine("Drink dodany do książki.\n");
        }

        public void RemoveDrink()
        {
            Console.WriteLine("Który drink z listy chcesz usunąć?");
            int drinkIndex = int.Parse(Console.ReadLine());
            DrinkList.RemoveAt(drinkIndex - 1);
            Console.WriteLine("Drink usunięty z książki.\n");
        }

        public AlcoDrink CreateAlcoDrink()
        {
            Console.WriteLine("Podaj nazwę drinka:");
            var Name = Console.ReadLine();
            Console.WriteLine("Podaj główny składnik drinka:");
            var MainIngredient = Console.ReadLine();
            Console.WriteLine("Podaj objętość drinka:");
            int Capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj składniki:");
            Console.WriteLine("Składnik 1:");
            var Ingredient1 = Console.ReadLine();
            Console.WriteLine("Składnik 2:");
            var Ingredient2 = Console.ReadLine();
            Console.WriteLine("Składnik 3:");
            var Ingredient3 = Console.ReadLine();
            var drinkToAdd = new AlcoDrink(Name, MainIngredient, Capacity, Ingredient1, Ingredient2, Ingredient3);
            return drinkToAdd;

        }
        //public void RemoveDrinksWithIngridient()
        //{
        //    Console.WriteLine("Podaj składnik a wszystkie drinki z tym składkiem zostaną usunięte z książki?");
        //    string drinkIngridient = Console.ReadLine();
        //    DrinkList.RemoveAll(DrinkList, drinkIngridient);
        //    Console.WriteLine("Drink usunięty z książki.\n");
        //}

        public void ClearDrinkBook()
        {
            DrinkList.Clear();
            Console.WriteLine("Wszystkie drinki z książki zostały usunięte.\n");
        }

        public void SortBy(Drink drink)
        {
            DrinkList.Sort();
        }

        public void ShowAllDrinks()
        {
            if (DrinkList.Count == 0)
            {
                Console.WriteLine("Książka jest pusta!");
            }
            int i = 0;
            foreach (var drink in DrinkList)
            {
                i++;
                Console.WriteLine($"{i}. \nNazwa: {drink.Name}.\nGłówny składnik: {drink.MainIngredient}\nObjętość: {drink.Capacity}\n" +
                    $"Składniki: {drink.Ingredient1}\n{drink.Ingredient2}\n{drink.Ingredient3}.\n");
            }
        }
    }
}
