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
            CreateMap<TicketState, StateMiniResponseDto>();
            CreateMap<TicketState, TicketStateResponseDto>();
            CreateMap<TicketStateRequestDto, TicketState>();
        }
    }
}
