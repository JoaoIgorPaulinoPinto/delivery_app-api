using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class ProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        // Busca todos os produtos de um estabelecimento
        public async Task<List<Produto>> GetAllByEstabelecimentoAsync(int estabelecimentoId)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .Where(p => p.EstabelecimentoId == estabelecimentoId)
                .ToListAsync();
        }

        // Busca produto por ID e estabelecimento
        public async Task<Produto?> GetByIdAsync(int id, int estabelecimentoId)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id && p.EstabelecimentoId == estabelecimentoId);
        }
        // Atualiza o produto com base no ID
        public async Task<Produto?> UpdateAsync(CreateProdutoDTO produto, int id)
        {
            Produto? produtoEncontrado = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.EstabelecimentoId == id);
            if (produtoEncontrado != null) {
                Produto produtoAtualizado = new Produto
                {
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    ImgUrl = produto.ImgUrl,
                    Preco = produto.Preco,
                    CategoriaId = produto.CategoriaId,
                    ProdutoStatusId = produto.StatusId
                };
                return produtoAtualizado;
            }
            else
            {
                throw new NotImplementedException("Produto não encontrado na base de dados");
            }
        }
    }
}
