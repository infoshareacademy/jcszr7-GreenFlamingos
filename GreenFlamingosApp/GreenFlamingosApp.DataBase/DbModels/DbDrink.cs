using GreenFlamingos.Model;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbDrink
    {
        public int Id { get; set; }
        //public User Author { get; set; }
        //public int AuthorId { get; set; }
        //public float AlcoholContent { get; set; }
        //public int Calories { get; set; }
        //public string DrinkType { get; set; }
        public string Name { get; set; }
        public DbMainIngredient MainIngredient { get; set; }
        public int MainIngredientId { get; set; }
       // public int Capacity { get; set; }
       // //public List<string> Ingredients { get; set; }
       // public string Description { get; set; }
       //// public List<string> Preparation { get; set; }
       // //public IFormFile Photo { get; set; }
       // public string ImageUrl { get; set; }
       // //public List<float> Ratings { get; set; }
       // public float AverageRating { get; set; }
    }
}
