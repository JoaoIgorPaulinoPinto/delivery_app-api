using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateEstabelecimentoDTO
    {
        public string NomeFantasia { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Whatsapp { get; set; } = "";
        public CreateEnderecoDTO Endereco { get; set; } = new();
        public decimal TaxaEntrega { get; set; }
        public decimal PedidoMinimo { get; set; }
    }

    public class GetEstabelecimentoDTO
    {
        public int Id { get; set; }
        public string Slug { get; set; } = "";
        public string NomeFantasia { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Whatsapp { get; set; } = "";
        public GetEnderecoDTO Endereco { get; set; } = new();
        public decimal TaxaEntrega { get; set; }
        public decimal PedidoMinimo { get; set; }
        public string Status { get; set; } = "";
        public List<GetHorarioFuncionamentoDTO> HorariosFuncionamento { get; set; } = new();
    }
}

