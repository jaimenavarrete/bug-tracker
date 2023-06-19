using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.CompletionDate).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy).HasMaxLength(36);

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.Description).HasColumnType("text");

            builder.Property(e => e.GroupId).HasMaxLength(36);

            builder.Property(e => e.LastModificationDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy).HasMaxLength(36);

            builder.Property(e => e.Name).HasMaxLength(75);

            builder.Property(e => e.OwnerId).HasMaxLength(36);

            builder.Property(e => e.StartDate).HasColumnType("datetime");

            builder.Property(e => e.StateId).HasMaxLength(36);

            builder.Property(e => e.TicketsPrefix).HasMaxLength(4);


            ConfigureIgnoredFields(builder);

            ConfigureRelationships(builder);
        }

        private static void ConfigureRelationships(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(d => d.Group)
                .WithMany(p => p.Projects)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.SetNull)
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
                    l => l.HasOne<ProjectTag>().WithMany().HasForeignKey("TagId").HasConstraintName("FK_ProjectTags_ProjectTagsAssignment"),
                    r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").HasConstraintName("FK_Projects_ProjectTagsAssignment"),
                    j =>
                    {
                        j.HasKey("ProjectId", "TagId");

                        j.ToTable("ProjectTagsAssignment");

                        j.IndexerProperty<string>("ProjectId").HasMaxLength(36);

                        j.IndexerProperty<string>("TagId").HasMaxLength(36);
                    });
        }

        private static void ConfigureIgnoredFields(EntityTypeBuilder<Project> builder)
        {
            // Ignored columns
            builder.Ignore(e => e.CompletedTicketsCount);
            builder.Ignore(e => e.PendingTicketsCount);
        }
    }
}