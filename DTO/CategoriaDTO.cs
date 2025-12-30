using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class GetCateriaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }
    }
}
