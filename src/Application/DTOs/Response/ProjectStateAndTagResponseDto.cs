using Application.Common;

namespace Application.DTOs.Response
{
    public class ProjectStateAndTagResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;
    }

    public class ProjectStateAndTagMiniResponseDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;
    }
}
