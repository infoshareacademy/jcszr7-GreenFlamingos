using GreenFlamingos.Model.Users;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore;
using FluentValidation;
namespace GreenFlamingos.Model.Users
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Błędne hasło")]
        //"* Hasło musi posiadać conajmniej 8 znaków" +
        //"* Hasło mus posiadać conajmniej jedną wielką literę" +
        //"* Hasło musi posiadać conajmniej jedną cyfrę" +
        //"* Hasło musi posiadać conajmniej jeden znak specjalny")]
        public string Password { get; set; }
        [Required]
        public string RepeatedPassword { get; set; }
        [Required]
        [RegularExpression(@"^[a-z0-9]+\.?[a-z0-9]+@[a-z]+\.[a-z]{2,3}$", ErrorMessage = "Błędny adres email")]
        //[Remote("ConfirmPassword","User",AdditionalFields ="Password")]
        public string UserMail { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
