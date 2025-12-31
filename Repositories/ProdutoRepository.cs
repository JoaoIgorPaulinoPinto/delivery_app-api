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
        public async Task<List<Produto>> GetAllByEstabelecimentoAsync(string slug)
        {
            // 1. Atualize o Include para ProdutoStatus
            // 2. Se quiser acessar o Status original, faça um ThenInclude
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status) // Nova tabela
                .AsNoTracking()
                .Where(p => p.Estabelecimento.Slug == slug)
                .ToListAsync();

            if (produtos.Any())
            {
                return produtos;
            }

            // Use string interpolation para evitar erro de concatenação sem espaço
            throw new Exception($"Produtos do estabelecimento {slug} não encontrados");
        }

        // Busca produto por ID e estabelecimento
        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Status)
                .Include(p => p.Estabelecimento)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        // Atualiza o produto com base no ID
        public async Task<bool> UpdateAsync(CreateProdutoDTO dto, int id)
        {
            var produtoEncontrado = await _context.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produtoEncontrado == null) return false;

            produtoEncontrado.Nome = dto.Nome;
            produtoEncontrado.Descricao = dto.Descricao;
            produtoEncontrado.ImgUrl = dto.ImgUrl;
            produtoEncontrado.Preco = dto.Preco;
            produtoEncontrado.CategoriaId = dto.CategoriaId;
            produtoEncontrado.ProdutoStatusId = dto.StatusId;

            await _context.SaveChangesAsync();
            return (true);
        }
        public async Task<bool> CreateAsync(Produto produto, int id)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return (true);
        }
    }
}
