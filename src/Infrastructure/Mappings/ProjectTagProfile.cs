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
            CreateMap<ProjectTag, StateAndTagMiniResponseDto>();
            CreateMap<ProjectTag, ProjectStateAndTagMiniResponseDto>();
            CreateMap<ProjectTag, ProjectStateAndTagResponseDto>();
            CreateMap<ProjectTagRequestDto, ProjectTag>();
        }
    }
}
