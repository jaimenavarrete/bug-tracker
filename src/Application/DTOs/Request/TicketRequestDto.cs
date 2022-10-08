namespace Application.DTOs.Request
{
    public class TicketRequestDto
    {
        public TicketRequestDto()
        {
            AssignedTagsId = Enumerable.Empty<string>();
        }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string SubmitterId { get; set; } = null!;

        public string StateId { get; set; } = null!;

        public IEnumerable<string> AssignedTagsId { get; set; }

        public string? AssignedUserId { get; set; }

        public DateTime? CompletionDate { get; set; }

        public int? GravityId { get; set; }

        public int? ReproducibilityId { get; set; }

        public int? ClassificationId { get; set; }

        public string? ProjectId { get; set; }
    }
}
