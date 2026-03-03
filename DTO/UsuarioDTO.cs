using System.ComponentModel.DataAnnotations;

namespace comaagora.DTO
{
    public class CreateUsuarioDTO
    {
        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Telefone { get; set; } = string.Empty;
    }

    //public class GetUsuarioDTO
    //{
    //    public string Nome { get; set; } = string.Empty;
    //    public string Telefone { get; set; } = string.Empty;
    //    public string ClientKey { get; set; } = string.Empty;
    //}
}
