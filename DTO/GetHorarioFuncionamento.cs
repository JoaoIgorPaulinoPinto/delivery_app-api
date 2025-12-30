using comaagora.DTO;
using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class GetHorarioFuncionamentoDTO
    {
        [Required]
        public string DiaSemana { get; set; } = "";
        [Required]
        public TimeSpan Abertura { get; set; }
        [Required]
        public TimeSpan Fechamento { get; set; }
    }
}
