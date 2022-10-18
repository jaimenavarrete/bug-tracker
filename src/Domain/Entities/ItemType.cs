namespace Domain.Entities
{
    public class ItemType
    {
        public ItemType()
        {
            ActivityFlows = new HashSet<ActivityFlow>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ActivityFlow> ActivityFlows { get; set; }
    }
}
