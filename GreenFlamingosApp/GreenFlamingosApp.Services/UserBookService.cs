using GreenFlamingos.Model;
using GreenFlamingosApp.Services.Validation;
using GreenFlamingosApp.DataBase;
using System.Linq;
namespace GreenFlamingosApp.Services
{
    public class UserBookService
    {
        List<User> users = new List<User>();


        User user = new User();

        public UserBookService()
        {
            users = GreenFlamingosDataBaseService.ReadAllUsers();
        }
        public void AddUser()
        {
            var userRegister = new UserRegister(user);
            user = userRegister.RecordUser();
            var userToAdd = users.FirstOrDefault(u => string.Equals(u.UserMail.ToLower(), user.UserMail.ToLower()));
            if (userToAdd != null)
            {
                Console.WriteLine("Uzytkownik z takim emailem już istnieje");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Gratulacje, udalo ci sie zarejestrować konto");
                users.Add(user);
                user.UserID = users.Count + 100;
                GreenFlamingosDataBaseService.WriteAllUsers(users);
                Console.ReadKey();
            }
        }
        public void ShowAllUsers()
        {
            foreach (var user in users)
            {
                user.ShowUser();
            }
        }
        public User LogIn()
        {
            Console.Clear();
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
                        if(unLoggedUser.UserMail == "admin")
                            unLoggedUser.UserLevel = UserLevel.admin;
                        else
                            unLoggedUser.UserLevel = UserLevel.logged;
                        user = unLoggedUser;
                        break;

                    }
                    else
                    {
                        user.UserLevel = UserLevel.unlogged;
                        Console.WriteLine("Błedne haslo");
                    }
                }
            }
            return user;
        }
        public void LogOut(User user)
        {
            user.UserLevel = UserLevel.unlogged;
        }
        public void AccountService(User user)
        {
            var userValidation = new UserDataValidation(user);
            Console.Clear();
            Console.WriteLine($"Witaj użytkowniku {user.UserMail}. Co chciałbyś zmienić w swoim koncie ?");
            var userInput = 0;
            do
            {
                Console.Clear();
                DefaultMenu.UserAccountService();
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            user.UserMail = userValidation.ValidateEmail();
                            Console.WriteLine("Pomyslnie zmieniles login");
                            break;
                        case 2:
                            user.Password = userValidation.ValidatePassword();
                            Console.WriteLine("Pomyslnie zmieniles login");
                            break;
                    }
                }
            } while (userInput != 3);
        }
    }
}
