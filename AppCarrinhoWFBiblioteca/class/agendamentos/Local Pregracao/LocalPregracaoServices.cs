using AppCarrinhoWFBiblioteca.classagendamento;
using AppCarrinhoWFBiblioteca.Situacao;
using AppCarrinhoWFBiblioteca.Interfaces;
using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1
{
    public class LocalPregracaoServices : ICrud<LocalPregacao>
    {
        public string Mensagem { get; set; }
        public bool Status;

        public ICollection<LocalPregacao> LocaisPregracao { get; set; } = new List<LocalPregacao>();

        public LocalPregracaoServices()
        {
            Status = true;
        }


        //Class de criar um novo registro do local de pregacao no Banco de dados
        public void CreateInDB(ConexaoDB conexaoDB, LocalPregacao localPregracao)
        {
            Status = true;
            try
            {

                string query = @"INSERT INTO tb_localpregacao 
                                    ( nome, descricao, endereco, complemento, bairro, cidade, uf, datacriacao, id_situacao)
                                VALUES 
                                    (@nome, @descricao, @endereco, @complemento, @bairro, @Cidade, @uf , @datacriacao, @id_situacao)
                               ";

                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    //cmd.Parameters.AddWithValue("@ID", carrinhoUnit.ID);
                    cmd.Parameters.AddWithValue("@nome", localPregracao.Nome);
                    cmd.Parameters.AddWithValue("@descricao", localPregracao.Descricao);
                    cmd.Parameters.AddWithValue("@endereco", localPregracao.Endereco);
                    cmd.Parameters.AddWithValue("@complemento", localPregracao.Complemento);
                    cmd.Parameters.AddWithValue("@bairro", localPregracao.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", localPregracao.Cidade);
                    cmd.Parameters.AddWithValue("@uf", localPregracao.UF);
                    cmd.Parameters.AddWithValue("@datacriacao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id_situacao", localPregracao.IdSituacao.Id);
                    

                    conexaoDB.OpenConnection();
                    cmd.ExecuteNonQuery();
                }
                Mensagem = "Local de pregação incluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao incluir local de pregação no banco de dados: " + ex.Message;
            }
            catch (Exception ex) 
            {
                Status = false;
                Mensagem = "Erro ao incluir novo local de pregação no banco de dados: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
        }


        // Consulta um registro de agendamento no banco de dados
        public void ReadInDB(ConexaoDB conexaoDB, string Id)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT * FROM tb_localpregacao WHERE id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(querySelect, conexaoDB.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conexaoDB.OpenConnection();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        LocaisPregracao.Clear();
                        while (reader.Read())
                        {
                            LocalPregacao localPregacao = new LocalPregacao
                            {
                                Id = (int)reader["id"],
                                Nome = reader["nome"].ToString(),
                                Descricao = reader["descricao"].ToString(),
                                Endereco = reader["endereco"].ToString(),
                                Complemento = reader["complemento"].ToString(),
                                Bairro = reader["bairro"].ToString(),
                                Cidade = reader["cidade"].ToString(),
                                UF = reader["uf"].ToString(),
                                IdSituacao = new Situacao1
                                {
                                    Id = (int)reader["id_situacao"]
                                }
                            };

                            LocaisPregracao.Add(localPregacao);
                        }
                    }
                }
                Mensagem = "Consulta realizada com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar Locais de pregação no banco de dados: " + ex.Message;
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar Locais de pregação no banco de dados: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
        }


        // Consulta todos os Locais de pregacao no banco de dados
        public void ReadAllInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {

                string querySelect = "SELECT * FROM tb_localpregacao";

                using (MySqlCommand cmd = new MySqlCommand(querySelect, conexaoDB.GetConnection()))
                {
                    conexaoDB.OpenConnection();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        LocaisPregracao.Clear();
                        while (reader.Read())
                        {
                            LocalPregacao localPregacao = new LocalPregacao
                            {
                                Id = (int)reader["id"],
                                Nome = reader["nome"].ToString(),
                                Descricao = reader["descricao"].ToString(),
                                Endereco = reader["endereco"].ToString(),
                                Complemento = reader["complemento"].ToString(),
                                Bairro = reader["bairro"].ToString(),
                                Cidade = reader["cidade"].ToString(),
                                UF = reader["uf"].ToString(),
                                IdSituacao = new Situacao1
                                {
                                    Id = (int)reader["id_situacao"]
                                }
                            };

                            LocaisPregracao.Add(localPregacao);
                        }
                    }
                }
                Mensagem = "Consulta realizada com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar Locais de pregação no banco de dados: " + ex.Message;
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar Locais de pregação no banco de dados: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
        }
        





        // Class de atualizar dado de locais de pregacao no banco de dados
        public void UpdateInDB(ConexaoDB conexaoDB, LocalPregacao localPregacao)
        {
            Status = true;
            try
            {
                string query = @"UPDATE tb_localpregacao SET 
                                    id = @id, nome = @nome, descricao = @descricao,
                                    endereco = @endereco, complemento = @complemento,
                                    bairro = @bairro, cidade = @cidade, uf = @uf ,
                                    id_situacao = @id_situacao
                                WHERE
                                    id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", localPregacao.Id);
                    cmd.Parameters.AddWithValue("@nome", localPregacao.Nome);
                    cmd.Parameters.AddWithValue("@descricao", localPregacao.Descricao);
                    cmd.Parameters.AddWithValue("@endereco", localPregacao.Endereco);
                    cmd.Parameters.AddWithValue("@complemento", localPregacao.Complemento);
                    cmd.Parameters.AddWithValue("@bairro", localPregacao.Bairro);
                    cmd.Parameters.AddWithValue("@cidade", localPregacao.Cidade);
                    cmd.Parameters.AddWithValue("@uf", localPregacao.UF);
                    cmd.Parameters.AddWithValue("@id_situacao", localPregacao.IdSituacao.Id);


                    conexaoDB.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    if (rowsAffected > 0)
                    {
                        Status = true;
                        Mensagem = "Local de pregação atualizado com sucesso!";
                    }
                    else
                    {
                        Status = false;
                        Mensagem = "Nenhum Local de pregação foi atualizado.";
                    }

                }
                Mensagem = "Local de pregação atualizado com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao atualizar local de pregação no banco de dados: " + ex.Message;
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao atualizar local de pregação no banco de dados: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
        }

        public void DeleteInDB(ConexaoDB conexaoDB, string Id)
        {
            try
            {
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                string query = $"DELETE FROM tb_localpregacao WHERE id = {Id}";

                int affectedRows = comandosDB.ExecuteNonQuery(query);

                if (affectedRows > 0)
                {
                    Status = true;
                    Mensagem = "Local de pregação excluido com sucesso!";
                }
                else
                {
                    Status = false;
                    Mensagem = $"ID {Id} não existe no banco de dados!";
                }
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao Excluir Local de pregação no banco de dados: " + ex.Message;
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao Excluir Local de pregação no banco de dados: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
        }

    }
}
