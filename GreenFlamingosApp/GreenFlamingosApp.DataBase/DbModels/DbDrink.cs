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
        public List<string> Ingredients { get; set; }
        public List<string> Preparations { get; set; }
        public string Description { get; set; }
       // //public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }


       // public DbRating Rating { get; set; }
        //public int RatingId { get; set; }

        // //public List<float> Ratings { get; set; }
        // public float AverageRating { get; set; }
    }
}
