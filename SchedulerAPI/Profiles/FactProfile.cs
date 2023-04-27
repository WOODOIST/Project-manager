using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Profiles
{
    public class FactProfile : Profile
    {
        public FactProfile() 
        {
            CreateMap<FactForCreationDto, Fact>();

            CreateMap<Fact,FactDto>();
        
        
        }
    }
}
