using comaagora.Data;
using comaagora.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace comaagora.Repositories
{
    public class EnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco?> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Enderecos
                .AsNoTracking()
                .Include(e => e.Cidade)
                .Include(e => e.Uf)
                .FirstOrDefaultAsync(e => e.Usuario == usuarioId);
        }

        public async Task<Dictionary<int, Endereco>> GetByUsuariosIdsAsync(IEnumerable<int> usuarioIds)
        {
            var ids = usuarioIds
                .Where(id => id > 0)
                .Distinct()
                .ToList();

            if (ids.Count == 0)
            {
                return new Dictionary<int, Endereco>();
            }

            var usuarioPredicate = BuildUsuarioIdsPredicate(ids);

            var enderecos = await _context.Enderecos
                .AsNoTracking()
                .Include(e => e.Cidade)
                .Include(e => e.Uf)
                .Where(usuarioPredicate)
                .OrderByDescending(e => e.UpdatedAt)
                .ToListAsync();

            return enderecos
                .GroupBy(e => e.Usuario)
                .ToDictionary(g => g.Key, g => g.First());
        }

        private static Expression<Func<Endereco, bool>> BuildUsuarioIdsPredicate(IReadOnlyCollection<int> ids)
        {
            var parameter = Expression.Parameter(typeof(Endereco), "e");
            Expression body = Expression.Constant(false);

            foreach (var id in ids)
            {
                var usuarioProperty = Expression.Property(parameter, nameof(Endereco.Usuario));
                var idConstant = Expression.Constant(id);
                var equals = Expression.Equal(usuarioProperty, idConstant);
                body = Expression.OrElse(body, equals);
            }

            return Expression.Lambda<Func<Endereco, bool>>(body, parameter);
        }
    }
}
