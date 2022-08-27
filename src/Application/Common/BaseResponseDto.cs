namespace Application.Common
{
    public class BaseResponseDto
    {
        public string Id { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? LastModificationDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
