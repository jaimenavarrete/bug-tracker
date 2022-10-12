using Application.Common;

namespace Application.DTOs.Response
{
    public class TicketTagResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string? ProjectId { get; set; }

        public string ColorHexCode { get; set; } = null!;
    }
}
