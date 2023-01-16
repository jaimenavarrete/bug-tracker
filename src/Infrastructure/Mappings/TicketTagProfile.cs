using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class TicketTagProfile : Profile
    {
        public TicketTagProfile()
        {
            CreateMap<TicketTag, StateAndTagMiniResponseDto>();
            CreateMap<TicketTag, TicketStateAndTagMiniResponseDto>();
            CreateMap<TicketTag, TicketStateAndTagResponseDto>();
            CreateMap<TicketTagRequestDto, TicketTag>();
        }
    }
}
