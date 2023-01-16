using GreenFlamingosApp.DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository
{
    public class UserRepository
    {
        private readonly GreenFlamingosDbContext _greenFlamingosDbContext;
        public UserRepository(GreenFlamingosDbContext greenFlamingosDbContext)
        {
            _greenFlamingosDbContext = greenFlamingosDbContext;
        }

        public async Task AddUserToDB(DbUser user)
        {
            await _greenFlamingosDbContext.Users.AddAsync(user); 
        }
    }
}
