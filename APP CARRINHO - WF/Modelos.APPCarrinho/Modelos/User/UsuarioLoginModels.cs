using Microsoft.AspNetCore.Identity;
using Modelos.APPCarrinho.Enuns;

namespace Modelos.APPCarrinho.Modelos.User
{
    public class UsuarioLoginModels : IdentityUser
    {
        public string NomeCompleto { get; set; }
        public int CongregacaoId { get; set; }
        public TipoUser TipoUser{ get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
