using Application.Common;

namespace Application.DTOs.Response
{
    public class GroupResponseDto : BaseResponseDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
