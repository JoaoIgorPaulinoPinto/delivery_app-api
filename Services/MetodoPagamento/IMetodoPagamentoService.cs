using comaagora.Models;

namespace comaagora.Services
{
    public interface IMetodoPagamentoService
    {
        public Task<List<MetodoPagamentoDTO>> GetAll(int estabelecimentoId);
    }
}
