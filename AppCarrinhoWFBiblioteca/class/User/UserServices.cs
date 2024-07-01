using AppCarrinhoWFBiblioteca.clientes;
using AppCarrinhoWFBiblioteca.Interfaces;
using AppCarrinhoWFBiblioteca.Users;
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
    public class UserServices : ICrud<User1>
    {
        public string Mensagem { get; set; }
        public bool Status { get; set; }
        public ICollection<User1> usuarios { get; set; } = new List<User1>();

        //Construtor
        public UserServices()
        {
            Status = true;
        }

        // Método para incluir um usuário no banco de dados
        public void CreateInDB(ConexaoDB conexaoDB, User1 user)
        {
            Status = true;
            try
            {
                // Query para inserir um novo registro na tabela tb_pessoa
                string query = "INSERT INTO tb_pessoa ( nome,  login, senha, situacao, datacriacao, cpf ) " +
                               "VALUES (@nome, @login, @senha, @situacao, @datacriacao, @cpf)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    // Adiciona os parâmetros à query
                    cmd.Parameters.AddWithValue("@nome", user.Nome);
                    //cmd.Parameters.AddWithValue("@tipo", user.Id_Tipo);
                    cmd.Parameters.AddWithValue("@login", user.Login);
                    cmd.Parameters.AddWithValue("@senha", user.Senha);
                    cmd.Parameters.AddWithValue("@situacao", user.Id_Situacao);
                    cmd.Parameters.AddWithValue("@datacriacao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@cpf", user.CPF);

                    // Abre a conexão, executa a query e fecha a conexão
                    conexaoDB.OpenConnection();
                    cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();
                }
                Mensagem = "Pessoa incluída com sucesso!";
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao incluir pessoa no banco de dados: " + ex.Message;
            }
        }

        // Método para consultar um registro pelo ID no banco de dados
        public void ReadInDB(ConexaoDB conexaoDB, string id)
        {
            Status = true;
            try
            {
                // Query para selecionar um registro pelo ID
                string querySelect = $"SELECT * FROM tb_user WHERE ID = {id}";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de usuários antes de adicionar os novos resultados
                usuarios.Clear();

                // Itera pelas linhas do resultado e adiciona cada usuário à lista
                foreach (DataRow row in result.Rows)
                {
                    User1 user = new User1
                    {
                        Id = row["id"].ToString(),
                        CPF = row["cpf"].ToString(),
                        Nome = row["nome"].ToString(),
                        Id_Tipo = row["tipo"].ToString(),
                        Login = row["login"].ToString(),
                        Senha = row["senha"].ToString(),
                        Id_Situacao = row["situacao"].ToString(),
                    };

                    usuarios.Add(user);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar usuários no banco de dados: " + ex.Message;
            }
        }

        // Método para consultar todos os registros no banco de dados
        public void ReadAllInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                // Query para selecionar todos os registros
                string querySelect = "SELECT * FROM tb_user";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de usuários antes de adicionar os novos resultados
                usuarios.Clear();

                // Itera pelas linhas do resultado e adiciona cada usuário à lista
                foreach (DataRow row in result.Rows)
                {
                    User1 user = new User1
                    {
                        Id = row["id"].ToString(),
                        CPF = row["cpf"].ToString(),
                        Nome = row["nome"].ToString(),
                        Id_Tipo = row["tipo"].ToString(),
                        Login = row["login"].ToString(),
                        Senha = row["senha"].ToString(),
                        Id_Situacao = row["situacao"].ToString(),
                    };

                    usuarios.Add(user);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar usuários no banco de dados: " + ex.Message;
            }
        }

        // Método para atualizar um registro no banco de dados
        public void UpdateInDB(ConexaoDB conexaoDB, User1 user)
        {
            Status = true;
            try
            {
                // Query para atualizar um registro na tabela tb_pessoa
                string query = "UPDATE tb_pessoa SET " +
                               "cpf = @cpf, " +
                               "nome = @nome, " +
                               "tipo = @tipo, " +
                               "login = @login, " +
                               "senha = @senha, " +
                               "situacao = @situacao " +
                               "WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    // Adiciona os parâmetros à query
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@cpf", user.CPF);
                    cmd.Parameters.AddWithValue("@nome", user.Nome);
                    cmd.Parameters.AddWithValue("@tipo", user.Id_Tipo);
                    cmd.Parameters.AddWithValue("@login", user.Login);
                    cmd.Parameters.AddWithValue("@senha", user.Senha);
                    cmd.Parameters.AddWithValue("@situacao", user.Id_Situacao);

                    // Abre a conexão, executa a query e fecha a conexão
                    conexaoDB.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();

                    // Verifica se algum registro foi atualizado
                    if (rowsAffected > 0)
                    {
                        Status = true;
                        Mensagem = "Pessoa atualizada com sucesso!";
                    }
                    else
                    {
                        Status = false;
                        Mensagem = "Nenhuma pessoa foi atualizada.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao atualizar pessoa no banco de dados: " + ex.Message;
            }
        }

        // Método para deletar um registro no banco de dados
        public void DeleteInDB(ConexaoDB conexaoDB, string id)
        {
            Status = true;
            try
            {
                // Query para deletar um registro pelo ID
                string query = "DELETE FROM tb_user WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    // Adiciona o parâmetro ID à query
                    cmd.Parameters.AddWithValue("@id", id);

                    // Abre a conexão, executa a query e fecha a conexão
                    conexaoDB.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();

                    // Verifica se algum registro foi deletado
                    if (rowsAffected > 0)
                    {
                        Status = true;
                        Mensagem = "Usuário deletado com sucesso!";
                    }
                    else
                    {
                        Status = false;
                        Mensagem = "Nenhum usuário foi deletado.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao deletar usuário no banco de dados: " + ex.Message;
            }
        }
    }
}
