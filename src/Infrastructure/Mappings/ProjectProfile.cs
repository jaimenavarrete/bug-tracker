using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectMiniResponseDto>();
            CreateMap<Project, ProjectResponseDto>()
                .ForMember(dest => dest.AssignedTags, opt => opt.MapFrom(src => src.Tags));
            CreateMap<ProjectRequestDto, Project>()
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => src.AssignedTagsId.Select(tag => new ProjectTag { Id = tag })));
        }
    }
}
