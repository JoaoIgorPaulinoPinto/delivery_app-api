using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class GetHorarioFuncionamentoDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string DiaSemana { get; set; } = string.Empty;

        public TimeOnly Abertura { get; set; }
        public TimeOnly Fechamento { get; set; }
    }
}
