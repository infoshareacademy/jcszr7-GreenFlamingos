using GreenFlamingos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    public class UserBookService
    {
        List<User> users = new List<User>();
        User user = new User();

        public void AddUser()
        {
            var userRegister = new UserRegister(user);
            user = userRegister.RecordUser();

            var userToAdd = users.FirstOrDefault(d => string.Equals(d.UserMail.ToLower(), user.UserMail.ToLower()));

            if (userToAdd != null)
            {
                Console.WriteLine("Uzytkownik z takim emailem już istnieje");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Gratulacje, udalo ci sie zarejestrować konto");
                Console.ReadKey();
                users.Add(user);
                user.UserID = users.Count + 100;
            }
        }

        public void ShowAllUsers()
        {
            foreach(var user in users)
            {
                user.ShowUser();
            }
        }

        public User LogIn()
        {
            Console.WriteLine("Podaj Login");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj haslo");
            string password = Console.ReadLine();
            foreach (var unLoggedUser in users)
            {
                if (string.Equals(unLoggedUser.UserMail.ToLower(), login.ToLower()))
                {
                    if (string.Equals(unLoggedUser.Password, password))
                    {
                        Console.WriteLine($"Witaj użytkowniku {unLoggedUser.UserMail}");
                        Console.ReadLine();
                        unLoggedUser.UserStatus = true;
                        user = unLoggedUser;
                        break;
                        
                    }
                    else
                    {
                        user.UserStatus = false;
                        Console.WriteLine("Błedne haslo");
                    }
                }
            }
            return user;
        }

        public void LogOut(User user)
        {
            user.UserStatus = false;
        }

    }
}
