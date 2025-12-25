using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Estabelecimento : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Slug { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string NomeFantasia { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string RazaoSocial { get; set; } = null!;

        [Required]
        [StringLength(18)]
        //[RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido. Formato esperado: 00.000.000/0000-00")]
        public string Cnpj { get; set; } = null!;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Telefone { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Whatsapp { get; set; } = null!;

        [Required]
        public int EnderecoId { get; set; }

        [ForeignKey(nameof(EnderecoId))]
        public Endereco Endereco { get; set; } = null!;

        [Required]
        public int EstabelecimentoStatusId { get; set; }

        [ForeignKey(nameof(EstabelecimentoStatusId))]
        public EstabelecimentoStatus EstabelecimentoStatus { get; set; } = null!;

        [Required]
        public int TenantId { get; set; }

        [ForeignKey(nameof(TenantId))]
        public Tenant Tenant { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxaEntrega { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PedidoMinimo { get; set; }

        // Relacionamentos
        public ICollection<Status> Status { get; set; } = new List<Status>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<PedidoStatus> PedidoStatus { get; set; } = new List<PedidoStatus>();
        public ICollection<ProdutoPedido> ProdutosPedido { get; set; } = new List<ProdutoPedido>();
        public ICollection<EstabelecimentoCategoria> Categorias { get; set; } = new List<EstabelecimentoCategoria>();
        public ICollection<ProdutoCategoria> ProdutoCategorias { get; set; } = new List<ProdutoCategoria>();
        public ICollection<MetodoPagamento> MetodosPagamento { get; set; } = new List<MetodoPagamento>();
        public ICollection<HorarioFuncionamento> HorariosFuncionamento { get; set; } = new List<HorarioFuncionamento>();
        public ICollection<ProdutoStatus> ProdutosStatus { get; set; } = new List<ProdutoStatus>();
    }
}
