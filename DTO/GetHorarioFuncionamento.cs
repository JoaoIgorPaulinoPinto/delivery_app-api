using comaagora.DTO;

namespace comaagora.DTO
{
    public class GetHorarioFuncionamentoDTO
    {
        public string DiaSemana { get; set; } = "";
        public TimeSpan Abertura { get; set; }
        public TimeSpan Fechamento { get; set; }
    }
}
