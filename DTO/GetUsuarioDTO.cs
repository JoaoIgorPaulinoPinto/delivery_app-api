namespace comaagora.DTO
{
    public class GetUsuarioDTO
    {
        public required string nome { get; set; }
        public required string telefone {  get; set; }
        public string? ClientKey { get; set; }
    }
}
