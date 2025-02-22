
using Modelos.APPCarrinho.Enuns;
using System.ComponentModel.DataAnnotations;

namespace API.Modelos
{
    public class CriarUsuarioModel
    {
        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public int CongregacaoId { get; set; }
        public TipoUser Tipo_User { get; set; }
    }
}