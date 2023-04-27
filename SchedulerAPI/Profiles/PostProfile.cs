using AutoMapper;
using ProjectManagerAPI.DtoObjects.Incoming;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Profiles
{
    public class PostProfile : Profile
    {
       public PostProfile()
        {
            CreateMap<PostForCreationDto, Post>()
                .ForMember(dest=>dest.Postname, opt=>opt.MapFrom(src=>src.PostName));

            CreateMap<Post, PostDto>()
                .ForMember(dest=>dest.PostName, opt=>opt.MapFrom(src=>src.Postname));
        }
    }
}
