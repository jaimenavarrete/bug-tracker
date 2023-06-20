using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectStateConfiguration : IEntityTypeConfiguration<ProjectState>
    {
        public void Configure(EntityTypeBuilder<ProjectState> builder)
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

        private static void ConfigureRelationships(EntityTypeBuilder<ProjectState> builder)
        {
            builder.HasOne(d => d.Group)
                .WithMany(p => p.ProjectStates)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Groups_ProjectStates");
        }
    }
}