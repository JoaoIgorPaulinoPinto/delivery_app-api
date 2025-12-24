using comaagora.DTO;
using comaagora.Models;
using comaagora.Repositories;

namespace comaagora.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService(ProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProdutoDTO>> GetAll(int estabelecimentoId)
        {
            var produtos = await _repository.GetAllByEstabelecimentoAsync(estabelecimentoId);

            return produtos.Select(p => new GetProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                ImgUrl = p.ImgUrl,
                Descricao = p.Descricao,
                Categoria = p.Categoria?.Nome ?? string.Empty,
                Status = p.Status?.Nome ?? string.Empty,
            }).ToList();
        }

        public async Task<GetProdutoDTO> GetByID(int id, int estabelecimentoId)
        {
            var p = await _repository.GetByIdAsync(id, estabelecimentoId);

            if (p == null)
                throw new KeyNotFoundException("Produto não encontrado");

            return new GetProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Descricao = p.Descricao,
                ImgUrl = p.ImgUrl,
                Categoria = p.Categoria?.Nome ?? string.Empty,
                Status = p.Status?.Nome ?? string.Empty,
            };
        }
        public async Task<GetProdutoDTO> Update(CreateProdutoDTO produto, int id)
        {
            var p = await _repository.UpdateAsync(produto, id);

            if (p == null)
                throw new KeyNotFoundException("Produto não encontrado");

            return new GetProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Descricao = p.Descricao,
                ImgUrl = p.ImgUrl,
                Categoria = p.Categoria?.Nome ?? string.Empty,
                Status = p.Status?.Nome ?? string.Empty,
            };
        }
    }
}
