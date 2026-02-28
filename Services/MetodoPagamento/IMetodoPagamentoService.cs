using comaagora.DTO;

namespace comaagora.Services.MetodoPagamento
{
    public interface IMetodoPagamentoService
    {
        Task<List<MetodoPagamentoDTO>> GetAll(string slug);
    }
}
