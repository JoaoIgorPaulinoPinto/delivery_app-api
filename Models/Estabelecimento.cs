using comaagora.Models.Base;

namespace comaagora.Models
{
    public class Estabelecimento: BaseEntity
    {
        public int Id { get; set; }

        public required string slug { get; set; }

        // Identificação
        public required string NomeFantasia { get; set; } = null!;
        public required string RazaoSocial { get; set; }
        public required string Cnpj { get; set; }

        // Contato
        public required string Telefone { get; set; } = null!;
        public required string Email { get; set; }
        public required string Whatsapp { get; set; }

        // Endereço
        public required int EnderecoId { get; set; }
        public  Endereco Endereco { get; set; } = null!;

        // Funcionamento
        public TimeSpan Abertura { get; set; }
        public TimeSpan Fechamento { get; set; }

        // Financeiro
        public required decimal TaxaEntrega { get; set; }
        public required decimal PedidoMinimo { get; set; }

        // Status
        public required int EstabelecimentoStatusId { get; set; }
        public  EstabelecimentoStatus EstabelecimentoStatus { get; set; } = null!;

        // Relacionamentos
        public ICollection<Status> Status { get; set; } = new List<Status>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<ProdutoPedido> ProdutosPedido { get; set; } = new List<ProdutoPedido>();
        public ICollection<EstabelecimentoCategoria> Categoria { get; set; } = new List<EstabelecimentoCategoria>();
        public ICollection<MetodoPagamento> MetodosPagamento { get; set; } = new List<MetodoPagamento>();

    }
}
