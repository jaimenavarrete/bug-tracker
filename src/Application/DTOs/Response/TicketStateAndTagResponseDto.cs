using Application.Common;

namespace Application.DTOs.Response
{
    public class TicketStateAndTagResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = null!;

        public string ProjectId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;
    }

    public class TicketStateAndTagMiniResponseDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ProjectId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;
    }
}
