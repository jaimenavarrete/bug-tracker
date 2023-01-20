namespace Application.DTOs.Response
{
    public class UserResponseDto
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? Biography { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; } = null!;

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public bool PhoneNumberConfirmed { get; set; }

        public string? Address { get; set; }

        public string? ProfileImage { get; set; }
    }

    public class UserMiniResponseDto
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? ProfileImage { get; set; }
    }
}
