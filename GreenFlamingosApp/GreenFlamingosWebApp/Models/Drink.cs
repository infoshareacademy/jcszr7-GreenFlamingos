using GreenFlamingos.Model;

namespace GreenFlamingosWebApp.Models
{
    public class Drink
    {
        private int _drinkID;
        public int Id { get { return _drinkID; } set { _drinkID = value; } }
        public User Owner { get; set; }
        public double AlcoholContent { get; set; }
        public int Calories { get; set; }
        public string DrinkType { get; set; }
        public string Name { get; set; }
        public string MainIngredient { get; set; }
        public int Capacity { get; set; }
        public List<string> Ingredients { get; set; }
        public string Description { get; set; }
        public List<string> Preparation { get; set; }
    }
}
