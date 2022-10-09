using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services
{
    public class UsersBook
    {
        List<User> users = new List<User>();

        public void AddUser()
        {
            var user = new User();
            user = user.SignUp();
            users.Add(user);
            Random random = new Random();
            user.UserID = users.Count + 100;
        }

        public void ShowAllUsers()
        {
            foreach(var user in users)
            {
                user.ShowUser();
            }
        }

        public bool LogIn()
        {
            bool userLogged = false;
            Console.WriteLine("Podaj Login");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj haslo");
            string password = Console.ReadLine();
            foreach (var user in users)
            {
                if (string.Equals(user.UserMail, login))
                {
                    if (string.Equals(user.Password, password))
                    {
                        Console.WriteLine($"Witaj użytkowniku {user.UserMail}");
                        Console.ReadLine();
                        userLogged = true;
                    }
                    else
                    {
                        userLogged = false;
                        Console.WriteLine("Błedne haslo");
                    }
                }
            }
            return userLogged;
        }

    }
}
