using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketResponseDto>()
                .ForMember(dest => dest.AssignedTags, opt => opt.MapFrom(src => src.Tags));
            CreateMap<TicketRequestDto, Ticket>()
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => src.AssignedTagsId.Select(tag => new TicketTag { Id = tag })));
        }
    }
}
