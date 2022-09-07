using Application.Common;

namespace Application.DTOs
{
    public class ProjectResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? OwnerId { get; set; }

        public string StateId { get; set; } = null!;

        public int MilestonesAmount { get; set; }

        public int TicketsAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string? GroupId { get; set; }
    }
}
