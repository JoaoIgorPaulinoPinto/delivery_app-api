using comaagora.DTO;
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

        public async Task<List<GetProdutoDTO>> GetAll(string slug)
        {
            var normalizedSlug = slug?.Trim().ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(normalizedSlug))
            {
                throw new ArgumentException("Slug do estabelecimento e obrigatorio.");
            }

            var produtos = await _repository.GetAllByEstabelecimentoAsync(normalizedSlug);
            return produtos.Select(MapProduto).ToList();
        }

        public async Task<GetProdutoDTO> GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do produto invalido.");
            }

            var produto = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Produto nao encontrado.");

            return MapProduto(produto);
        }

        public async Task<bool> Update(CreateProdutoDTO produto, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id do produto invalido.");
            }

            var updated = await _repository.UpdateAsync(produto, id);
            if (!updated)
            {
                throw new KeyNotFoundException("Produto nao encontrado.");
            }

            return true;
        }

        public async Task<bool> CreateProduto(CreateProdutoDTO dto, int estabelecimentoId)
        {
            if (estabelecimentoId <= 0)
            {
                throw new ArgumentException("Id do estabelecimento invalido.");
            }

            var novoProduto = new Models.Produto
            {
                Nome = dto.Nome.Trim(),
                Descricao = dto.Descricao.Trim(),
                ImgUrl = dto.ImgUrl.Trim(),
                Preco = dto.Preco,
                CategoriaId = dto.CategoriaId,
                ProdutoStatusId = dto.StatusId,
                EstabelecimentoId = estabelecimentoId
            };

            return await _repository.CreateAsync(novoProduto);
        }

        private static GetProdutoDTO MapProduto(Models.Produto produto)
        {
            return new GetProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                ImgUrl = produto.ImgUrl,
                Descricao = produto.Descricao,
                Categoria = new ProdutoCategoriaDTO
                {
                    Id = produto.Categoria?.Id ?? 0,
                    Nome = produto.Categoria?.Nome ?? string.Empty
                },
                Status = new ProdutoStatusDTO
                {
                    Id = produto.ProdutoStatus?.Id ?? 0,
                    Nome = produto.ProdutoStatus?.Nome ?? string.Empty
                }
            };
        }
    }
}
