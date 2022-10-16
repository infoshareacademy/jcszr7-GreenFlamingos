﻿using GreenFlamingos.Model.Drinks;

namespace GreenFlamingosApp.Services
{
    internal class DrinkBookService
    {
        public List<Drink> DrinkList = new List<Drink>();
        AlcoDrink alcoDrink = new AlcoDrink();
        public DrinkBookService(){}
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

        //Function to add extra ingredients ( max cuantity of ingredients is 3 - can be more, but Drink class has to be changed)
        public string AdditionalIgredient()
        {
            string ingredient;
            Console.WriteLine("Czy chcesz podac dodatkowe skladniki ? (y)");
            string userInput = Console.ReadLine();
            if (string.Equals(userInput, "y"))
            {
                Console.WriteLine("Podaj dodatkowy skladnik:");
                ingredient = Console.ReadLine();
            }
            else
            {
                ingredient = null;
            }

            return ingredient;
        }
        public int Capacity_Check()
        {
            int capacity;
            bool capacityOk = false;
            do
            {
                Console.WriteLine("Podaj Pojemność:");

                if (int.TryParse(Console.ReadLine(), out capacity))
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
                else
                {
                    Console.WriteLine("Podana przez ciebie objetosc nie jest liczba.");
                }
            } while (!capacityOk);

            return capacity;
        }
        public void CreateAlcoDrink(AlcoDrink newAlcoDrink)
        {
            Console.WriteLine("Podaj nazwę drinka:");
            newAlcoDrink.Name = Console.ReadLine();
            Console.WriteLine("Podaj główny składnik drinka:");
            newAlcoDrink.MainIngredient = Console.ReadLine();
            newAlcoDrink.Capacity = Capacity_Check();

            //////Extra Ingredients Service//////////
            newAlcoDrink.Ingredient1 = AdditionalIgredient();
            if (newAlcoDrink.Ingredient1 is null)
                return;
            else
                newAlcoDrink.Ingredient2 = AdditionalIgredient();
            if (newAlcoDrink.Ingredient2 is null)
                return;
            else
                newAlcoDrink.Ingredient3 = AdditionalIgredient();
            return;
        }

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
       
            foreach (var drink in DrinkList)
            {
                drink.ShowDrink();
            }
        }
    }
}