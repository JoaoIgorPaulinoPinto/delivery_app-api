using comaagora.DTO;
using comaagora.Repositories;

namespace comaagora.Services.Localizacao
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private readonly LocalizacaoRepository _repository;

        public LocalizacaoService(LocalizacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EstadoDTO>> GetEstadosAsync()
        {
            var estados = await _repository.GetEstadosAsync();

            return estados.Select(e => new EstadoDTO
            {
                Id = e.Id,
                Nome = e.Nome,
                Uf = e.Uf
            }).ToList();
        }

        public async Task<List<MunicipioDTO>> GetMunicipiosByEstadoIdAsync(int estadoId)
        {
            if (estadoId <= 0)
            {
                throw new ArgumentException("Estado invalido.");
            }

            var estado = await _repository.GetEstadoByIdAsync(estadoId);
            if (estado == null)
            {
                throw new KeyNotFoundException("Estado nao encontrado.");
            }

            var municipios = await _repository.GetMunicipiosByUfAsync(estado.Uf);

            return municipios.Select(m => new MunicipioDTO
            {
                Id = m.Id,
                Codigo = m.Codigo,
                Nome = m.Nome,
                Uf = m.Uf
            }).ToList();
        }
    }
}
