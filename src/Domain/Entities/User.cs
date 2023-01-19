using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
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

        public string? ProfileImageUrl { get; set; }
    }
}