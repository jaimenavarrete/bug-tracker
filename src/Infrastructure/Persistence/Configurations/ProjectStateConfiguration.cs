using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectStateConfiguration : BaseEntityConfiguration<ProjectState>
    {
        public override void Configure(EntityTypeBuilder<ProjectState> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).HasMaxLength(25);

            builder.Property(e => e.GroupId).HasMaxLength(36);

            builder.Property(e => e.ColorHexCode).HasMaxLength(7);

            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<ProjectState> builder)
        {
            builder.HasOne(d => d.Group)
                .WithMany(p => p.ProjectStates)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_ProjectStates");
        }
    }
}
