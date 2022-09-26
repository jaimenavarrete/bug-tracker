namespace Domain.Entities
{
    public partial class Classification
    {
        public Classification()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
