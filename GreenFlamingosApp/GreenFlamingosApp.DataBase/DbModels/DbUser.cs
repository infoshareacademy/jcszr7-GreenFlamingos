using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbUser : IdentityUser
    {
        public string Password { get; set; }
        public string UserMail { get; set; }
        public List<DbDrinkUser> DrinkUsers { get; set; }
        public DbUserDetails UserDetails { get; set; }
    }
}
