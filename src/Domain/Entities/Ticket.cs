using Domain.Common;

namespace Domain.Entities
{
    public partial class Ticket : BaseEntity
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


        public virtual Classification? Classification { get; set; }

        public virtual GravityLevel? Gravity { get; set; }

        public virtual Project? Project { get; set; }

        public virtual ReproducibilityLevel? Reproducibility { get; set; }

        public virtual TicketState State { get; set; } = null!;

        public virtual ICollection<TicketTag> Tags { get; set; }
    }
}
