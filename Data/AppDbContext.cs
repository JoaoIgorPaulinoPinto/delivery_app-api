using comaagora.Models;
using comaagora.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<EstabelecimentoStatus> EstabelecimentoStatus { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<EstabelecimentoCategoria> EstabelecimentoCategoria { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedidos {  get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<PedidoStatus> PedidoStatus { get; set; }
        public DbSet<ProdutoStatus> ProdutoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.CreatedAt))
                        .ValueGeneratedOnAdd();

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.UpdatedAt))
                        .ValueGeneratedOnAddOrUpdate();
                }
            }
            modelBuilder.Entity<Pedido>()
             .HasOne(p => p.MetodoPagamento)
             .WithMany(mp => mp.Pedidos)
             .HasForeignKey(p => p.MetodoPagamentoId)
             .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Endereco)
                .WithOne()
                .HasForeignKey<Pedido>(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);



        }

    }
}
