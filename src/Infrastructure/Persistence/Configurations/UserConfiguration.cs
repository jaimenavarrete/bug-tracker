using Infrastructure.Persistence.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.FirstName).HasMaxLength(50);

        builder.Property(e => e.LastName).HasMaxLength(50);

        builder.Property(e => e.Biography).HasMaxLength(1000);

        builder.Property(e => e.BirthDate).HasColumnType("datetime");

        builder.Property(e => e.Address).HasMaxLength(100);

        builder.Property(e => e.ProfileImageUrl).HasMaxLength(100);
    }
}
