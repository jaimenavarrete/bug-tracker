namespace Domain.Entities
{
    public class Classification
    {
        public Classification()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
