using Domain.Common;

namespace Domain.Entities
{
    public partial class TicketTag : BaseEntity
    {
        public TicketTag()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; } = null!;

        public string? ProjectId { get; set; }

        public string ColorHexCode { get; set; } = null!;


        public virtual Project? Project { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
