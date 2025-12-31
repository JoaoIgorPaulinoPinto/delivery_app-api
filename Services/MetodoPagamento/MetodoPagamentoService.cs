using comaagora.DTO;
using comaagora.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace comaagora.Services.MetodoPagamento
{
    public class MetodoPagamentoService : IMetodoPagamentoService
    {
        private readonly MetodoPagamentoRepository _metodoPagamentoRepo;

        public MetodoPagamentoService(MetodoPagamentoRepository metodoPagamentoRepo)
        {
            _metodoPagamentoRepo = metodoPagamentoRepo;
        }

        public async Task<List<MetodoPagamentoDTO>> GetAll(string slug)
        {
            return await _metodoPagamentoRepo.GetAll(slug);
        }
    }
}
