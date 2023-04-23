using AutoMapper;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.AutoMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {


            CreateMap<User, UserDto>()

                .ForMember(destinationMember: dest => dest.RoleName,
                memberOptions: opt => opt.MapFrom(src => src.Role.Rolename));
                
        
        }

    }
}
