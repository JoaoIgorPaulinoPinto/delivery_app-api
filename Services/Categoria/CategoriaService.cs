using comaagora.DTO;
using comaagora.Repositories;

namespace comaagora.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _repo;

        public CategoriaService(CategoriaRepository repository)
        {
            _repo = repository;
        }

        public async Task<List<GetCategoriaDTO>> GetCategorias(string slug)
        {
            var normalizedSlug = slug?.Trim().ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(normalizedSlug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            var categorias = await _repo.GetCategorias(normalizedSlug);
            return categorias.Select(c => new GetCategoriaDTO
            {
                Id = c.Id,
                Nome = c.Nome
            }).ToList();
        }
    }
}
