using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GreenFlamingosApp.Services
{
    public class UserDataValidation
    {
        private User _user;
        public UserDataValidation(User user)
        {
            _user = user;
        }
        public string EmailValidation()
        {
            bool emailCorrect = false;
            string userMail;
            Regex emailCheck = new Regex(@"^[a-z0-9]+\.?[a-z0-9]+@[a-z]+\.[a-z]{2,3}$");
            Console.WriteLine("Podaj adres email:  ");
            do
            {
                userMail = Console.ReadLine();
                if (emailCheck.IsMatch(userMail.ToLower()))
                {
                    emailCorrect = true;
                }
                else
                {
                    Console.WriteLine("Błędny adres email. Sprobuj jeszcze raz.");
                }

            } while (!emailCorrect);
            return userMail;
        }

        public string PasswordValidation()
        {
            bool passwordCorrect = false;
            string password;
            Regex passwordCheck = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z]*|[a-zA-Z0-9]*)$"); // 8 znakow, jedna duza litera, jeden znak specjalny // Regex z wykorzystaniem negacji tych zalozen
            do
            {
                Console.WriteLine("Podaj haslo:");
                password = Console.ReadLine();
                if (passwordCheck.IsMatch(password))
                {
                    Console.WriteLine("Haslo nie spelnia zalozen - minimum 8 znaków, jedne znak specjalny, jedna liczba, jedna duża Litera. Sprobuj jeszcze raz.");
                }
                else
                {
                    passwordCorrect = true;
                }
            } while (!passwordCorrect);
            return password;
        }
    }
}
