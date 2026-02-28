using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateEstabelecimentoDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string NomeFantasia { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Whatsapp { get; set; } = string.Empty;

        [Required]
        public CreateEnderecoDTO Endereco { get; set; } = new();

        [Required]
        [Range(typeof(decimal), "0", "999999")]
        public decimal TaxaEntrega { get; set; }

        [Range(typeof(decimal), "0", "999999")]
        public decimal PedidoMinimo { get; set; }
    }

    public class GetEstabelecimentoDTO
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public GetEnderecoEstabelecimentoDTO Endereco { get; set; } = new();
        public decimal TaxaEntrega { get; set; }
        public decimal PedidoMinimo { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<GetHorarioFuncionamentoDTO> HorariosFuncionamento { get; set; } = new();
    }
    public class GetEnderecoEstabelecimentoDTO
    {
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string? Complemento { get; set; }
    }

}
