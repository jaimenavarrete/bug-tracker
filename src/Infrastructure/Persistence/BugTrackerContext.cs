using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class BugTrackerContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public BugTrackerContext()
        {
        }

        public BugTrackerContext(DbContextOptions<BugTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionType> ActionTypes { get; set; } = null!;
        public virtual DbSet<ActivityFlow> ActivityFlows { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<ItemType> ItemTypes { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectState> ProjectStates { get; set; } = null!;
        public virtual DbSet<ProjectTag> ProjectTags { get; set; } = null!;
        public virtual DbSet<Classification> Classifications { get; set; } = null!;
        public virtual DbSet<GravityLevel> GravityLevels { get; set; } = null!;
        public virtual DbSet<ReproducibilityLevel> ReproducibilityLevels { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketState> TicketStates { get; set; } = null!;
        public virtual DbSet<TicketTag> TicketTags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActionType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<ActivityFlow>(entity =>
            {
                entity.ToTable("ActivityFlow");

                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasMaxLength(36);

                entity.Property(e => e.UserId).HasMaxLength(36);

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.ActivityFlows)
                    .HasForeignKey(d => d.ActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityTypes_ActivityFlow");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.ActivityFlows)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityEntities_ActivityFlow");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.ApplyConfiguration(new GroupConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectStateConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectTagConfiguration());

            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.ApplyConfiguration(new TicketStateConfiguration());

            modelBuilder.ApplyConfiguration(new TicketTagConfiguration());

            modelBuilder.Entity<ReproducibilityLevel>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<GravityLevel>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(25);
            });

            //**********************************************************************************************
            // IDENTITY
            //**********************************************************************************************

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
