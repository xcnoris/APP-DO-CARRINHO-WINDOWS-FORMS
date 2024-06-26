using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.clientes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DataBases;
using System.Net.Http;
using banco.DataBases;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using banco.DAL.DataBases;
using System.Data;

namespace AppCarrinhoWFBiblioteca.carrinho
{
    public class CarrinhoService
    {
        public string Mensagem {  get; set; }
        public bool Status;

        public ICollection<Carrinho1> Carrinhos { get; set; } = new List<Carrinho1>();

        public CarrinhoService()
        {
            Status = true;
        }
        public void AdicionarCarrinho(Carrinho1 carrinho)
        {
            carrinho.ValidarClasse();
            Carrinhos.Add(carrinho);
        }

        public Carrinho1 BuscarPorID(string Id)
        {
            return Carrinhos.FirstOrDefault(c => c.ID == Id);
        }
        public static Carrinho1 DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Carrinho1>(vJson);
        }
        public static string SerializedClassUnit(Carrinho1 unit)
        {
            return JsonConvert.SerializeObject(unit);
        }

        public void IncluirCarrinhoInDB(ConexaoDB conexaoDB, Carrinho1 carrinhoUnit)
        {
            Status = true;
            try
            {
                string query = "INSERT INTO tb_carrinho ( nome, situacao, congregacao_id, codigo_carrinho, data_criacao) VALUES ( @nome, @situacao, @congregacao_id,@Codigo_Carrinho,@data_criacao)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    //cmd.Parameters.AddWithValue("@ID", carrinhoUnit.ID);
                    cmd.Parameters.AddWithValue("@Nome", carrinhoUnit.Nome);
                    cmd.Parameters.AddWithValue("@Situacao", carrinhoUnit.Situacao);
                    cmd.Parameters.AddWithValue("@Congregacao_ID", carrinhoUnit.Congregacao_ID);
                    cmd.Parameters.AddWithValue("@Codigo_Carrinho", carrinhoUnit.Codigo_Carrinho);
                    cmd.Parameters.AddWithValue("@Data_Criacao", DateTime.Now);
                    //cmd.Parameters.AddWithValue("@Congregacao_Nome", carrinhoUnit.Congregacao_Nome);

                    conexaoDB.OpenConnection();
                    cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();
                }
                Mensagem = "Carrinho incluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao incluir carrinho no banco de dados: " + ex.Message;
            }
        }
        public void AtualizarCarrinhoInDB(ConexaoDB conexaoDB, Carrinho1 carrinho)
        {
            Status = true;
            try
            {
                string query = "UPDATE Carrinho SET Nome = @Nome, Codigo_Carrinho = @Codigo_Carrinho, Situacao = @Situacao WHERE ID = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", carrinho.ID);
                    cmd.Parameters.AddWithValue("@Nome", carrinho.Nome);
                    cmd.Parameters.AddWithValue("@Codigo_Carrinho", carrinho.Codigo_Carrinho);
                    cmd.Parameters.AddWithValue("@Situacao", carrinho.Situacao);

                    
                    conexaoDB.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();
                    if (rowsAffected > 0)
                    {
                        Status = true;
                        Mensagem = "Carrinho atualizado com sucesso!";
                    }
                    else
                    {
                        Status = false;
                        Mensagem = "Nenhum carrinho foi atualizado.";
                    }
                    
                }
                Mensagem = "Carrinho incluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao incluir carrinho no banco de dados: " + ex.Message;
            }
        }


        // Consulta todos os carrinhos no banco de dados
        public void ConsultarCarrinhosInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de carrinhos antes de adicionar os novos resultados
                Carrinhos.Clear();

                // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
                foreach (DataRow row in result.Rows)
                {
                    Carrinho1 carrinho = new Carrinho1
                    {
                        ID = row["ID"].ToString(),
                        Nome = row["nome"].ToString(),
                        Situacao = row["situacao"].ToString(),
                        Congregacao_ID = row["congregacao_id"].ToString(),
                        Codigo_Carrinho = row["codigo_carrinho"].ToString()
                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    Carrinhos.Add(carrinho);
                }
                //return Carrinhos;
                Mensagem = comandosDB.Mensagem ;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        public void ConsultarCarrinhosPorID(ConexaoDB conexaoDB, string Id)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE ID = {Id}";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de carrinhos antes de adicionar os novos resultados
                Carrinhos.Clear();

                // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
                foreach (DataRow row in result.Rows)
                {
                    Carrinho1 carrinho = new Carrinho1
                    {
                        ID = row["ID"].ToString(),
                        Nome = row["nome"].ToString(),
                        Situacao = row["situacao"].ToString(),
                        Congregacao_ID = row["congregacao_id"].ToString(),
                        Codigo_Carrinho = row["codigo_carrinho"].ToString()
                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    Carrinhos.Add(carrinho);
                }
                //return Carrinhos;
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
