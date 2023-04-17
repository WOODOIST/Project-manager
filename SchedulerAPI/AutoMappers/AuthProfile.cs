using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.Models;
using System.Runtime.InteropServices;

namespace ProjectManagerAPI.AutoMappers
   
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<AuthUserDto, User>()
                .ForMember(destinationMember: dest => dest.Userlogin,
                memberOptions: opt => opt.MapFrom(src => src.Login))
                .ForMember(destinationMember: dest=> dest.Userpassword,
                memberOptions:opt => opt.MapFrom(src=>src.Password));
        }
    }
}
