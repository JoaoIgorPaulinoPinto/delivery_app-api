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

    public class GetPedidoDTO
    {
        public int Id { get; set; }
        public GetEnderecoDTO Endereco { get; set; } = new();
        public PedidoStatus Status { get; set; } = new();
        public int MetodoPagamentoId { get; set; }
        public GetEstabelecimentoDTO Estabelecimento { get; set; } = new();
        public GetUsuarioDTO Usuario { get; set; } = new();
        public List<GetProdutoPedidoDTO> Produtos { get; set; } = new();
        public List<HorarioFuncionamento> HorariosFuncionamento { get; set; } = new();
    }

}
