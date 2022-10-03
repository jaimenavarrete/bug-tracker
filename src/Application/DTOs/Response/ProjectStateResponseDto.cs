using Application.Common;

namespace Application.DTOs.Response
{
    public class ProjectStateResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string GroupId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;
    }
}
