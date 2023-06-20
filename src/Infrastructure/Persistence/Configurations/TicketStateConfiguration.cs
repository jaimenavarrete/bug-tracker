using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketStateConfiguration : IEntityTypeConfiguration<TicketState>
    {
        public void Configure(EntityTypeBuilder<TicketState> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.ColorHexCode).HasMaxLength(7);

            builder.Property(e => e.CreatedBy).HasMaxLength(36);

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.LastModificationDate).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy).HasMaxLength(36);

            builder.Property(e => e.Name).HasMaxLength(25);

            builder.Property(e => e.ProjectId).HasMaxLength(36);


            ConfigureRelationships(builder);
        }

        private static void ConfigureRelationships(EntityTypeBuilder<TicketState> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(p => p.TicketStates)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Projects_TicketStates");
        }
    }
}