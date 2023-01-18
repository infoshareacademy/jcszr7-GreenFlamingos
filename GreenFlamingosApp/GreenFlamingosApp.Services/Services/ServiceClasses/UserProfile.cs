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
            CreateMap<User, DbUser>()
                .ForMember(dest => dest.UserMail,
                           opt => opt.MapFrom(src => src.UserMail))
                .ForMember(dest => dest.Password,
                            opt => opt.MapFrom(src => src.Password));
                //.ForMember(dest => dest.UserDetails.City,
                //            opt => opt.MapFrom(src => src.UserDetails.City))
                //.ForMember(dest => dest.UserDetails.Street,
                //            opt => opt.MapFrom(src => src.UserDetails.Street))
                //.ForMember(dest => dest.UserDetails.PhoneNumber,
                //            opt => opt.MapFrom(src => src.UserDetails.PhoneNumber));


        }

    }
}
