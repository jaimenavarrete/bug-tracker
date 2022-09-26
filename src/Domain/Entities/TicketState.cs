using Domain.Common;

namespace Domain.Entities
{
    public partial class TicketState : BaseEntity
    {
        public TicketState()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string Name { get; set; } = null!;

        public string ProjectId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;


        public virtual Project Project { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
