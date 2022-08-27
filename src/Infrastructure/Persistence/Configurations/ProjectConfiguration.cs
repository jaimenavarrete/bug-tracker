using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CompletionDate).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.GroupId).HasMaxLength(36);

            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.LastModificationDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy).HasMaxLength(36);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(e => e.OwnerId).HasMaxLength(36);

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.Property(e => e.StateId)
                .IsRequired()
                .HasMaxLength(36);
        }
    }
}
