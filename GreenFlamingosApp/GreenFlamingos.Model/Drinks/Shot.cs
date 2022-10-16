using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model.Drinks
{
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
}
