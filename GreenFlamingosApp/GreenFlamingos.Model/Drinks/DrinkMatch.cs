using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingos.Model.Drinks
{
    public class DrinkMatch
    {
        [DisplayName("Główny Składnik")]
        [Required(ErrorMessage = "Główny składnik jest wymagany")]
        public string MainIngredient { get; set; }
        [DisplayName("Podaj Składniki Dodatkowe")]
        public List<string> Ingredients { get; set; }
    }
}
