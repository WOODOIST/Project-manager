using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Profiles
{
    public class PostDynamicProfile : Profile
    {
        public PostDynamicProfile() 
        {
            CreateMap<PostDynamicForCreationDto, PostDynamic>();

            CreateMap<PostDynamic, PostDynamicDto>();
        
        
        }
    }
}
