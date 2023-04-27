using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<ProjectForCreationDto, Project>()
                .ForMember(dest => dest.Projectname, opt => opt.MapFrom(src => src.ProjectName))
                .ForMember(dest => dest.Projectcreationdate, opt => opt.MapFrom(src => src.ProjectCreationDate));

            CreateMap<Project, ProjectDto>()
                .ForMember(dest=>dest.ProjectName, opt=>opt.MapFrom(src=>src.Projectname))
                .ForMember(dest=>dest.ProjectCreationDate, opt=>opt.MapFrom(src=>src.Projectcreationdate))
                .ForMember(dest=>dest.ProjectFinishDate, opt=>opt.MapFrom(src=>src.Projectfinishdate));
        
        
        }
    }
}
