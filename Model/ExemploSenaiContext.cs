using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoSenai.Model
{
    public partial class ExemploSenaiContext : DbContext
    {
        public ExemploSenaiContext()
        {
        }

        public ExemploSenaiContext(DbContextOptions<ExemploSenaiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QMC8BF0\\SQLEXPRESS;Initial Catalog=ExemploSenai;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Conteudo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Momento).HasColumnType("datetime");

                entity.HasOne(d => d.PublicanteNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Publicante)
                    .HasConstraintName("FK__Post__Publicante__267ABA7A");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
