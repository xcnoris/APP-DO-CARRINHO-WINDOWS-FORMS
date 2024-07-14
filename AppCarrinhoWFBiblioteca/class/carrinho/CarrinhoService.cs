using AppCarrinhoWFBiblioteca.carrinho1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using banco.DataBases;
using MySql.Data.MySqlClient;
using banco.DAL.DataBases;
using System.Data;
using AppCarrinhoWFBiblioteca.Interfaces;
using AppCarrinhoWFBiblioteca.agendamentos.Categoria_Agendamento;

namespace AppCarrinhoWFBiblioteca.carrinho
{
    public class CarrinhoService : ICrud<Carrinho1>
    {
        public string Mensagem {  get; set; }
        public bool Status;

        public ICollection<Carrinho1> Carrinhos { get; set; } = new List<Carrinho1>();

        public CarrinhoService()
        {
            Status = true;
        }
     

        public static Carrinho1 DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Carrinho1>(vJson);
        }
        public static string SerializedClassUnit(Carrinho1 unit)
        {
            return JsonConvert.SerializeObject(unit);
        }


        //Class de criar um novo registro de carrinho no Banco de dados
        public void CreateInDB(ConexaoDB conexaoDB, Carrinho1 carrinhoUnit)
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


        // Consulta um registro de carrinho no banco de dados
        public void ReadInDB(ConexaoDB conexaoDB, int Id)
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

        // Consulta todos os carrinhos no banco de dados
        public void ReadAllInDB(ConexaoDB conexaoDB)
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
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        // Class de atualizar dado de carrinho no banco de dados
        public void UpdateInDB(ConexaoDB conexaoDB, Carrinho1 carrinho)
        {
            Status = true;
            try
            {
                string query = "UPDATE tb_carrinho SET Nome = @Nome, Codigo_Carrinho = @Codigo_Carrinho, Situacao = @Situacao WHERE ID = @ID";
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

        public void DeleteInDB(ConexaoDB conexaoDB, int Id)
        {
            try
            {
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                string query = $"DELETE FROM tb_carrinho WHERE ID = '{Id}'";

                int affectedRows = comandosDB.ExecuteNonQuery(query);

                if (affectedRows > 0)
                {
                    Status = true;
                    Mensagem = "Carrinho Excluida com sucesso!";
                }
                else
                {
                    Status = false;
                    Mensagem = $"ID {Id} não existe no banco de dados!";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao Excluir Carrinho no banco de dados: " + ex.Message;
            }
        }


        // Consulta um registro de carrinho no banco de dados
        public void FiltrarPorNome(ConexaoDB conexaoDB, string Nome)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT* FROM tb_carrinho WHERE nome LIKE '%{Nome}%'";

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


        // Consulta um registro de carrinho no banco de dados
        public void FiltrarPorCodigoCarrinhoENome(ConexaoDB conexaoDB, string Nome, string codigoCarrinho)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT * FROM tb_carrinho WHERE nome LIKE '%{Nome}%' AND codigo_carrinho ='{codigoCarrinho}'";

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

        // Consulta um registro de carrinho no banco de dados com filtro de ID e Situação
        public void FiltrarPorIDESituacao(ConexaoDB conexaoDB, string id, string situacao)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE ID = {id} AND situacao = '{situacao}'";

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
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        // Consulta um registro de carrinho no banco de dados com filtro de ID e Situação
        public void FiltrarPorIDESituacaoECodigoCarrinho(ConexaoDB conexaoDB, string id, string situacao,string codigocarrinho)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT * FROM tb_carrinho WHERE ID = {id} AND situacao = '{situacao}' AND codigo_carrinho = {codigocarrinho}";

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
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        // Consulta um registro de carrinho no banco de dados com filtro de Situação
        public void FiltrarPorSituacao(ConexaoDB conexaoDB, string situacao)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE situacao = '{situacao}'";

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
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        // Consulta um registro de carrinho no banco de dados com filtro de Situação
        public void FiltrarPorSituacaoENome(ConexaoDB conexaoDB, string situacao, string nome)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE situacao = '{situacao}' AND  nome LIKE '%{nome}%'";

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
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }



        // Consulta um registro de carrinho no banco de dados com filtro de ID + Situação + Nome
        public void FiltrarPorIDESituacaoNomeECodigoCarrinho(ConexaoDB conexaoDB, string situacao, string nome, string codigoCarrinho)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT * FROM tb_carrinho WHERE situacao = '{situacao}' AND nome ='{nome}' AND codigo_carrinho = '{codigoCarrinho}'";

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
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        public void FiltrarPorCodigoCarrinho(ConexaoDB conexaoDB, string codigoCarrinho)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE codigo_carrinho = '{codigoCarrinho}'";

                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                Carrinhos.Clear();

                foreach (DataRow row in result.Rows)
                {
                    Carrinho1 carrinho = new Carrinho1
                    {
                        ID = row["ID"].ToString(),
                        Nome = row["nome"].ToString(),
                        Situacao = row["situacao"].ToString(),
                        Congregacao_ID = row["congregacao_id"].ToString(),
                        Codigo_Carrinho = row["codigo_carrinho"].ToString()
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        // Método de filtragem por ID, Situação e Código de Carrinho
        public void FiltrarPorSituacaoECodigoCarrinho(ConexaoDB conexaoDB,  string situacao, string codigoCarrinho)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT * FROM tb_carrinho WHERE  situacao = '{situacao}' AND codigo_carrinho ='{codigoCarrinho}'";

                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                Carrinhos.Clear();

                foreach (DataRow row in result.Rows)
                {
                    Carrinho1 carrinho = new Carrinho1
                    {
                        ID = row["ID"].ToString(),
                        Nome = row["nome"].ToString(),
                        Situacao = row["situacao"].ToString(),
                        Congregacao_ID = row["congregacao_id"].ToString(),
                        Codigo_Carrinho = row["codigo_carrinho"].ToString()
                    };

                    Carrinhos.Add(carrinho);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        public void ConsultarIdENomeDeCarrinhoInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT id, nome, codigo_carrinho FROM tb_carrinho WHERE situacao =1 ";

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
                        Codigo_Carrinho = row["codigo_carrinho"].ToString()

                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    Carrinhos.Add(carrinho);
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
