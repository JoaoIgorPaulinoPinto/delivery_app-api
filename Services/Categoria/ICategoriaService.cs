using comaagora.DTO;
using System.Reflection.Metadata;

namespace comaagora.Services.Categoria
{
    public interface ICategoriaService 
    {
        public Task<List<GetCateriaDTO>> GetCategorias(string slug);
    }
}
