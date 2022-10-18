using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ActivityFlowConfiguration : IEntityTypeConfiguration<ActivityFlow>
    {
        public void Configure(EntityTypeBuilder<ActivityFlow> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasMaxLength(36);

            builder.Property(e => e.ActionDate).HasColumnType("datetime");

            builder.Property(e => e.ItemId).HasMaxLength(36);

            builder.Property(e => e.UserId).HasMaxLength(36);

            ConfigureRelationships(builder);
        }

        private void ConfigureRelationships(EntityTypeBuilder<ActivityFlow> builder)
        {
            builder.HasOne(d => d.ActionType)
                .WithMany(p => p.ActivityFlows)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityTypes_ActivityFlow");

            builder.HasOne(d => d.ItemType)
                .WithMany(p => p.ActivityFlows)
                .HasForeignKey(d => d.ItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityEntities_ActivityFlow");
        }
    }
}
