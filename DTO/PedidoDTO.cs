using comaagora.Models;
using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreatePedidoDTO
    {
        public CreateUsuarioDTO Usuario { get; set; } = new();
        public CreateEnderecoDTO Endereco { get; set; } = new();
        public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new();
        public int MetodoPagamentoId { get; set; }
        public string? Observacao { get; set; }
    }
    public class UpdatePedidoDTO
    {
        public string Telefone { get; set; } = "";
        public string Nome { get; set; } = "";
        public List<CreateProdutoPedidoDTO> Produtos { get; set; } = new();
        public int MetodoPagamentoId { get; set; }
        public CreateEnderecoDTO Endereco { get; set; } = new();
        public PedidoStatusDTO PedidoStatus { get; set; } = new();
        public string? Observacao { get; set; }
    }

    public class GetPedidoDTO
    {
        public int Id { get; set; }
        public GetEnderecoDTO Endereco { get; set; } = new();
        public PedidoStatusDTO Status { get; set; } = new();
        public int MetodoPagamentoId { get; set; }
        public string Observacao { get; set; } = "";
        public GetEstabelecimentoDTO Estabelecimento { get; set; } = new();
        public GetUsuarioDTO Usuario { get; set; } = new();
        public List<GetProdutoPedidoDTO> Produtos { get; set; } = new();
        public List<HorarioFuncionamento> HorariosFuncionamento { get; set; } = new();
    }
    public class UpdatePedidoStatus
    {
        public int pedidoId { get; set; }
        public int statusId { get; set; }
    }
    public class PedidoStatusDTO
    {
        public int id { get; set; }
        public string nome { get; set; } = "";
    }
}
