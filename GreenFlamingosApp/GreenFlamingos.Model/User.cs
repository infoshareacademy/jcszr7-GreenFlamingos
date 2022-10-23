using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingos.Model
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
        public UserLevel UserLevel { get; set; }
        public void ShowUser()
        {
            Console.WriteLine($"Login: {UserMail}, haslo: {Password}, ID = {UserID}");
        }
    }
    public enum UserLevel
    {
        unlogged,
        logged,
        admin,
    }
}
