using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Housing_Society.Models;

public partial class HousingSocietyContext : DbContext
{
    public HousingSocietyContext()
    {
    }

    public HousingSocietyContext(DbContextOptions<HousingSocietyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=HousingSociety;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21B7657F30788");

            entity.Property(e => e.CityName).HasMaxLength(100);

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Cities__StateId__398D8EEE");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Houses__3214EC071D434400");

            entity.Property(e => e.Laundry).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Wifi).HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.Houses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Houses__CityId__3C69FB99");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__Photos__21B7B5E27314D311");

            entity.Property(e => e.PhotoUrl).HasMaxLength(500);

            entity.HasOne(d => d.Housing).WithMany(p => p.Photos)
                .HasForeignKey(d => d.HousingId)
                .HasConstraintName("FK__Photos__HousingI__3F466844");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__States__C3BA3B3A58B3A4AA");

            entity.Property(e => e.StateName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Signup__3214EC07DA6DE9CB");

            entity.HasIndex(e => e.Email, "UQ__Signup__AB6E6164DE608858").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
