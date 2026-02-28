using comaagora.DTO;

namespace comaagora.Services.Produto
{
    public interface IProdutoService
    {
        Task<List<GetProdutoDTO>> GetAll(string slug);
        Task<GetProdutoDTO> GetById(int id);
        Task<bool> Update(CreateProdutoDTO produto, int id);
        Task<bool> CreateProduto(CreateProdutoDTO dto, int estabelecimentoId);
    }
}
