using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CapaPresentacion.Models
{
    public partial class BingoContext : DbContext
    {
        public BingoContext()
        {
        }

        public BingoContext(DbContextOptions<BingoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Combinaciones> Combinaciones { get; set; }
        public virtual DbSet<Juegos> Juegos { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }
        public virtual DbSet<Tarjetas> Tarjetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TV575S0;Database=Bingo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combinaciones>(entity =>
            {
                entity.HasKey(e => e.IdCombinacion);

                entity.Property(e => e.Numeros)
                    .IsRequired()
                    .HasMaxLength(71)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Juegos>(entity =>
            {
                entity.HasKey(e => e.IdJuego);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.NombreSala)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jugadores>(entity =>
            {
                entity.HasKey(e => e.IdJugador);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarjetas>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta);

                entity.HasOne(d => d.IdCombinacionNavigation)
                    .WithMany(p => p.Tarjetas)
                    .HasForeignKey(d => d.IdCombinacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarjetas_Combinaciones");

                entity.HasOne(d => d.IdJuegoNavigation)
                    .WithMany(p => p.Tarjetas)
                    .HasForeignKey(d => d.IdJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarjetas_Juegos");

                entity.HasOne(d => d.IdJugadorNavigation)
                    .WithMany(p => p.Tarjetas)
                    .HasForeignKey(d => d.IdJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarjetas_Jugadores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
