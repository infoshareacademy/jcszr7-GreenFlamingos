using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbProposedDrinkIngredient
    {
        public DbProposedDrink ProposedDrink { get; set; }
        public int DrinkId { get; set; }
        public DbIngredient Ingredient { get; set; }
        public int IngredientId { get; set; }
        public string IngredientCapacity { get; set; }
    }
}
