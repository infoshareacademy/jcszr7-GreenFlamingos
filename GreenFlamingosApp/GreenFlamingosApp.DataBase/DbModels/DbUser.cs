using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbUser
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserMail { get; set; }
        public List<DbDrink> Drinks { get; set; } = new List<DbDrink>();
        //public ICollection<DbDrinkUser> DrinksUsers { get; set; }
        public DbUserDetails UserDetails { get; set; }
    }
}
