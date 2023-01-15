namespace Application.DTOs.Response
{
    public class CreationResponseDto
    {
        public CreationResponseDto(string id)
        {
            Id = id;
        }

        public string Id { get; set; } = null!;
    }
}
