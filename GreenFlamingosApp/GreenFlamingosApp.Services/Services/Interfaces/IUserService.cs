using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using System.Security.Claims;

namespace GreenFlamingosApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        public Task<DbUser> GetUserById(Claim userId);
        public void SendEmail(string receiver, string userName);
        public Task<List<DbUser>> GetAllUsers();

    }
}
