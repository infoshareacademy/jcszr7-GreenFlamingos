using GreenFlamingos.Model.Drinks;
using System.ComponentModel;

namespace GreenFlamingos.Model
{
    public class Preparation
    {
        public int Id { get; set; }
        public string DrinkPreparations { get; set; }
        public Drink Drink { get; set; }
        public int DrinkId { get; set; }
    }
}
