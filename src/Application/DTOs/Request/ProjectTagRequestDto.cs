namespace Application.DTOs.Request
{
    public class ProjectTagRequestDto
    {
        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;
    }
}
