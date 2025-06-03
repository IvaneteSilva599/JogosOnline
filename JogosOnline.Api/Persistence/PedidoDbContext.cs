using JogosOnline.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JogosOnline.Api.Persistence
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.ValorTotal)
                      .HasPrecision(18, 2);

                entity.HasMany(p => p.Produtos)
                      .WithOne(p => p.Pedido)
                      .HasForeignKey(p => p.PedidoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Altura)
                      .IsRequired();

                entity.Property(p => p.Largura)
                      .IsRequired();

                entity.Property(p => p.Comprimento)
                      .IsRequired();

                entity.HasOne(p => p.Pedido)
                      .WithMany(p => p.Produtos)
                      .HasForeignKey(p => p.PedidoId);
            });
        }
    }
}