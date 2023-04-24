using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.AutoMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<UserForCreationDto, User>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Usersurname, opt => opt.MapFrom(src => src.UserSurname))
                .ForMember(dest => dest.Userpatronymic, opt => opt.MapFrom(src => src.UserPatronymic))
                .ForMember(dest => dest.Useremail, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.Userlogin, opt => opt.MapFrom(src => src.UserLogin))
                .ForMember(dest => dest.Userpassword, opt => opt.MapFrom(src => src.UserPassword));
                

            CreateMap<User, UserDto>()

                .ForMember(destinationMember: dest => dest.Rolename,
                memberOptions: opt => opt.MapFrom(src => src.Role.Rolename));


        }

    }
}
