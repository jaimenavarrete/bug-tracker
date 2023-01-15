using Application.Common;

namespace Application.DTOs.Response
{
    public class GroupResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }

    public class GroupMiniResponseDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
