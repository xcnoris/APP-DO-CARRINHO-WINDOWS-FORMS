using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ConsultarTiposDeUsuarioInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT * FROM tb_categoriauser";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de tipos de usuários antes de adicionar os novos resultados
                Tipos.Clear();

                // Itera pelas linhas do resultado e adiciona cada tipo de usuário à lista
                foreach (DataRow row in result.Rows)
                {
                    TipoUser tipo = new TipoUser
                    {
                        Id = row["id"].ToString(),
                        Nome = row["nome"].ToString()
                    };

                    Tipos.Add(tipo);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar tipos de usuários no banco de dados: " + ex.Message;
            }
        }
    }
}
