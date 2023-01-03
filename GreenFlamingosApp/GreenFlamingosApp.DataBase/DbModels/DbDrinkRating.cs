using GreenFlamingos.Model.Drinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbDrinkRating
    {
        public DbDrink Drink { get; set; }
        public int DrinkId { get; set; }
        public DbRating Rating { get; set; }
        public int RatingId { get; set; }


    }
}
