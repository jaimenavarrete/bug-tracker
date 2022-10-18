namespace Domain.Entities
{
    public class ActionType
    {
        public ActionType()
        {
            ActivityFlows = new HashSet<ActivityFlow>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ActivityFlow> ActivityFlows { get; set; }
    }
}
