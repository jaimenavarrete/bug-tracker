using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Biography { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Address { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
