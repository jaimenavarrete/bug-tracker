using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Common
{
    public static class BaseConfiguration<T> where T : BaseEntity
    {
        public static void ConfigureBaseEntityProperties(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(e => e.LastModificationDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy).HasMaxLength(36);
        }
    }
}
