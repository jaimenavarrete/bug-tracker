using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            BaseConfiguration<Group>.ConfigureBaseEntityProperties(builder);

            builder.Property(e => e.Name).HasMaxLength(75);

            builder.Property(e => e.Description).HasColumnType("text");
        }
    }
}
