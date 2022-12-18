using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenFlamingos.Model.Drinks
{
    public class Drink
    {
        public int Id { get; set; }
        public User Owner {get; set; }
        public int OwnerId { get;set; }


      //  [DisplayName("Zawartość Alkoholu")]
       // [Required(ErrorMessage = "Zawartość alkoholu jest wymagana")]
      //  [Range(0,99,ErrorMessage ="Podaj Zawartość Alkoholu z przedziału 0 - 99%")]
        public float AlcoholContent { get; set; }

    //    [DisplayName("Ilość Kalori")]
     //   [Required(ErrorMessage = "Kalorie są wymagane")]
        public int Calories { get; set; }

      //  [DisplayName("Rodzaj Drinka")]
        public string DrinkType { get; set; }

    //    [DisplayName("Nazwa")]
      //  [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        public MainIngredinet MainIngredient { get; set; }
        public int MainIngredientId { get; set; }

      //  [DisplayName("Pojemność")]
      //  [Required(ErrorMessage = "Pojemność jest wymagana")]
        public int Capacity { get; set; }
        //[DisplayName("Składniki")]
        //public List<string> Ingredient { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int IngredientsId { get; set; }

     //   [DisplayName("Opis Napoju")]
        public string Description { get; set; }
        //public List<string> Preparation { get; set; }
        public List<Preparation> Preparations { get; set; }
        public int PreparationsId { get; set; }
        //  [DisplayName("Zdjęcie")] 
        //  [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public List<float> Ratings { get; set; }
        public float AverageRating { get; set; }
    }
}
