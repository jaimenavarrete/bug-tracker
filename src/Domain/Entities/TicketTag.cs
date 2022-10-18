using Domain.Common;

namespace Domain.Entities
{
    public class TicketTag : BaseEntity
    {
        public TicketTag()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; } = null!;

        public string ProjectId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;


        public Project Project { get; set; } = null!;

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
