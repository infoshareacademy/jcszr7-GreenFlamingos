using GreenFlamingos.Model.Drinks;
namespace GreenFlamingos.Model
{
    public class User
    {
        public string Password { get; set; }
        private int _userID;
        public int UserID { get { return _userID; } set { _userID = value; } }
        public string UserMail { get; set; }
        public User() { }

        public List<Drink> FavoriteDrinks = new List<Drink>();
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
