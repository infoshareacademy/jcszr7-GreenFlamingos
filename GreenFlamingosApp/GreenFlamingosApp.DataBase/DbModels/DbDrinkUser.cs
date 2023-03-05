using System.ComponentModel.DataAnnotations.Schema;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbDrinkUser
    {
        public DbDrink Drink { get; set; }
        public int DrinkId { get; set; }
        public DbUser User { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public bool IsFavourite { get; set; }

        public string Comment { get; set; }
    }
}
