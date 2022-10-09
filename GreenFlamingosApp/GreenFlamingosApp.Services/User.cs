using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GreenFlamingosApp.Services
{
    public class User
    {
        public string Password { get; set; }
        private int _userID;
        public int UserID { get { return _userID; } set { _userID = value; } }
        public string UserMail { get; set; }
        public User() { }
        public User(string password, string userMail)
        {
            Password = password;
            UserMail = userMail;
        }

        public bool UserStatus { get; set; }


        public string EmailValidation()
        {
            bool emailCorrect = false;
            string userMail;
            Regex emailCheck = new Regex(@"^[a-z0-9]+\.?[a-z0-9]+@[a-z]+\.[a-z]{2,3}$");
            Console.WriteLine("Podaj adres email:  ");
            do
            {
                userMail = Console.ReadLine();
                if (emailCheck.IsMatch(userMail))
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
                    Console.WriteLine("Gratulacje, udało ci się zarejestrować konto");
                    passwordCorrect = true;
                }
            } while (!passwordCorrect);
            return password;
        }
            
        public void ShowUser()
        {
            Console.WriteLine($"Login: {UserMail}, haslo: {Password}, ID = {UserID}");
        }
        public User SignUp()
        {
            string userMail = EmailValidation();
            string password = PasswordValidation();
            var user = new User(password,userMail);
            return user;
        }

    }
}
