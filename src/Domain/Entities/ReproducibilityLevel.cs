namespace Domain.Entities
{
    public class ReproducibilityLevel
    {
        public ReproducibilityLevel()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
