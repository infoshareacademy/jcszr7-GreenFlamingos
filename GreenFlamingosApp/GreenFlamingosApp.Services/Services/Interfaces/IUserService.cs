using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using System.Security.Claims;

namespace GreenFlamingosApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        public Task<DbUser> GetUserById(string userId);
        public void SendEmail(string receiver, string userName);
        public Task<List<DbUser>> GetAllUsers();
        public Task DeleteUser(DbUser user);

    }
}
