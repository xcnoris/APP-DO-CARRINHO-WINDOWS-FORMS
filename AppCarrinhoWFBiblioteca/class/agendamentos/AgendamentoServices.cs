using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.classagendamento;
using AppCarrinhoWFBiblioteca.Interfaces;
using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.agendamentos
{
    public class AgendamentoServices : ICrud<Agendameto>
    {

        public string Mensagem { get; set; }
        public bool Status;

        public ICollection<Agendameto> Agendamentos { get; set; } = new List<Agendameto>();

        public AgendamentoServices()
        {
            Status = true;
        }


        //Class de criar um novo registro de carrinho no Banco de dados
        public void CreateInDB(ConexaoDB conexaoDB, Agendameto agendamento)
        {
            Status = true;
            try
            {

                string query = "INSERT INTO tb_agendamento (IdSituacao, IdCategoria, IdPessoa, IdCarrinho, DataAgendamento, Hora1, Hora2, Local1, DataCriacao) VALUES (@idSituacao, @idcategoria, @idpessoa, @idcarrinho, @dataagendamento, @hora1, @hora2, @local, @datacriacao;";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    //cmd.Parameters.AddWithValue("@ID", carrinhoUnit.ID);
                    cmd.Parameters.AddWithValue("@idSituacao", agendamento.IdSituacao);
                    cmd.Parameters.AddWithValue("@idcategoria", agendamento.IdCategoria);
                    cmd.Parameters.AddWithValue("@idpessoa", agendamento.IdPessoa);
                    cmd.Parameters.AddWithValue("@idcarrinho", agendamento.IdCarrinho);
                    cmd.Parameters.AddWithValue("@dataagendamento", agendamento.DataAgendamento);
                    cmd.Parameters.AddWithValue("@hora1", agendamento.Hora1);
                    cmd.Parameters.AddWithValue("@hora2", agendamento.Hora2);
                    cmd.Parameters.AddWithValue("@local", agendamento.Local);
                    cmd.Parameters.AddWithValue("@datacriacao", DateTime.Now);

                    conexaoDB.OpenConnection();
                    cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();
                }
                Mensagem = "Agendamento incluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao incluir novo agendamento no banco de dados: " + ex.Message;
            }
        }


        // Consulta um registro de agendamento no banco de dados
        public void ReadInDB(ConexaoDB conexaoDB, string Id)
        {
            Status = true;
            try
            {
                string querySelect = $"select * from tb_agendamento WHERE ID = {Id}";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de agendamentos antes de adicionar os novos resultados
                Agendamentos.Clear();

                // Itera pelas linhas do resultado e adiciona cada agendamento à lista agendamentos
                foreach (DataRow row in result.Rows)
                {
                    Agendameto agendamento = new Agendameto
                    {
                        Id = row["IdAgendamento"].ToString(),
                        IdSituacao = row["IdSituacao"].ToString(),
                        IdCategoria = row["IdCategoria"].ToString(),
                        IdPessoa = row["IdPesso"].ToString(),
                        IdCarrinho = row["IdCarrinho"].ToString(),
                        DataAgendamento = row["DataAgendamento"].ToString(),
                        Hora1 = row["Hora1"].ToString(),
                        Hora2 = row["Hora2"].ToString(),
                        Local = row["Local1"].ToString(),
                        DataCriacao = row["DataCriacao"].ToString(),
                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    Agendamentos.Add(agendamento);
                }
                
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
            }
        }

        // Consulta todos os agendamentos no banco de dados
        public void ReadAllInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "select * from tb_agendamento;";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de agendamentos antes de adicionar os novos resultados
                Agendamentos.Clear();

                // Itera pelas linhas do resultado e adiciona cada agendamento à lista agendamentos
                foreach (DataRow row in result.Rows)
                {
                    Agendameto agendamento = new Agendameto
                    {
                        Id = row["IdAgendamento"].ToString(),
                        IdSituacao = row["IdSituacao"].ToString(),
                        IdCategoria = row["IdCategoria"].ToString(),
                        IdPessoa = row["IdPesso"].ToString(),
                        IdCarrinho = row["IdCarrinho"].ToString(),
                        DataAgendamento = row["DataAgendamento"].ToString(),
                        Hora1 = row["Hora1"].ToString(),
                        Hora2 = row["Hora2"].ToString(),
                        Local = row["Local1"].ToString(),
                        DataCriacao = row["DataCriacao"].ToString(),
                        // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
                    };

                    Agendamentos.Add(agendamento);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar agendamentos no banco de dados: " + ex.Message;
            }
        }

        // Class de atualizar dado de agendamento no banco de dados
        public void UpdateInDB(ConexaoDB conexaoDB, Agendameto agendamento)
        {
            Status = true;
            try
            {
                string query = "UPDATE tb_agendamento SET IdSituacao = @idsituacao, IdCategoria = @idcategoria, IdPessoa = @idpessoa, IdCarrinho = @idcarrinho, DataAgendamento = @dataagendamento, Hora1 = @hora1, Hora2 = @hora2, Local1 = @local WHERE ID = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", agendamento.Id);
                    cmd.Parameters.AddWithValue("@idsituacao", agendamento.IdSituacao);
                    cmd.Parameters.AddWithValue("@idcategoria", agendamento.IdCategoria);
                    cmd.Parameters.AddWithValue("@idpessoa", agendamento.IdPessoa);
                    cmd.Parameters.AddWithValue("@idcarrinho", agendamento.IdCarrinho);
                    cmd.Parameters.AddWithValue("@dataagendamento", agendamento.DataAgendamento);
                    cmd.Parameters.AddWithValue("@hora1", agendamento.Hora1);
                    cmd.Parameters.AddWithValue("@hora2", agendamento.Hora2);
                    cmd.Parameters.AddWithValue("@local", agendamento.Local);


                    conexaoDB.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();
                    if (rowsAffected > 0)
                    {
                        Status = true;
                        Mensagem = "Agendamento atualizado com sucesso!";
                    }
                    else
                    {
                        Status = false;
                        Mensagem = "Nenhum Agendamento foi atualizado.";
                    }

                }
                Mensagem = "Agendamento atualizado com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao atualizar agendamento no banco de dados: " + ex.Message;
            }
        }

        public void DeleteInDB(ConexaoDB conexaoDB, string Id)
        {
            try
            {
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                string query = $"DELETE FROM tb_agendamento WHERE ID = '{Id}'";

                int affectedRows = comandosDB.ExecuteNonQuery(query);

                if (affectedRows > 0)
                {
                    Status = true;
                    Mensagem = "Agendamento excluido com sucesso!";
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
                Mensagem = "Erro ao Excluir agendamento no banco de dados: " + ex.Message;
            }
        }


        //// Consulta um registro de agendamento no banco de dados
        //public void FiltrarPorNome(ConexaoDB conexaoDB, string Nome)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT* FROM tb_carrinho WHERE nome LIKE '%{Nome}%'";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //                // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        //return Carrinhos;
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}


        // Consulta um registro de carrinho no banco de dados
        //public void FiltrarPorCodigoCarrinhoENome(ConexaoDB conexaoDB, string Nome, string codigoCarrinho)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT * FROM tb_carrinho WHERE nome LIKE '%{Nome}%' AND codigo_carrinho ='{codigoCarrinho}'";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //                // Certifique-se de ajustar os nomes das colunas conforme estão no banco de dados
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        //return Carrinhos;
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}

        //// Consulta um registro de carrinho no banco de dados com filtro de ID e Situação
        //public void FiltrarPorIDESituacao(ConexaoDB conexaoDB, string id, string situacao)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE ID = {id} AND situacao = '{situacao}'";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}

        //// Consulta um registro de carrinho no banco de dados com filtro de ID e Situação
        //public void FiltrarPorIDESituacaoECodigoCarrinho(ConexaoDB conexaoDB, string id, string situacao, string codigocarrinho)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT * FROM tb_carrinho WHERE ID = {id} AND situacao = '{situacao}' AND codigo_carrinho = {codigocarrinho}";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}

        //// Consulta um registro de carrinho no banco de dados com filtro de Situação
        //public void FiltrarPorSituacao(ConexaoDB conexaoDB, string situacao)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE situacao = '{situacao}'";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}

        //// Consulta um registro de carrinho no banco de dados com filtro de Situação
        //public void FiltrarPorSituacaoENome(ConexaoDB conexaoDB, string situacao, string nome)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE situacao = '{situacao}' AND  nome LIKE '%{nome}%'";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}



        //// Consulta um registro de carrinho no banco de dados com filtro de ID + Situação + Nome
        //public void FiltrarPorIDESituacaoNomeECodigoCarrinho(ConexaoDB conexaoDB, string situacao, string nome, string codigoCarrinho)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT * FROM tb_carrinho WHERE situacao = '{situacao}' AND nome ='{nome}' AND codigo_carrinho = '{codigoCarrinho}'";

        //        // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        // Limpa a lista de carrinhos antes de adicionar os novos resultados
        //        Agendamentos.Clear();

        //        // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}

        //public void FiltrarPorCodigoCarrinho(ConexaoDB conexaoDB, string codigoCarrinho)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT ID, nome, situacao, congregacao_id, codigo_carrinho FROM tb_carrinho WHERE codigo_carrinho = '{codigoCarrinho}'";

        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        Agendamentos.Clear();

        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}

        //// Método de filtragem por ID, Situação e Código de Carrinho
        //public void FiltrarPorSituacaoECodigoCarrinho(ConexaoDB conexaoDB, string situacao, string codigoCarrinho)
        //{
        //    Status = true;
        //    try
        //    {
        //        string querySelect = $"SELECT * FROM tb_carrinho WHERE  situacao = '{situacao}' AND codigo_carrinho ='{codigoCarrinho}'";

        //        ComandosDB comandosDB = new ComandosDB(conexaoDB);
        //        DataTable result = comandosDB.ExecuteQuery(querySelect);

        //        Agendamentos.Clear();

        //        foreach (DataRow row in result.Rows)
        //        {
        //            Carrinho1 carrinho = new Carrinho1
        //            {
        //                ID = row["ID"].ToString(),
        //                Nome = row["nome"].ToString(),
        //                Situacao = row["situacao"].ToString(),
        //                Congregacao_ID = row["congregacao_id"].ToString(),
        //                Codigo_Carrinho = row["codigo_carrinho"].ToString()
        //            };

        //            Agendamentos.Add(carrinho);
        //        }
        //        Mensagem = comandosDB.Mensagem;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Status = false;
        //        Mensagem = "Erro ao consultar carrinhos no banco de dados: " + ex.Message;
        //    }
        //}
    }
}
