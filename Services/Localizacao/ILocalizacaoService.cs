using comaagora.DTO;

namespace comaagora.Services.Localizacao
{
    public interface ILocalizacaoService
    {
        Task<List<EstadoDTO>> GetEstadosAsync();
        Task<List<MunicipioDTO>> GetMunicipiosByEstadoIdAsync(int estadoId);
    }
}
