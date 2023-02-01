using GreenFlamingosApp.DataBase.DbModels;
using System.Security.Claims;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUserToDB(DbUser user);
        public Task<DbUser> GetUserById(Claim userId);
        public Task<DbUser> GetUserByLoginForm(DbUser user);
    }
}
