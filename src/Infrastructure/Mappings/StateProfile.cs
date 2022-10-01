using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<ProjectState, StateResponseDto>();
            CreateMap<TicketState, StateResponseDto>();
        }
    }
}
