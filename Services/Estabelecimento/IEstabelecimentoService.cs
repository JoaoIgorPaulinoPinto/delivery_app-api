using comaagora.DTO;

namespace comaagora.Services.Estabelecimento
{
    public interface IEstabelecimentoService
    {
        public Task<GetEstabelecimentoDTO?> GetBySlug(string slug);
    }
}
