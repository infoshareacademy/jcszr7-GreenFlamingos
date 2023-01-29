using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;
using GreenFlamingosApp.DataBase.DbModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GreenFlamingosApp.DataBase.GreenFlamingosRepository.Identity.Interfaces
{
    public interface IUserAutentication
    {
        public Task<Status> LoginAsync(LoginModel loginModel);
        public Task<Status> RegistrationAsync(Registration registration);
        public Task LogOutAsync();
        public Task<DbUser> GetUserById(Claim userId);
    }
}
