using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    public abstract class Drink
    {
        public string DrinkType { get; set; }
        public string Name { get; set; }
        public string MainIngredient { get; set; }
        public int Capacity { get; set; }
        public string Ingredient1 { get; set; }
        public string Ingredient2 { get; set; }
        public string Ingredient3 { get; set; }

        public virtual void ShowIngredients()
        {
            Console.WriteLine($"Oto moj {DrinkType} + {Name}");
            Console.WriteLine("Składniki:");
            Console.WriteLine($"Głowny składnik: {MainIngredient}");
            Console.WriteLine($"Pojemnosc: {Capacity}");

            ////// Below is checking that drink has optional igredients///////////
            if (!string.IsNullOrEmpty(Ingredient1))
            {
                Console.WriteLine($"Skladnik 1: {Ingredient1}");
            }
            if (!string.IsNullOrEmpty(Ingredient2))
            {
                Console.WriteLine($"Skladnik 2: {Ingredient2}");
            }
            if (!string.IsNullOrEmpty(Ingredient3))
            {
                Console.WriteLine($"Skladnik 3: {Ingredient3}");
            }
        }

        public virtual void ShowRecipe()
        {
            Console.WriteLine("Przygotowanie: ");
            Console.WriteLine("Jakis przepis");         /////Here will show recipe from user
        }

        public virtual void ShowDrink()
        {
                ShowIngredients();
                ShowRecipe();
        }

    }

    public class AlcoDrink : Drink
    {
        public AlcoDrink() {}
        public AlcoDrink(string name, string mainIgredient, int capacity)
        {
            DrinkType = "Drink";
            Name = name;
            MainIngredient = mainIgredient;

            if (capacity < 100 || capacity > 500)
                throw new ArgumentOutOfRangeException();
            else
                Capacity = capacity;
        }

        public AlcoDrink(string name, string mainIgredient, int capacity, string igredient1) : this(name, mainIgredient, capacity)
        {
            Ingredient1 = igredient1;
        }
        public AlcoDrink(string name, string mainIgredient, int capacity, string igredient1, string igredient2) : this(name, mainIgredient, capacity, igredient1)
        {
            Ingredient2 = igredient2;
        }
        public AlcoDrink(string name, string mainIgredient, int capacity, string igredient1, string igredient2, string igredient3) : this(name, mainIgredient, capacity, igredient1, igredient2)
        {
            Ingredient3 = igredient3;
        }
    }
    public class Shot : Drink
    {
        public Shot(string name, string mainIgredient, int capacity)
        {
            DrinkType = "Shot";
            Name = name;
            MainIngredient = mainIgredient;

            if (capacity < 25 || capacity > 100)
                throw new ArgumentOutOfRangeException();
        }

        public Shot(string name, string mainIgredient, int capacity, string igredient1) : this(name, mainIgredient, capacity)
        {
            Ingredient1 = igredient1;
        }
        public Shot(string name, string mainIgredient, int capacity, string igredient1, string igredient2) : this(name, mainIgredient, capacity, igredient1)
        {
            Ingredient2 = igredient2;
        }
        public Shot(string name, string mainIgredient, int capacity, string igredient1, string igredient2, string igredient3) : this(name, mainIgredient, capacity, igredient1, igredient2)
        {
            Ingredient3 = igredient3;
        }
    }

    public class NoAlcoDrink : Drink
    {
        public NoAlcoDrink(string name, string mainIgredient, int capacity)
        {
            DrinkType = "Drink bezalkoholowy";
            Name = name;
            MainIngredient = mainIgredient;

            if (capacity < 25 || capacity > 100)
                throw new ArgumentOutOfRangeException();
        }
        public NoAlcoDrink(string name, string mainIgredient, int capacity, string igredient1) : this(name, mainIgredient, capacity)
        {
            Ingredient1 = igredient1;
        }
        public NoAlcoDrink(string name, string mainIgredient, int capacity, string igredient1, string igredient2) : this(name, mainIgredient, capacity, igredient1)
        {
            Ingredient2 = igredient2;
        }
        public NoAlcoDrink(string name, string mainIgredient, int capacity, string igredient1, string igredient2, string igredient3) : this(name, mainIgredient, capacity, igredient1, igredient2)
        {
            Ingredient3 = igredient3;
        }
    }

}
