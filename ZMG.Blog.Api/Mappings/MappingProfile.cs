using AutoMapper;
using ZMG.Blog.Core.Dtos;
using ZMG.Blog.Core.Models;

namespace ZMG.Blog.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, LoginRequest>().ReverseMap();
        }
    }
}
