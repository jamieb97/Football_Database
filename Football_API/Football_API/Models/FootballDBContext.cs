using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Football_API.Models
{
    public partial class FootballDBContext : DbContext
    {
        public FootballDBContext()
        {
        }

        public FootballDBContext(DbContextOptions<FootballDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<HeadStaffs> HeadStaffs { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Scouts> Scouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FootballDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agents>(entity =>
            {
                entity.HasKey(e => e.AgentId)
                    .HasName("PK__Agents__9AC3BFD1294BDB4C");

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HeadStaffs>(entity =>
            {
                entity.HasKey(e => e.HeadStaffId)
                    .HasName("PK__HeadStaf__E3D4E3BFACCDD224");

                entity.Property(e => e.HeadStaffId).HasColumnName("HeadStaffID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.ScoutId).HasColumnName("ScoutID");

                entity.Property(e => e.StaffName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.HeadStaffs)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__HeadStaff__Owner__2E1BDC42");

                entity.HasOne(d => d.Scout)
                    .WithMany(p => p.HeadStaffs)
                    .HasForeignKey(d => d.ScoutId)
                    .HasConstraintName("FK__HeadStaff__Scout__2F10007B");
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__Owners__819385988B47879C");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.ClubOwned)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__Players__4A4E74A846B7600A");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PlayerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK__Players__AgentID__286302EC");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Players__OwnerID__276EDEB3");
            });

            modelBuilder.Entity<Scouts>(entity =>
            {
                entity.HasKey(e => e.ScoutId)
                    .HasName("PK__Scouts__CEF0ED58C9A24C87");

                entity.Property(e => e.ScoutId).HasColumnName("ScoutID");

                entity.Property(e => e.CountryBased)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.Property(e => e.ScoutName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Scouts)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__Scouts__PlayerID__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
