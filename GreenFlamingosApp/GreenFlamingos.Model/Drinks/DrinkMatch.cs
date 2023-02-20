using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingos.Model.Drinks
{
    public class DrinkMatch
    {
        [DisplayName("Main ingredient")]
        [Required(ErrorMessage = "Main ingredient is required")]
        public string MainIngredient { get; set; }
        [DisplayName("Provide additional ingredients")]
        public List<string> Ingredients { get; set; }
    }
}
