using Domain.Common;

namespace Domain.Entities
{
    public class Project : BaseEntity
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


        public Group? Group { get; set; }

        public ProjectState State { get; set; } = null!;

        public IEnumerable<TicketState> TicketStates { get; set; }

        public IEnumerable<TicketTag> TicketTags { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }

        public IEnumerable<ProjectTag> Tags { get; set; }
    }
}
