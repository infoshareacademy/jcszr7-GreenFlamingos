using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbProposedDrink
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DbUser Author { get; set; }
        public int AuthorId { get; set; }
        public float AlcoholContent { get; set; }
        public int Calories { get; set; }
        public DbDrinkType DrinkType { get; set; }
        public int DrinkTypeId { get; set; }
        public DbMainIngredient MainIngredient { get; set; }
        public int MainIngredientId { get; set; }
        public int Capacity { get; set; }
        public List<DbProposedDrinkIngredient> ProposedDrinkIngredients { get; set; }
        public List<DbDrinkUser> DrinkUsers { get; set; }
        public string Preparations { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
