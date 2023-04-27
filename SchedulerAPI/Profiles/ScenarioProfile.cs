using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Profiles
{
    public class ScenarioProfile : Profile
    {
        public ScenarioProfile() 
        {
            CreateMap<ScenarioForCreationDto, Scenario>();

            CreateMap<Scenario, ScenarioDto>();
        
        }
    }
}
