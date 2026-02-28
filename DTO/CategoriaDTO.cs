using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class GetCategoriaDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nome { get; set; } = string.Empty;
    }
}
