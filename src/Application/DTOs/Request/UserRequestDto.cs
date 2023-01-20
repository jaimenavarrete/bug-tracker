namespace Application.DTOs.Request
{
    public class UserRequestDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Biography { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        public string? ProfileImage { get; set; }
    }
}
