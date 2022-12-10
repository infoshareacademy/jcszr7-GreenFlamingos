using GreenFlamingos.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingosWebApp.Models
{
    public class Drink : ValidationAttribute
    {
        private int _drinkID;
        public int Id { get { return _drinkID; } set { _drinkID = value; } }
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
        public List<string> Ingredients { get; set; }
        [DisplayName("Opis Napoju")]
        public string Description { get; set; }
        //public List<string> Preparation { get; set; }
        public List<string> Preparation { get; set; }
        [DisplayName("Zdjęcie")]
        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
