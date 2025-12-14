using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Estabelecimento: BaseEntity
    {
        public int Id { get; set; }

        public string? slug { get; set; }

        // Identificação
        public string NomeFantasia { get; set; } = null!;
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }

        // Contato
        public string Telefone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Whatsapp { get; set; }

        // Endereço
        public int? EnderecoId { get; set; }

        // Funcionamento
        public TimeSpan Abertura { get; set; }
        public TimeSpan Fechamento { get; set; }

        // Financeiro
        public decimal TaxaEntrega { get; set; }
        public decimal PedidoMinimo { get; set; }

        // Status
        public int EstabelecimentoStatusId { get; set; }
        public EstabelecimentoStatus EstabelecimentoStatus { get; set; } = null!;
        public Endereco Endereco { get; set; } = null!;

        // Relacionamentos
        public ICollection<Status> Status { get; set; } = new List<Status>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public ICollection<ProdutoPedido> ProdutosPedido { get; set; } = new List<ProdutoPedido>();
        public ICollection<EstabelecimentoCategoria> Categoria { get; set; } = new List<EstabelecimentoCategoria>();

    }
}
