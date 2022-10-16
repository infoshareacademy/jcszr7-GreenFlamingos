using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model.Drinks
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
            Console.WriteLine($"Oto moj {DrinkType} {Name}");
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
}
