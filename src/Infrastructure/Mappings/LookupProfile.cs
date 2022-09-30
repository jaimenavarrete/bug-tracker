using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class LookupProfile : Profile
    {
        public LookupProfile()
        {
            CreateMap<Classification, LookupResponseDto>();
            CreateMap<GravityLevel, LookupResponseDto>();
            CreateMap<ReproducibilityLevel, LookupResponseDto>();
        }
    }
}
