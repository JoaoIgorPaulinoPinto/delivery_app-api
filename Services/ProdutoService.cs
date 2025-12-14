using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProdutoDTO>> GetAll(int estabelecimentoId)
        {
            var produtos = await _repository.GetAllByEstabelecimentoAsync(estabelecimentoId);

            return produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                ImgUrl = p.ImgUrl,
                Descricao = p.Descricao,
                Categoria = p.Categoria?.nome ?? string.Empty,
                Status = p.Status?.nome ?? string.Empty,
                estabelecimento = p.Estabelecimento?.NomeFantasia ?? string.Empty
            }).ToList();
        }

        public async Task<ProdutoDTO> GetByID(int id, int estabelecimentoId)
        {
            var p = await _repository.GetByIdAsync(id, estabelecimentoId);

            if (p == null)
                throw new KeyNotFoundException("Produto não encontrado");

            return new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Descricao = p.Descricao,
                ImgUrl = p.ImgUrl,
                Categoria = p.Categoria?.nome ?? string.Empty,
                Status = p.Status?.nome ?? string.Empty,
                estabelecimento = p.Estabelecimento?.NomeFantasia ?? string.Empty
            };
        }
    }
}
