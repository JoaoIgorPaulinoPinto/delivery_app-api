using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Produto
{
    public interface IProdutoService
    {
        public Task<List<GetProdutoDTO>> GetAll(int estabelecimentoId);
        public Task<GetProdutoDTO> GetByID(int id,string slug);
        public Task<bool> Update(CreateProdutoDTO produto, int id);
        public Task<bool> CreateProduto(CreateProdutoDTO dto, int id);
    }
}
