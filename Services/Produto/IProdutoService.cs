using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Produto
{
    public interface IProdutoService
    {
        public Task<List<ProdutoDTO>> GetAll(int estabelecimentoId);
        public Task<ProdutoDTO> GetByID(int id,int estabelecimentoId);
    }
}
