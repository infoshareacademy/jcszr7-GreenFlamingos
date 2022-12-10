using GreenFlamingos.Model;
using GreenFlamingosApp.Services.Validation;
namespace GreenFlamingosApp.Services
{
    public class UserRegister
    {
        private User _user;
        public UserRegister(User user)
        {
            _user = user;
        }

        public User RecordUser()
        {
            var userValidation = new UserDataValidation(_user);
            string userMail = userValidation.ValidateEmail();
            string password = userValidation.ValidatePassword();
            var userToAdd = new User(password, userMail);
            return userToAdd;
        }


    }
}
