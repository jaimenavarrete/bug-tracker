using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(e => e.Description).HasColumnType("text");

            builder.Property(e => e.TicketsPrefix)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(e => e.OwnerId).HasMaxLength(36);

            builder.Property(e => e.StateId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(e => e.TicketsAmount).IsRequired();

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.Property(e => e.CompletionDate).HasColumnType("datetime");

            builder.Property(e => e.GroupId).HasMaxLength(36);

            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(d => d.Group)
                .WithMany(p => p.Projects)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Groups_Projects");

            builder.HasOne(d => d.State)
                .WithMany(p => p.Projects)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectStates_Projects");

            builder.HasMany(d => d.Tags)
                .WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectTagsAssignment",
                    l => l.HasOne<ProjectTag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProjectTags_ProjectTagsAssignment"),
                    r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Projects_ProjectTagsAssignment"),
                    j =>
                    {
                        j.HasKey("ProjectId", "TagId");

                        j.ToTable("ProjectTagsAssignment");

                        j.IndexerProperty<string>("ProjectId").HasMaxLength(36);

                        j.IndexerProperty<string>("TagId").HasMaxLength(36);
                    });
        }
    }
}
