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

        public async Task<List<Produto>> GetAllByEstabelecimentoAsync(string slug)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ProdutoStatus)
                .AsNoTracking()
                .Where(p => p.Estabelecimento.Slug == slug)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ProdutoStatus)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateAsync(CreateProdutoDTO dto, int id)
        {
            var produtoEncontrado = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produtoEncontrado == null)
            {
                return false;
            }

            produtoEncontrado.Nome = dto.Nome.Trim();
            produtoEncontrado.Descricao = dto.Descricao.Trim();
            produtoEncontrado.ImgUrl = dto.ImgUrl.Trim();
            produtoEncontrado.Preco = dto.Preco;
            produtoEncontrado.CategoriaId = dto.CategoriaId;
            produtoEncontrado.ProdutoStatusId = dto.StatusId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
