using AutoMapper;
using GreenFlamingos.Model.Users;
using GreenFlamingosApp.DataBase.DbModels;

namespace GreenFlamingosApp.Services.Profiles
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
            CreateMap<UserDetails, DbUserDetails>();

            CreateMap<DbUser, User>()
                .ForMember(dest => dest.UserMail,
               opt => opt.MapFrom(src => src.UserMail))
                .ForMember(dest => dest.Password,
                opt => opt.MapFrom(src => src.Password));
            CreateMap<DbUserDetails, UserDetails>();
            //.ForMember(dest => dest.UserDetails);
            //        opt => opt.MapFrom(src => src.UserDetails.Street))
            //.ForMember(dest => dest.UserDetails.PhoneNumber,
            //        opt => opt.MapFrom(src => src.UserDetails.PhoneNumber));


        }

    }
}
