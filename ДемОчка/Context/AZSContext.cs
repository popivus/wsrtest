using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ДемОчка.Models;

namespace ДемОчка.Context
{
    public partial class AZSContext : DbContext
    {
        public AZSContext()
        {
        }

        public AZSContext(DbContextOptions<AZSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FuelType> FuelTypes { get; set; } = null!;
        public virtual DbSet<Gas> Gas { get; set; } = null!;
        public virtual DbSet<GasType> GasTypes { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MANAGER55\\MANAGER55;Initial Catalog=AZS;User ID=sa;Password=5Dfg893ass");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__FuelType__737584F7A1BD8F6F");

                entity.ToTable("FuelType");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Gas>(entity =>
            {
                entity.HasKey(e => e.IdGas);

                entity.Property(e => e.IdGas).HasColumnName("ID_Gas");

                entity.Property(e => e.GasTypeId).HasColumnName("GasType_ID");

                entity.Property(e => e.StationId).HasColumnName("Station_ID");

                entity.HasOne(d => d.GasType)
                    .WithMany(p => p.Gas)
                    .HasForeignKey(d => d.GasTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gas_GasType");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Gas)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gas_Station");
            });

            modelBuilder.Entity<GasType>(entity =>
            {
                entity.HasKey(e => e.IdGasType);

                entity.ToTable("GasType");

                entity.Property(e => e.IdGasType).HasColumnName("ID_GasType");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.IdStation);

                entity.ToTable("Station");

                entity.Property(e => e.IdStation).HasColumnName("ID_Station");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
