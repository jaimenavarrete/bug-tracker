using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketTagConfiguration : BaseEntityConfiguration<TicketTag>
    {
        public override void Configure(EntityTypeBuilder<TicketTag> builder)
        {
            base.Configure(builder);

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
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("FK_Projects_TicketTags");
        }
    }
}
