using comaagora.Models;
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
        public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new();
        [Required]
        public int MetodoPagamentoId { get; set; }
        public string? Observacao { get; set; }
    }
    public class UpdatePedidoDTO
    {
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new();
        [Required]
        public int MetodoPagamentoId { get; set; }
        [Required]
        public CreateEnderecoDTO Endereco { get; set; } = new();
        [Required]
        public PedidoStatusDTO PedidoStatus { get; set; } = new();
        [Required]
        public string? Observacao { get; set; }
    }

    public class GetPedidoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public GetEnderecoDTO Endereco { get; set; } = new();
        [Required]
        public PedidoStatusDTO Status { get; set; } = new();
        [Required]
        public int MetodoPagamentoId { get; set; }
        [Required]
        public string Observacao { get; set; } = "";
        [Required]
        public GetEstabelecimentoDTO Estabelecimento { get; set; } = new();
        [Required]
        public GetUsuarioDTO Usuario { get; set; } = new();
        [Required]
        public List<GetProdutoPedidoDTO> Produtos { get; set; } = new();
        [Required]
        public List<HorarioFuncionamento> HorariosFuncionamento { get; set; } = new();
    }
    public class UpdatePedidoStatus
    {
        [Required] public int pedidoId { get; set; }
        [Required] public int statusId { get; set; }
    }
    public class PedidoStatusDTO
    {
        [Required] public int id { get; set; }
        [Required] public string nome { get; set; } = "";
    }
}
