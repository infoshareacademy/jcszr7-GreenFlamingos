using GreenFlamingos.Model.Users;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingos.Model.Drinks
{
    public class Drink : ValidationAttribute
    {
        public int Id { get; set; }
        public User Owner {get; set; }
        [DisplayName("Alkohol content")]
        [Required(ErrorMessage = "Alkohol content is required")]
        [Range(0,99,ErrorMessage ="Enter the alkohol content in the range 0 - 99%")]
        public float AlcoholContent { get; set; }
        [DisplayName("Amount of calories")]
        [Required(ErrorMessage = "Calories are required")]
        public int Calories { get; set; }
        [DisplayName("Type of drink")]
        public string DrinkType { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DisplayName("Main ingredient")]
        [Required(ErrorMessage = "Main ingredient is required")]
        public string MainIngredient { get; set; }
        [DisplayName("Capacity")]
        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
        [DisplayName("Ingredients")]
        public List<Ingredient> Ingredients { get; set; }
        [DisplayName("Description of the drink")]
        public string Description { get; set; }
        [DisplayName("Preparation")]
        public string Preparation { get; set; }
        [DisplayName("Photo")] 
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
        public decimal AverageRating { get; set; }
        public Dictionary<string, string> Comments { get; set; }
    }
}
