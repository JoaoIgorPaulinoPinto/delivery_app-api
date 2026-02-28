using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateEnderecoDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Rua { get; set; } = string.Empty;

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string Numero { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int Cidade { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Uf { get; set; }

        [Required]
        [RegularExpression("^\\d{8}$", ErrorMessage = "CEP deve conter 8 digitos numericos.")]
        public string Cep { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Complemento { get; set; }
    }

    public class GetEnderecoDTO
    {
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public int Cidade { get; set; }
        public int Uf { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string? Complemento { get; set; }
    }
}
