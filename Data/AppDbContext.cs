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
            modelBuilder.Entity<Estabelecimento>()
            .HasOne(e => e.Endereco)
            .WithOne()
            .HasForeignKey<Estabelecimento>(e => e.EnderecoId)
            .OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Estabelecimento>()
            .HasOne(e => e.Endereco)
            .WithOne(e => e.Estabelecimento)
            .HasForeignKey<Estabelecimento>(e => e.EnderecoId)
             .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
