using Domain.Common;

namespace Domain.Entities
{
    public partial class Project : BaseEntity
    {
        public Project()
        {
            TicketStates = new HashSet<TicketState>();
            TicketTags = new HashSet<TicketTag>();
            Tickets = new HashSet<Ticket>();
            Tags = new HashSet<ProjectTag>();
        }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string TicketsPrefix { get; set; } = null!;

        public string? OwnerId { get; set; }

        public string StateId { get; set; } = null!;

        public int TicketsAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string? GroupId { get; set; }


        public virtual Group? Group { get; set; }

        public virtual ProjectState State { get; set; } = null!;

        public virtual ICollection<TicketState> TicketStates { get; set; }

        public virtual ICollection<TicketTag> TicketTags { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<ProjectTag> Tags { get; set; }
    }
}
