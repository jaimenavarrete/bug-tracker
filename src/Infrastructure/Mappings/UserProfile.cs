using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserMiniResponseDto>();
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
        }
    }
}
