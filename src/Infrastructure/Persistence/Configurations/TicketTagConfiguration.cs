using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TicketTagConfiguration : IEntityTypeConfiguration<TicketTag>
    {
        public void Configure(EntityTypeBuilder<TicketTag> builder)
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

        private static void ConfigureRelationships(EntityTypeBuilder<TicketTag> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(p => p.TicketTags)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Projects_TicketTags");
        }
    }
}