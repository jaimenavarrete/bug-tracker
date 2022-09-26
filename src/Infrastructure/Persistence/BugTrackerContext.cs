using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class BugTrackerContext : DbContext
    {
        public BugTrackerContext()
        {
        }

        public BugTrackerContext(DbContextOptions<BugTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classification> Classifications { get; set; } = null!;
        public virtual DbSet<GravityLevel> GravityLevels { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectState> ProjectStates { get; set; } = null!;
        public virtual DbSet<ProjectTag> ProjectTags { get; set; } = null!;
        public virtual DbSet<ReproducibilityLevel> ReproducibilityLevels { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketState> TicketStates { get; set; } = null!;
        public virtual DbSet<TicketTag> TicketTags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectStateConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectTagConfiguration());

            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.ApplyConfiguration(new TicketStateConfiguration());

            modelBuilder.ApplyConfiguration(new TicketTagConfiguration());


            modelBuilder.Entity<Classification>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<GravityLevel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<ReproducibilityLevel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
