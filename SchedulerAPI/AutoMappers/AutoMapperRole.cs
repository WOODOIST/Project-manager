using ProjectManagerAPI.Models;
using AutoMapper;
using ProjectManagerAPI.DtoObjects;

namespace ProjectManagerAPI.AutoMappers
{
    public class AutoMapperRole : Profile
    {
        public AutoMapperRole() 
        {
           CreateMap<Role, RoleDto>();
        
        }
    }
}
