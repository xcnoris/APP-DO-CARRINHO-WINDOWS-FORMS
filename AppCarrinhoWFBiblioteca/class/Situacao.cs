
using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
namespace AppCarrinhoWFBiblioteca
{

    public class Situacao
    {
        public bool Status;
        public string Mensagem;
        public string Id { get; set; }
        public string Nome { get; set; }

        public static ICollection<Situacao> Situacoes = new List<Situacao>();

        public Situacao()
        {
            Status = true;
        }


        public void ConsultarDisponibilidadeInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT id, nome FROM tb_situacao";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de carrinhos antes de adicionar os novos resultados
                Situacoes.Clear();

                // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
                foreach (DataRow row in result.Rows)
                {
                    Situacao situacoes = new Situacao
                    {
                        Id = row["ID"].ToString(),
                        Nome = row["nome"].ToString()

                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    Situacoes.Add(situacoes);
                    // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados

                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }
    }

}
