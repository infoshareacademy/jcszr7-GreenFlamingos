using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.GreenFlamingosRepository;
using GreenFlamingosApp.Services.Services.Interfaces;

namespace GreenFlamingosApp.Services.Services.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUser(DbUser user)
        {
            await _userRepository.AddUserToDB(user);
        }
    }
}
