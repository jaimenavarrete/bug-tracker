namespace Application.DTOs.Request
{
    public class LoginUserRequestDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
