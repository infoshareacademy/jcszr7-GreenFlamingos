using GreenFlamingos.Model.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
