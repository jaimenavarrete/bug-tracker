namespace Application.DTOs.Request
{
    public class ProjectRequestDto
    {
        public ProjectRequestDto()
        {
            AssignedTagsId = Enumerable.Empty<string>();
        }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string TicketsPrefix { get; set; } = null!;

        public string? OwnerId { get; set; }

        public string StateId { get; set; } = null!;

        public IEnumerable<string> AssignedTagsId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string? GroupId { get; set; }
    }
}
