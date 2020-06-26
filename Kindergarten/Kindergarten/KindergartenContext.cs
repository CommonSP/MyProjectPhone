using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kindergarten
{
    public partial class KindergartenContext : DbContext
    {
        public KindergartenContext()
        {
        }

        public KindergartenContext(DbContextOptions<KindergartenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Children> Children { get; set; }
        public virtual DbSet<Educators> Educators { get; set; }
        public virtual DbSet<Entity8> Entity8 { get; set; }
        public virtual DbSet<Entity9> Entity9 { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Parents> Parents { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-CP1M852\\SQLEXPRESS;Database=Kindergarten;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.IdAttendance);

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<Children>(entity =>
            {
                entity.HasKey(e => e.IdChild);

                entity.HasIndex(e => e.IdGroup)
                    .HasName("IX_Relationship2");

                entity.Property(e => e.BirdthSerteficate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(40);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship2");
            });

            modelBuilder.Entity<Educators>(entity =>
            {
                entity.HasKey(e => e.IdEducator);

                entity.HasIndex(e => e.IdGroup)
                    .HasName("IX_Relationship13");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pasport)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Educators)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship13");
            });

            modelBuilder.Entity<Entity8>(entity =>
            {
                entity.HasKey(e => new { e.IdAttendance, e.IdChild });

                entity.HasOne(d => d.IdAttendanceNavigation)
                    .WithMany(p => p.Entity8)
                    .HasForeignKey(d => d.IdAttendance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship8");

                entity.HasOne(d => d.IdChildNavigation)
                    .WithMany(p => p.Entity8)
                    .HasForeignKey(d => d.IdChild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship9");
            });

            modelBuilder.Entity<Entity9>(entity =>
            {
                entity.HasKey(e => new { e.IdParent, e.IdChild });

                entity.HasOne(d => d.IdChildNavigation)
                    .WithMany(p => p.Entity9)
                    .HasForeignKey(d => d.IdChild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship11");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.Entity9)
                    .HasForeignKey(d => d.IdParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship10");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.IdGroup);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Parents>(entity =>
            {
                entity.HasKey(e => e.IdParent);

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pasport)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.IdSchedule);

                entity.HasIndex(e => e.IdGroup)
                    .HasName("IX_Relationship7");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
