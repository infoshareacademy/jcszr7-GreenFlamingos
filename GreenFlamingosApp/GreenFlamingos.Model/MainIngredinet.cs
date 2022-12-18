using GreenFlamingos.Model.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model
{
    public class MainIngredinet
    {
        public int Id { get; set; }
        public string DrinkMainIngredient { get; set; }
        public Drink Drink { get; set; }
        public int DrinkId { get; set; }
    }
}
