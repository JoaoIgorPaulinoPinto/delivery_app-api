using comaagora.DTO;
using comaagora.Models;
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
        public async Task<List<GetCateriaDTO>> GetCategorias(int estabelecimentoId)
        {
            List<ProdutoCategoria> lista = await _repo.GetCategorias(estabelecimentoId);
            return lista.Select(c => new GetCateriaDTO
            {
                Id = c.Id,
                Nome = c.Nome,
            }).ToList();
        }
    }
}
