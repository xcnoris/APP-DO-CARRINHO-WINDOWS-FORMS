using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.agendamentos.Situacao
{
    public class SituacaoAgendamento
    {
        public bool Status;
        public string Mensagem;
        public string Id { get; set; }
        public string Nome { get; set; }

        public static ICollection<SituacaoAgendamento> Situacoes = new List<SituacaoAgendamento>();

        public SituacaoAgendamento()
        {
            Status = true;
        }


        public void ConsultarDisponibilidadeInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT id, nome FROM tb_situacaoagendamento";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de carrinhos antes de adicionar os novos resultados
                Situacoes.Clear();

                // Itera pelas linhas do resultado e adiciona cada situacao à lista Situacoes
                foreach (DataRow row in result.Rows)
                {
                    SituacaoAgendamento situacoes = new SituacaoAgendamento
                    {
                        Id = row["id"].ToString(),
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
                Mensagem = "Erro ao consultar Situações de agendamento no banco de dados: " + ex.Message;
            }
        }

    }
}
