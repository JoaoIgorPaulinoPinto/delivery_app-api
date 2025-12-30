using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateEstabelecimentoDTO
    {
        [Required]
        public string NomeFantasia { get; set; } = "";
        [Required]
        public string Slug { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Whatsapp { get; set; } = "";
        [Required]
        public CreateEnderecoDTO Endereco { get; set; } = new();
        [Required]
        public decimal TaxaEntrega { get; set; }
        public decimal PedidoMinimo { get; set; }
    }

    public class GetEstabelecimentoDTO
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Slug { get; set; } = "";
        [Required]
        public string NomeFantasia { get; set; } = "";
        [Required]
        public string Telefone { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Whatsapp { get; set; } = "";
        [Required]
        public GetEnderecoDTO Endereco { get; set; } = new();
        [Required]
        public decimal TaxaEntrega { get; set; }
        [Required]
        public decimal PedidoMinimo { get; set; }
        [Required]
        public string Status { get; set; } = "";
        public List<GetHorarioFuncionamentoDTO> HorariosFuncionamento { get; set; } = new();
    }
}

