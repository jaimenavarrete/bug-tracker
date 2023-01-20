namespace Application.DTOs.Request
{
    public class UserLoginRequestDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
