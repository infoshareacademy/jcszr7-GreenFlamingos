using GreenFlamingosApp.DataBase.DbModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingos.Model.Drinks
{
    public class Drink : ValidationAttribute
    {
        public int Id { get; set; }
        public User Owner {get; set; }
        [DisplayName("Zawartość Alkoholu")]
        [Required(ErrorMessage = "Zawartość alkoholu jest wymagana")]
        [Range(0,99,ErrorMessage ="Podaj Zawartość Alkoholu z przedziału 0 - 99%")]
        public float AlcoholContent { get; set; }
        [DisplayName("Ilość Kalori")]
        [Required(ErrorMessage = "Kalorie są wymagane")]
        public int Calories { get; set; }
        [DisplayName("Rodzaj Drinka")]
        public string DrinkType { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }
        [DisplayName("Główny Składnik")]
        [Required(ErrorMessage = "Główny składnik jest wymagany")]
        public string MainIngredient { get; set; }
        [DisplayName("Pojemność")]
        [Required(ErrorMessage = "Pojemność jest wymagana")]
        public int Capacity { get; set; }
        [DisplayName("Składniki")]
        public ICollection<Ingredient> Ingredients { get; set; }
        [DisplayName("Opis Napoju")]
        public string Description { get; set; }
        [DisplayName("Przygotowanie")]
        public string Preparation { get; set; }
        [DisplayName("Zdjęcie")] 
        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
        public List<float> Ratings { get; set; }
        public float AverageRating { get; set; }
    }
}
