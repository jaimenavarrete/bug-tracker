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
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.CreatedBy).HasMaxLength(36);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.Entity<ProjectState>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.ColorHexCode).HasMaxLength(7);

                entity.Property(e => e.CreatedBy).HasMaxLength(36);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasMaxLength(36);

                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProjectStates)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_ProjectStates");
            });

            modelBuilder.Entity<ProjectTag>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.ColorHexCode).HasMaxLength(7);

                entity.Property(e => e.CreatedBy).HasMaxLength(36);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasMaxLength(36);

                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProjectTags)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Groups_ProjectTags");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.AssignedUserId).HasMaxLength(36);

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(36);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.Name).HasMaxLength(75);

                entity.Property(e => e.ProjectId).HasMaxLength(36);

                entity.Property(e => e.StateId).HasMaxLength(36);

                entity.Property(e => e.SubmitterId).HasMaxLength(36);

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK_Classifications_Tickets");

                entity.HasOne(d => d.Gravity)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.GravityId)
                    .HasConstraintName("FK_GravityLevels_Tickets");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Projects_Tickets");

                entity.HasOne(d => d.Reproducibility)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ReproducibilityId)
                    .HasConstraintName("FK_ReproducibilityLevels_Tickets");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketsStates_Tickets");

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Tickets)
                    .UsingEntity<Dictionary<string, object>>(
                        "TicketTagsAssignment",
                        l => l.HasOne<TicketTag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TicketTags_TicketTagsAssignment"),
                        r => r.HasOne<Ticket>().WithMany().HasForeignKey("TicketId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tickets_TicketTagsAssignment"),
                        j =>
                        {
                            j.HasKey("TicketId", "TagId");

                            j.ToTable("TicketTagsAssignment");

                            j.IndexerProperty<string>("TicketId").HasMaxLength(36);

                            j.IndexerProperty<string>("TagId").HasMaxLength(36);
                        });
            });

            modelBuilder.Entity<TicketState>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.ColorHexCode).HasMaxLength(7);

                entity.Property(e => e.CreatedBy).HasMaxLength(36);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.ProjectId).HasMaxLength(36);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TicketStates)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_TicketStates");
            });

            modelBuilder.Entity<TicketTag>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(36);

                entity.Property(e => e.ColorHexCode).HasMaxLength(7);

                entity.Property(e => e.CreatedBy).HasMaxLength(36);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.ProjectId).HasMaxLength(36);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TicketTags)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Projects_TicketTags");
            });


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
