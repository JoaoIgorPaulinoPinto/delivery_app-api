using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateUsuarioDTO
    {
        [Required] public string Nome { get; set; } = "";
        [Required] public string Telefone { get; set; } = "";
    }

    public class GetUsuarioDTO
    {
        [Required] public string Nome { get; set; } = "";
        [Required] public string Telefone { get; set; } = "";
        [Required] public string ClientKey { get; set; } = "";
    }

}
