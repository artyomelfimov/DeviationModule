using DeviationModule.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviationModule.Infrastructure;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
        Database.EnsureCreated();
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Launch> Launches { get; set; }
    public virtual DbSet<Procedure> Procedures { get; set; }
    public virtual DbSet<Deviation> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestDB_1;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Procedures_pkey");

            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Owner).HasColumnType("text");
            entity.Property(e => e.Status).HasColumnType("text");
        });
        modelBuilder.Entity<Deviation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Positions_pkey");
        });
        modelBuilder.Entity<Launch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Launches_pkey");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
