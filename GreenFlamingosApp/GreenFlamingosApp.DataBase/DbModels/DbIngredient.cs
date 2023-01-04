using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DbDrinkIngredient> DrinkIngredients { get; set; }


    }
}
