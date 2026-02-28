using comaagora.DTO;
using comaagora.Repositories;

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
            var normalizedSlug = slug?.Trim().ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(normalizedSlug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            return await _metodoPagamentoRepo.GetAll(normalizedSlug);
        }
    }
}
