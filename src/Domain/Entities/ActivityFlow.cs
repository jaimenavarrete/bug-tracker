namespace Domain.Entities
{
    public class ActivityFlow
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int ActionTypeId { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemId { get; set; } = null!;
        public DateTime ActionDate { get; set; }

        public ActionType ActionType { get; set; } = null!;
        public ItemType ItemType { get; set; } = null!;
    }
}
