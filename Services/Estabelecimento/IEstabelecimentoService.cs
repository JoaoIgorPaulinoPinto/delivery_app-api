using comaagora.DTO;

namespace comaagora.Services.Estabelecimento
{
    public interface IEstabelecimentoService
    {
        Task<GetEstabelecimentoDTO?> GetBySlug(string slug);
    }
}
