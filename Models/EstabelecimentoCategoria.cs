using comaagora.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace comaagora.Models
{
    public class EstabelecimentoCategoria: BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string? nome { get; set; }
        public Status? status  { get; set; }

        public int EstabelecimentoId  { get; set; }


    }
}
