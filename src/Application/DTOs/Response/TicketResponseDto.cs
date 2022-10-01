using Application.Common;

namespace Application.DTOs.Response
{
    public class TicketResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string SubmitterId { get; set; } = null!;

        public StateMiniResponseDto State { get; set; } = null!;

        public string? AssignedUserId { get; set; }

        public DateTime? CompletionDate { get; set; }

        public LookupResponseDto? Gravity { get; set; }

        public LookupResponseDto? Reproducibility { get; set; }

        public LookupResponseDto? Classification { get; set; }

        public string? ProjectId { get; set; }

        public IEnumerable<TagMiniResponseDto> Tags { get; set; } = null!;
    }
}
