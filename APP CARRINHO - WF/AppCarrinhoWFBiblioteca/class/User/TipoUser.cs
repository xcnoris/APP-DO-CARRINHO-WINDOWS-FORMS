
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace AppCarrinhoWFBiblioteca.User
{
    public class TipoUser
    {


        public bool Status { get; set; }
        public string Mensagem { get; set; }

        public string Id { get; set; }
        public string Nome { get; set; }

        public static ICollection<TipoUser> Tipos = new List<TipoUser>();

        public TipoUser()
        {
            Status = true;
        }

     
        }
    }
}
