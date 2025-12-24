using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comaagora.Models
{
    public class Endereco : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter exatamente 8 dígitos.")]
        public string Cep { get; set; } = null!;

        [Required]
        [MaxLength(2)]
        public string Uf { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Cidade { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Rua { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Bairro { get; set; } = null!;

        [MaxLength(100)]
        public string? Complemento { get; set; }
    }
}
