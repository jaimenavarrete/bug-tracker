using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            BaseConfiguration<Ticket>.ConfigureBaseEntityProperties(builder);

            builder.Property(e => e.Name).HasMaxLength(75);

            builder.Property(e => e.Description).HasColumnType("text");

            builder.Property(e => e.SubmitterId).HasMaxLength(36);

            builder.Property(e => e.StateId).HasMaxLength(36);

            builder.Property(e => e.AssignedUserId).HasMaxLength(36);

            builder.Property(e => e.CompletionDate).HasColumnType("datetime");

            builder.Property(e => e.GravityId).HasColumnType("int");

            builder.Property(e => e.ReproducibilityId).HasColumnType("int");

            builder.Property(e => e.ClassificationId).HasColumnType("int");

            builder.Property(e => e.ProjectId).HasMaxLength(36);
            
            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasOne(d => d.Classification)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ClassificationId)
                .HasConstraintName("FK_Classifications_Tickets");

            builder.HasOne(d => d.Gravity)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.GravityId)
                .HasConstraintName("FK_GravityLevels_Tickets");

            builder.HasOne(d => d.Project)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Projects_Tickets");

            builder.HasOne(d => d.Reproducibility)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ReproducibilityId)
                .HasConstraintName("FK_ReproducibilityLevels_Tickets");

            builder.HasOne(d => d.State)
                .WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketsStates_Tickets");

            builder.HasMany(d => d.Tags)
                .WithMany(p => p.Tickets)
                .UsingEntity<Dictionary<string, object>>(
                    "TicketTagsAssignment",
                    l => l.HasOne<TicketTag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TicketTags_TicketTagsAssignment"),
                    r => r.HasOne<Ticket>().WithMany().HasForeignKey("TicketId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tickets_TicketTagsAssignment"),
                    j =>
                    {
                        j.HasKey("TicketId", "TagId");

                        j.ToTable("TicketTagsAssignment");

                        j.IndexerProperty<string>("TicketId").HasMaxLength(36);

                        j.IndexerProperty<string>("TagId").HasMaxLength(36);
                    });
        }
    }
}
