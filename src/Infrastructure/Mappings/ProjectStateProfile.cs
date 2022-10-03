using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class ProjectStateProfile : Profile
    {
        public ProjectStateProfile()
        {
            CreateMap<ProjectState, StateMiniResponseDto>();
            CreateMap<ProjectState, ProjectStateResponseDto>();
        }
    }
}
