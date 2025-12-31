using comaagora.DTO;
using comaagora.Models;

namespace comaagora.Services.Produto
{
    public interface IProdutoService
    {
        public Task<List<GetProdutoDTO>> GetAll(string slug);
        public Task<GetProdutoDTO> GetByID(int id);
        public Task<bool> Update(CreateProdutoDTO produto, int id);
        public Task<bool> CreateProduto(CreateProdutoDTO dto, int id);
    }
}
