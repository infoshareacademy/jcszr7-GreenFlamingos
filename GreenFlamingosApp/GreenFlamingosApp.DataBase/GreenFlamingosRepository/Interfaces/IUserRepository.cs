using GreenFlamingosApp.DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUserToDB(DbUser user);
        public Task<DbUser> GetUserById(int id);
        public Task<DbUser> GetUserByLoginForm(DbUser user);
    }
}
