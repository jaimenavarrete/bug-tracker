namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? LastModificationDate { get; set; }

        public string? ModifiedBy { get; set; }

        public bool AddCreationInfo(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            CreationDate = DateTime.UtcNow;
            CreatedBy = userId;

            return true;
        }

        public bool UpdateModificationInfo(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException(nameof(userId));

            LastModificationDate = DateTime.UtcNow;
            ModifiedBy = userId;

            return true;
        }
    }
}
