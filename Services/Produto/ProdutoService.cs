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
                Categoria = new ProdutoCategoriaDTO
                {
                    Id = p.Categoria.Id,
                    Nome = p.Categoria.Nome ?? string.Empty,
                },
                Status = new DTO.ProdutoStatusDTO
                {
                    Nome = p.Status.Nome,
                    Id = p.Status.Id,
                }
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
                Categoria = new ProdutoCategoriaDTO
                {
                    Id = p.Categoria.Id,
                    Nome = p.Categoria.Nome ?? string.Empty,
                },
                Status = new DTO.ProdutoStatusDTO
                {
                    Nome = p.Status.Nome,
                    Id = p.Status.Id,
                }
            };
        }
        public async Task<bool> Update(CreateProdutoDTO produto, int id)
        {
            var p = await _repository.UpdateAsync(produto, id);

            if (p == false)
                throw new KeyNotFoundException("Produto não encontrado");

            return true;

        }
        public async Task<bool> CreateProduto(CreateProdutoDTO dto, int id)
        {
            var novoProduto = new Models.Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                ImgUrl = dto.ImgUrl,
                Preco = dto.Preco,
                CategoriaId = dto.CategoriaId,
                ProdutoStatusId = dto.StatusId,
                EstabelecimentoId = id // Vincula ao restaurante logado
            };

            var p = await _repository.CreateAsync(novoProduto, id);

            if (p == false)
                throw new KeyNotFoundException("Erro ao criar");

            return true;
        }
    }
}
