using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectTagConfiguration : IEntityTypeConfiguration<ProjectTag>
    {
        public void Configure(EntityTypeBuilder<ProjectTag> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.ColorHexCode).HasMaxLength(7);

            builder.Property(e => e.CreatedBy).HasMaxLength(36);

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.GroupId).HasMaxLength(36);

            builder.Property(e => e.LastModificationDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy).HasMaxLength(36);

            builder.Property(e => e.Name).HasMaxLength(25);

            ConfigureRelationships(builder);
        }

        private static void ConfigureRelationships(EntityTypeBuilder<ProjectTag> builder)
        {
            builder.HasOne(d => d.Group)
                .WithMany(p => p.ProjectTags)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Groups_ProjectTags");
        }
    }
}