using Domain.Common;

namespace Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket()
        {
            Tags = new HashSet<TicketTag>();
        }

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


        public Classification? Classification { get; set; }

        public GravityLevel? Gravity { get; set; }

        public Project? Project { get; set; }

        public ReproducibilityLevel? Reproducibility { get; set; }

        public TicketState State { get; set; } = null!;

        public IEnumerable<TicketTag> Tags { get; set; }
    }
}
