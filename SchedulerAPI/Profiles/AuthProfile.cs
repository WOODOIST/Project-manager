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
            CreateMap<AuthUserDto, User>();
               
        }
    }
}
