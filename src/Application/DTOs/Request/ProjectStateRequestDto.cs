namespace Application.DTOs.Request
{
    public class ProjectStateRequestDto
    {
        public string Name { get; set; } = null!;

        public string GroupId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;
    }
}
