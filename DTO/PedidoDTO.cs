using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreatePedidoDTO
    {
        [Required]
        public CreateUsuarioDTO Usuario { get; set; } = new();

        [Required]
        public CreateEnderecoDTO Endereco { get; set; } = new();

        [Required]
        [MinLength(1)]
        public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue)]
        public int MetodoPagamentoId { get; set; }

        [StringLength(500)]
        public string? Observacao { get; set; }
    }

    public class UpdatePedidoDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue)]
        public int MetodoPagamentoId { get; set; }

        [Required]
        public CreateEnderecoDTO Endereco { get; set; } = new();

        [Required]
        public PedidoStatusDTO PedidoStatus { get; set; } = new();

        [StringLength(500)]
        public string? Observacao { get; set; }
    }

    public class GetPedidoDTO
    {
        public int Id { get; set; }
        public GetEnderecoDTO Endereco { get; set; } = new();
        public PedidoStatusDTO Status { get; set; } = new();
        public int MetodoPagamentoId { get; set; }
        public string Observacao { get; set; } = string.Empty;
        public GetEstabelecimentoDTO Estabelecimento { get; set; } = new();
        public GetUsuarioDTO Usuario { get; set; } = new();
        public List<GetProdutoPedidoDTO> Produtos { get; set; } = new();
    }

    public class UpdatePedidoStatus
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PedidoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int StatusId { get; set; }
    }

    public class PedidoStatusDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
