using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;
using System.Runtime.InteropServices;

namespace ProjectManagerAPI.AutoMappers
{
    public class LaborCostProfile : Profile
    {
        public LaborCostProfile()
        {
            CreateMap<LbrCostForCreationDto, Laborcost>()
                .ForMember(dest => dest.Laborcostname,
                opt => opt.MapFrom(src => src.LaborCostName));

            CreateMap<Laborcost, LaborCostDto>()
                .ForMember(dest => dest.LaborCostName, 
                opt => opt.MapFrom(src => src.Laborcostname));
        }
    }
}
