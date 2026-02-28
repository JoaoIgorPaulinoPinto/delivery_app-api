using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<EstabelecimentoStatus> EstabelecimentoStatus { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<EstabelecimentoCategoria> EstabelecimentoCategoria { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<PedidoStatus> PedidoStatus { get; set; }
        public DbSet<ProdutoStatus> ProdutoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estabelecimento>()
                .HasOne(e => e.Endereco)
                .WithMany(e => e.Estabelecimentos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Uf)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(e => e.UfId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Tipo)
                .WithMany(t => t.Enderecos)
                .HasForeignKey(e => e.TipoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Endereco)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Endereco)
                .WithOne(e => e.Pedido)
                .HasForeignKey<Pedido>(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.MetodoPagamento)
                .WithMany(mp => mp.Pedidos)
                .HasForeignKey(p => p.MetodoPagamentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
