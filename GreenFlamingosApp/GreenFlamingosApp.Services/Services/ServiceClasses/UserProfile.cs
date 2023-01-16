using AutoMapper;
using GreenFlamingos.Model;
using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;

namespace GreenFlamingosApp.Services.Services.ServiceClasses
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, DbUser>();
        }
       
    }
}
