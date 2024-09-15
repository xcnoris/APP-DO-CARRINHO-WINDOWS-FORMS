using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.agendamentos.Categoria_Agendamento
{
    public class CategoriaAgendamento
    {

        public bool Status;
        public string Mensagem;
        public static ICollection<CategoriaAgendamento> categorias = new List<CategoriaAgendamento>();


        public string Id { get; set; }
        public string Nome { get; set; }


        public CategoriaAgendamento()
        {
            Status = true;
        }


        public void ConsultarCategoriaInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT id, nome FROM tb_categoriaagendamento";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de carrinhos antes de adicionar os novos resultados
                categorias.Clear();

                // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
                foreach (DataRow row in result.Rows)
                {
                    CategoriaAgendamento categoria = new CategoriaAgendamento
                    {
                        Id = row["ID"].ToString(),
                        Nome = row["nome"].ToString()

                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    categorias.Add(categoria);
                    // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados

                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar categorias de agendamento no banco de dados: " + ex.Message;
            }
        }

    }
}
