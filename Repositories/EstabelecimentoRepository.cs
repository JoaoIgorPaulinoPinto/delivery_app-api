using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;

namespace comaagora.Repositories
{
    public class EstabelecimentoRepository
    {
        private readonly AppDbContext _context;

        public EstabelecimentoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Estabelecimento?> GetBySlug(string slug)
        {
            if (string.IsNullOrEmpty(slug)) return null;

            return await _context.Estabelecimentos
                .AsNoTracking()
                .Where(e => e.Slug == slug)
                .Select(e => new Estabelecimento
                {
                    Id = e.Id,
                    NomeFantasia = e.NomeFantasia,
                    Slug = e.Slug,
                    HorarioFuncionamentos = e.HorarioFuncionamentos,
                    EstabelecimentoStatus = e.EstabelecimentoStatus,

                    Endereco = _context.Enderecos
                        .Where(end => end.Usuario == e.Id)
                        .Select(end => new Endereco
                        {
                            Id = end.Id,
                            Rua = end.Rua,
                            Cidade = end.Cidade,
                            Uf = end.Uf,
                            Cep = end.Cep,
                            Numero = end.Numero,
                            Bairro = end.Bairro,
                            Complemento = end.Complemento
                        }).FirstOrDefault()!
                })
                .FirstOrDefaultAsync();
        }
    }
}
