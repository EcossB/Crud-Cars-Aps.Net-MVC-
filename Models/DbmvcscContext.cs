using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Segundo_parcial_CRUD.Models;
//esta es la representacion de mi base de datos
public partial class DbmvcscContext : DbContext
{
    public DbmvcscContext()
    {
    }

    public DbmvcscContext(DbContextOptions<DbmvcscContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<MStatus> MStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vhestatus> Vhestatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.Idauto);

            entity.ToTable("AUTOS");

            entity.Property(e => e.Idauto).HasColumnName("IDauto");
            entity.Property(e => e.Anio)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ImgRuta).HasColumnType("text");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.MiEstatus).HasColumnName("miEstatus");
            entity.Property(e => e.Modelo)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.oEstatus).WithMany(p => p.Autos)
                .HasForeignKey(d => d.MiEstatus)
                .HasConstraintName("FK_AUTOS_VHESTATUS");
        });

        modelBuilder.Entity<MStatus>(entity =>
        {
            entity.HasKey(e => e.Idstatus);

            entity.ToTable("mStatus");

            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(150);

            entity.HasOne(d => d.IdEstatusNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERS_mStatus");
        });

        modelBuilder.Entity<Vhestatus>(entity =>
        {
            entity.HasKey(e => e.Idestatus);

            entity.ToTable("VHESTATUS");

            entity.Property(e => e.Idestatus).HasColumnName("IDestatus");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
