using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class GroupConfiguration : BaseEntityConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).HasMaxLength(75);

            builder.Property(e => e.Description).HasColumnType("text");
        }
    }
}
