using Application.Common;
using Domain.Entities;

namespace Application.DTOs.Response
{
    public class TicketResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string SubmitterId { get; set; } = null!;

        public string StateId { get; set; } = null!;

        public string? AssignedUserId { get; set; }

        public DateTime? CompletionDate { get; set; }

        public int? GravityId { get; set; }

        public int? ReproducibilityId { get; set; }

        public int? ClassificationId { get; set; }

        public string? ProjectId { get; set; }

        public IEnumerable<TicketTag> Tags { get; set; } = null!;
    }
}
