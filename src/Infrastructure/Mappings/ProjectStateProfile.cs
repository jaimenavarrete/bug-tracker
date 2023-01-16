using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class ProjectStateProfile : Profile
    {
        public ProjectStateProfile()
        {
            CreateMap<ProjectState, StateAndTagMiniResponseDto>();
            CreateMap<ProjectState, ProjectStateAndTagMiniResponseDto>();
            CreateMap<ProjectState, ProjectStateAndTagResponseDto>();
            CreateMap<ProjectStateRequestDto, ProjectState>();
        }
    }
}
