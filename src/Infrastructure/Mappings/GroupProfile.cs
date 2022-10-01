using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupMiniResponseDto>();

            CreateMap<Group, GroupResponseDto>();
        }
    }
}
