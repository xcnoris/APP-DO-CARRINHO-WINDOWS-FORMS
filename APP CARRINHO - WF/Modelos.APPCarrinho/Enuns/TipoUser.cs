using System.ComponentModel;

namespace Modelos.APPCarrinho.Enuns
{
    public enum TipoUser
    {
        [Description("Admin")]
        Admin = 1,

        [Description("Responsavel Carrinho")]
        RespCarrinho = 2,

        [Description("Responsavel Designações")]
        RespDesignacoes = 3,

    }
}
