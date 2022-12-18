using GreenFlamingos.Model.Drinks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
       // [DisplayName("Składniki")]
        public string DrinkIngredient { get; set; }
        public Drink Drink { get; set; }
        public int DrinkId { get; set; }
    }
}
