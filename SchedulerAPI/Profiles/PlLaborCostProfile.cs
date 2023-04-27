using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Profiles
{
    public class PlLaborCostProfile : Profile
    {
        public PlLaborCostProfile() 
        {
            CreateMap<PlLaborCostForCreationDto, Plannedlaborcost>();

            CreateMap<Plannedlaborcost, PlLaborCostDto>();
        
        }
    }
}
