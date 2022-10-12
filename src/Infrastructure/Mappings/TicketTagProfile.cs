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
            CreateMap<TicketTag, TagMiniResponseDto>();
            CreateMap<TicketTag, TicketTagResponseDto>();
            CreateMap<TicketTagRequestDto, TicketTag>();
        }
    }
}
