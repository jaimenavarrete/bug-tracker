using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class TicketStateProfile : Profile
    {
        public TicketStateProfile()
        {
            CreateMap<TicketState, StateAndTagMiniResponseDto>();
            CreateMap<TicketState, TicketStateAndTagMiniResponseDto>();
            CreateMap<TicketState, TicketStateAndTagResponseDto>();
            CreateMap<TicketStateRequestDto, TicketState>();
        }
    }
}
