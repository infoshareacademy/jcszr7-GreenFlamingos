using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model.Drinks
{
    public abstract class Drink
    {
        private int _drinkID;
        public int DrinkID { get { return _drinkID; } set { _drinkID = value; } }
        public User Owner { get; set; }
        public double AlcoholContent { get; set; }
        public int Calories { get; set; }
        public string DrinkType { get; set; }
        public string Name { get; set; }
        public string MainIngredient { get; set; }
        public int Capacity { get; set; }
        public List<string> Ingredients { get; set; }
        public string Description { get; set; }
        public List<string> Preparation { get; set; }

        public virtual void ShowIngredients()
        {
            Console.WriteLine($"Oto mój {DrinkType}, {Name}\n" +
                $"Twórca: {Owner.UserMail}\n" +
                $"Zawartość alkoholu: {AlcoholContent}%\n" +
                $"Kalorie: {Calories}\n" +
                $"Pojemność: {Capacity}\n" +
                $"Składnik główny: {MainIngredient}\n" +
                $"Pozostałe składniki:");
            foreach (string ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient}");
            }
            Console.WriteLine($"\nOpis Drinka:\n" +
                $"{Description}\n");
        }

        public virtual void ShowRecipe()
        {
            Console.WriteLine("Przyrządzenie:");
            foreach (string step in Preparation)
            {
                Console.WriteLine($" - {step}");
            }
        }

        public void ShowDrink()
        {
            ShowIngredients();
            ShowRecipe();
        }

    }
}
