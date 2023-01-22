using GreenFlamingosApp.DataBase.DbModels;

namespace GreenFlamingosApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        public Task RegisterUser(DbUser user);
        public Task<DbUser> LoginUser(DbUser user);

    }
}
