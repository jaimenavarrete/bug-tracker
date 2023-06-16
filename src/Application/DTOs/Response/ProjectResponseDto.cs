using Application.Common;

namespace Application.DTOs.Response
{
    public class ProjectResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string TicketsPrefix { get; set; } = null!;

        public string? OwnerId { get; set; }

        public StateAndTagMiniResponseDto State { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public GroupMiniResponseDto? Group { get; set; }

        public int CompletedTicketsCount { get; set; }

        public int PendingTicketsCount { get; set; }

        public IEnumerable<StateAndTagMiniResponseDto> AssignedTags { get; set; } = null!;
    }

    public class ProjectMiniResponseDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string TicketsPrefix { get; set; } = null!;

        public string? OwnerId { get; set; }

        public StateAndTagMiniResponseDto State { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public GroupMiniResponseDto? Group { get; set; }

        public int CompletedTicketsCount { get; set; }

        public int PendingTicketsCount { get; set; }
    }
}
