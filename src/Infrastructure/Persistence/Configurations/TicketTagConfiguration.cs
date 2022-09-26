using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketTagConfiguration : IEntityTypeConfiguration<TicketTag>
    {
        public void Configure(EntityTypeBuilder<TicketTag> builder)
        {
            BaseConfiguration<TicketTag>.ConfigureBaseEntityProperties(builder);

            builder.Property(e => e.Name).HasMaxLength(25);

            builder.Property(e => e.ProjectId).HasMaxLength(36);

            builder.Property(e => e.ColorHexCode).HasMaxLength(7);

            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<TicketTag> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(p => p.TicketTags)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Projects_TicketTags");
        }
    }
}
