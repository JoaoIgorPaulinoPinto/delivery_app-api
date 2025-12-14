using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace comaagora.Models
{
    public class EstabelecimentoCategoria: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public required string? nome { get; set; }
        public required Status? status  { get; set; }
        public required int EstabelecimentoId  { get; set; }

    }
}
