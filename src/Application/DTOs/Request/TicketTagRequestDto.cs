namespace Application.DTOs.Request
{
    public class TicketTagRequestDto
    {
        public string Name { get; set; } = null!;

        public string? ProjectId { get; set; }

        public string ColorHexCode { get; set; } = null!;
    }
}
