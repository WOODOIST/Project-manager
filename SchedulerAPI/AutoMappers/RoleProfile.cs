using ProjectManagerAPI.Models;
using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;

namespace ProjectManagerAPI.AutoMappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            
            CreateMap<RoleForCreationDto, Role>()
                .ForMember(destinationMember:dest=>dest.Rolename,
                memberOptions:opt=>opt.MapFrom(src => src.Rolename));


            CreateMap<Role, RoleDto>()
                .ForMember(
                destinationMember:dest=>dest.RoleName,
                memberOptions:opt=>opt.MapFrom(src=>src.Rolename));

        }
    }
}
