﻿using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<ProjectTag, TagMiniResponseDto>();
            CreateMap<TicketTag, TagMiniResponseDto>();
        }
    }
}
