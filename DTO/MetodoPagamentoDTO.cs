using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class MetodoPagamentoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Tipo { get; set; } = string.Empty;
    }
}
