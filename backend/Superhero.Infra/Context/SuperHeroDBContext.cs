using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SuperHeroi.Domain.Entities;

namespace SuperHeroi.Infra.Context
{
    public partial class SuperHeroDBContext : DbContext
    {
        public SuperHeroDBContext()
        {
        }

        public SuperHeroDBContext(DbContextOptions<SuperHeroDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Herois> Herois { get; set; }
        public virtual DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
        public virtual DbSet<Superpoderes> Superpoderes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Herois>(entity =>
            {
                entity.HasIndex(e => e.NomeHeroi)
                    .HasName("UQ__Herois__F9934DB0348EC620")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.NomeHeroi)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<HeroisSuperpoderes>(entity =>
            {
                entity.HasKey(e => new { e.HeroiId, e.SuperpoderId })
                    .HasName("PK__HeroisSu__0670904384EA78ED");

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.HeroisSuperpoderes)
                    .HasForeignKey(d => d.HeroiId)
                    .HasConstraintName("FK__HeroisSup__Heroi__44FF419A");

                entity.HasOne(d => d.Superpoder)
                    .WithMany(p => p.HeroisSuperpoderes)
                    .HasForeignKey(d => d.SuperpoderId)
                    .HasConstraintName("FK__HeroisSup__Super__45F365D3");
            });

            modelBuilder.Entity<Superpoderes>(entity =>
            {
                entity.Property(e => e.Descricao).HasMaxLength(250);

                entity.Property(e => e.Superpoder)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
