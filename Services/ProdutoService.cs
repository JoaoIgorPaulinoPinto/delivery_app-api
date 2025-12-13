using comaagora.Data;
using comaagora.DTO;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProdutoDTO>> GetAll(int estabelecimentoId)
        {
            return await _context.Produtos
                .AsNoTracking().Where(p => p.EstabelecimentoId == estabelecimentoId)
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Categoria = p.Categoria.nome,
                    Status = p.Status.nome,
                    estabelecimento = p.Estabelecimento.NomeFantasia
                })
                .ToListAsync();
        }

        public async Task<List<ProdutoDTO>> GetByID(int id, int estabelecimentoId)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Where(p => p.EstabelecimentoId == estabelecimentoId)
                .Where(p => p.Id == id )
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Categoria = p.Categoria.nome,
                    Status = p.Status.nome,
                    estabelecimento = p.Estabelecimento.NomeFantasia

                })
                .ToListAsync();
        }

    }
}
