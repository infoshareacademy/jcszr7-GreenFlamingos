using GreenFlamingos.Model;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbDrink
    {
        public int Id { get; set; }
        public DbUser Author { get; set; }
        public int AuthorId { get; set; }
        public float AlcoholContent { get; set; }
        public int Calories { get; set; }
        public DbDrinkType DrinkType { get; set; }
        public int DrinkTypeId { get; set; }
        public string Name { get; set; }
        public DbMainIngredient MainIngredient { get; set; }
        public int MainIngredientId { get; set; }
        public int Capacity { get; set; }
        public ICollection<DbDrinkIngredient> DrinkIngredients { get; set; }
        public ICollection<DbIngredient> Ingredients { get; set; }
        public ICollection<DbDrinkUser> DrinsUsers { get; set; }
        public string Preparations { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
