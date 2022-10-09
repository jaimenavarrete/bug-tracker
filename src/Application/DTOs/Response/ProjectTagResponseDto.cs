using Application.Common;

namespace Application.DTOs.Response
{
    public class ProjectTagResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;
    }
}
