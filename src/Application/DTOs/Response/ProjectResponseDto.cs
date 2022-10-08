using Application.Common;
using Domain.Entities;

namespace Application.DTOs.Response
{
    public class ProjectResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string TicketsPrefix { get; set; } = null!;

        public string? OwnerId { get; set; }

        public StateMiniResponseDto State { get; set; } = null!;

        public int TicketsAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public GroupMiniResponseDto? Group { get; set; }

        public IEnumerable<TagMiniResponseDto> AssignedTags { get; set; } = null!;
    }
}
