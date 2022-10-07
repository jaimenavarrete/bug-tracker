namespace Application.DTOs.Response
{
    public class MiniResponseDto
    {
        public MiniResponseDto(string id)
        {
            Id = id;
        }

        public string Id { get; set; } = null!;
    }
}
