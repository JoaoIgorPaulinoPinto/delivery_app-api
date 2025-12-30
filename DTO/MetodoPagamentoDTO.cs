using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class MetodoPagamentoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = null!;
        [Required]
        public string Tipo { get; set; } = null!;
    }
}
