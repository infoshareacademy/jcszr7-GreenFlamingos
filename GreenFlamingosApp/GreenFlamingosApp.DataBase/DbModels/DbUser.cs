using System.ComponentModel.DataAnnotations;

namespace GreenFlamingosApp.DataBase.DbModels
{
    public class DbUser
    {
        public int Id { get; set; }
        //[Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage ="Błędne hasło")]
        //    //ErrorMessage =$"Błędne hasło \r\n" + 
        //    //               "* Hasło powinno posiadac conajmniej 8 znaków \n\n" + 
        //    //               "* Hasło powinno posiadać conajmniej jedną wielką literę \r\n" + 
        //    //               "* Hasło powinno posiadac conajmniej jedną cyfrę \r\n" +
        //    //               "* Hasło powinno posiadać conajmniej jeden znak specjalny")]
        public string Password { get; set; }
        //[Required]
        //[RegularExpression(@"^[a-z0-9]+\.?[a-z0-9]+@[a-z]+\.[a-z]{2,3}$", ErrorMessage = "Błędny adres email")]
        public string UserMail { get; set; }
        public List<DbDrink> Drinks { get; set; } = new List<DbDrink>();
        public DbUserDetails UserDetails { get; set; }
    }
}
