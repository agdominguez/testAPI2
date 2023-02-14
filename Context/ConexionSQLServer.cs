using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Context
{
    public partial class ConexionSQLServer : DbContext
    {
        public ConexionSQLServer()
        {
        }
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options)
        : base(options)
        {
        }
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1E52A99673A");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("fk_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}
