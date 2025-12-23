using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateUsuarioDTO
    {
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
    }

    public class GetUsuarioDTO
    {
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string ClientKey { get; set; } = "";
    }

}
