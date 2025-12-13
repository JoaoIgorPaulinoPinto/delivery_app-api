namespace comaagora.Services
{
    public interface IEstabelecimentoService
    {
        public Task<int?> GetIdBySlug(string slug);
    }
}
