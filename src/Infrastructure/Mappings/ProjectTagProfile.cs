using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class ProjectTagProfile : Profile
    {
        public ProjectTagProfile()
        {
            CreateMap<ProjectTag, TagMiniResponseDto>();
            CreateMap<ProjectTag, ProjectTagResponseDto>();
            CreateMap<ProjectTagRequestDto, ProjectTag>();
        }
    }
}
