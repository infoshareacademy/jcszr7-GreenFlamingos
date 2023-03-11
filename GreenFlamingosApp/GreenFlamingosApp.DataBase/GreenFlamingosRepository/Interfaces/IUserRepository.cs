using GreenFlamingosApp.DataBase.DbModels;
using System.Security.Claims;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUserToDB(DbUser user);
        public Task<DbUser> GetUserById(string userId);
        public Task<DbUser> GetUserByLoginForm(DbUser user);
        public Task<List<DbUser>> GetAllUsers();
        public Task DeleteUser(string id);
    }
}
