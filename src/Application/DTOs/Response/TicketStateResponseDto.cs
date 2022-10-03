using Application.Common;

namespace Application.DTOs.Response
{
    public class TicketStateResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string ProjectId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;
    }
}
