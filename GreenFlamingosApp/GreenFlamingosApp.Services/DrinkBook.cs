using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GreenFlamingosApp.Services
{
    public class DrinkBook
    {
        public static List<Drink> DrinkList = new List<Drink>();

        public DrinkBook()
        { 
            
        }


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
