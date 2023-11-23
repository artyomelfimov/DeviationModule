using System;
using System.Collections.Generic;
using DeviationModule.Models;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Procedure> Procedures { get; set; }
    public virtual DbSet<Deviation> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestDB;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Procedures_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasColumnType("text");
            entity.Property(e => e.Owner).HasColumnType("text");
            entity.Property(e => e.Status).HasColumnType("text");
        });
        modelBuilder.Entity<Deviation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Positions_pkey");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
