using comaagora.DTO;

namespace comaagora.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<List<GetCategoriaDTO>> GetCategorias(string slug);
    }
}
