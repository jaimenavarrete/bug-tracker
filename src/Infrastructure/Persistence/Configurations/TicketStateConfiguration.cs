using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketStateConfiguration : BaseEntityConfiguration<TicketState>
    {
        public override void Configure(EntityTypeBuilder<TicketState> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).HasMaxLength(25);

            builder.Property(e => e.ProjectId).HasMaxLength(36);

            builder.Property(e => e.ColorHexCode).HasMaxLength(7);

            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<TicketState> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(p => p.TicketStates)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .HasConstraintName("FK_Projects_TicketStates");
        }
    }
}
