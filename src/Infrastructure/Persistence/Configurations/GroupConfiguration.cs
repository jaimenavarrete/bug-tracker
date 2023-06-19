using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.CreatedBy).HasMaxLength(36);

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.Description).HasColumnType("text");

            builder.Property(e => e.LastModificationDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy).HasMaxLength(36);

            builder.Property(e => e.Name).HasMaxLength(75);
        }
    }
}