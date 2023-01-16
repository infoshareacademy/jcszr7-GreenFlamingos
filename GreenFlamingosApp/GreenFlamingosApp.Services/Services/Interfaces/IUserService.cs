using GreenFlamingos.Model;
using GreenFlamingosApp.DataBase.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        public Task RegisterUser(DbUser user);
        
    }
}
