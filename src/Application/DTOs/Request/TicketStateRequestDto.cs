namespace Application.DTOs.Request
{
    public class TicketStateRequestDto
    {
        public string Name { get; set; } = null!;

        public string ProjectId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;
    }
}
