using AppCarrinhoWFBiblioteca.carrinho1;
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

namespace AppCarrinhoWFBiblioteca.clientes
{
    public class PessoaService
    {
        public string Mensagem { get; set; }
        public bool Status { get; set; }

        public PessoaService()
        {
            Status = true;
        }

        public ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

        public void AddCliente(Pessoa cliente)
        {
            cliente.ValidarClass();
            Pessoas.Add(cliente);
        }

        // Transforma Json em Class
        public static Pessoa DeserializeCliente(string vJson)
        {
            return JsonConvert.DeserializeObject<Pessoa>(vJson);
        }

        // Transforma Class em Json
        public static string SerializeCliente(Pessoa cliente)
        {
            return JsonConvert.SerializeObject(cliente);
        }
        public void IncluirPessoaInDB(ConexaoDB conexaoDB, Pessoa pessoa)
        {
            Status = true;
            try
            {
                string query = "INSERT INTO tb_pessoa (cpf, nome, cep, cidade, uf, endereco, numero, complemento, bairro, telefone_ddd,telefone_numero, celular_ddd, celular_numero, sexo, data_nascimento, email, congregacao_id) " +
                               "VALUES (@cpf, @nome, @cep, @cidade, @uf,@endereco, @numero, @complemento, @bairro, @telefone_ddd,@telefone_numero,@celular_ddd, @celular_numero, @sexo, @data_nascimento, @email, @congregacao_id)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@cpf", pessoa.CPF);
                    cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                    cmd.Parameters.AddWithValue("@cep", pessoa.CEP);
                    cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade_Nome);
                    cmd.Parameters.AddWithValue("@uf", pessoa.UF);
                    cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                    cmd.Parameters.AddWithValue("@numero", pessoa.Endereco_Numero);
                    cmd.Parameters.AddWithValue("@complemento", pessoa.Endereco_Complemento);
                    cmd.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                    cmd.Parameters.AddWithValue("@telefone_ddd", pessoa.DDD_Telefone);
                    cmd.Parameters.AddWithValue("@telefone_numero", pessoa.Telefone);
                    cmd.Parameters.AddWithValue("@celular_ddd", pessoa.DDD_Celular);
                    cmd.Parameters.AddWithValue("@celular_numero", pessoa.Celular);
                    cmd.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                    cmd.Parameters.AddWithValue("@data_nascimento", pessoa.DataNascimento);
                    cmd.Parameters.AddWithValue("@email", pessoa.Email);
                    cmd.Parameters.AddWithValue("@congregacao_id", pessoa.Congregacao_ID);

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

        public void AtualizarPessoaInDB(ConexaoDB conexaoDB, Pessoa pessoa)
        {
            Status = true;
            try
            {
                string query = "UPDATE tb_pessoa SET " +
                               "cpf = @cpf, " +
                               "nome = @nome, " +
                               "cep = @cep, " +
                               "cidade = @cidade, " +
                               "uf = @uf, " +
                               "endereco = @endereco, " +
                               "numero = @numero, " +
                               "complemento = @complemento, " +
                               "bairro = @bairro, " +
                               "telefone_ddd = @telefone_ddd, " +
                               "telefone_numero = @telefone_numero, " +
                               "celular_ddd = @celular_ddd, " +
                               "celular_numero = @celular_numero, " +
                               "sexo = @sexo, " +
                               "data_nascimento = @data_nascimento, " +
                               "email = @email, " +
                               "congregacao_id = @congregacao_id " +
                               "WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection()))
                {
                    //campos opcionais (que podem ser nulos) são tratados com DBNull.Value se forem null.
                    cmd.Parameters.AddWithValue("@id", pessoa.ID);
                    cmd.Parameters.AddWithValue("@cpf", pessoa.CPF);
                    cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                    cmd.Parameters.AddWithValue("@cep", pessoa.CEP ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade_Nome ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@uf", pessoa.UF ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@numero", pessoa.Endereco_Numero ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@complemento", pessoa.Endereco_Complemento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@bairro", pessoa.Bairro ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefone_ddd", pessoa.DDD_Telefone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefone_numero", pessoa.Telefone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@celular_ddd", pessoa.DDD_Celular ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@celular_numero", pessoa.Celular ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@sexo", pessoa.Sexo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@data_nascimento", pessoa.DataNascimento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", pessoa.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@congregacao_id", pessoa.Congregacao_ID ?? (object)DBNull.Value);

                    conexaoDB.OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conexaoDB.CloseConnection();

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


        // Consulta todas as pessoas no banco de dados
        public void ConsultarPessoasInDB(ConexaoDB conexaoDB)
        {
            Status = true;
            try
            {
                string querySelect = "SELECT * FROM tb_pessoa";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de pessoas antes de adicionar os novos resultados
                Pessoas.Clear();

                // Itera pelas linhas do resultado e adiciona cada pessoa à lista Pessoas
                foreach (DataRow row in result.Rows)
                {
                    Pessoa pessoa = new Pessoa
                    {
                        //ID = Convert.ToInt32(row["id"]),
                        ID = row["id"].ToString(),
                        CPF = row["cpf"].ToString(),
                        Nome = row["nome"].ToString(),
                        CEP = row["cep"].ToString(),
                        Cidade_Nome = row["cidade"].ToString(),
                        UF = row["uf"].ToString(),
                        Endereco = row["endereco"].ToString(),
                        Endereco_Numero = row["numero"].ToString(),
                        Endereco_Complemento = row["complemento"].ToString(),
                        Bairro = row["bairro"].ToString(),
                        DDD_Telefone = row["telefone_ddd"].ToString(),
                        Telefone = row["telefone_numero"].ToString(),
                        DDD_Celular = row["celular_ddd"].ToString(),
                        Celular = row["celular_numero"].ToString(),
                        Sexo = row["sexo"].ToString(),
                        DataNascimento = row["data_nascimento"].ToString(),
                        Email = row["email"].ToString(),
                        Congregacao_ID = row["congregacao_id"].ToString()
                    };

                    Pessoas.Add(pessoa);
                }
                Mensagem = comandosDB.Mensagem;
            }
            catch (MySqlException ex)
            {
                Status = false;
                Mensagem = "Erro ao consultar pessoas no banco de dados: " + ex.Message;
            }
        }

        public void ConsultarCarrinhosPorID(ConexaoDB conexaoDB, string Id)
        {
            Status = true;
            try
            {
                string querySelect = $"SELECT * FROM tb_carrinho WHERE ID = {Id}";

                // Utiliza um objeto ComandosDB para executar a consulta e obter o resultado
                ComandosDB comandosDB = new ComandosDB(conexaoDB);
                DataTable result = comandosDB.ExecuteQuery(querySelect);

                // Limpa a lista de carrinhos antes de adicionar os novos resultados
                Pessoas.Clear();

                // Itera pelas linhas do resultado e adiciona cada carrinho à lista Carrinhos
                foreach (DataRow row in result.Rows)
                {
                    Pessoa pessoa = new Pessoa
                    {
                        //ID = Convert.ToInt32(row["id"]),
                        ID = row["id"].ToString(),
                        CPF = row["cpf"].ToString(),
                        Nome = row["nome"].ToString(),
                        CEP = row["cep"].ToString(),
                        Cidade_Nome = row["cidade"].ToString(),
                        UF = row["uf"].ToString(),
                        Endereco = row["endereco"].ToString(),
                        Endereco_Numero = row["numero"].ToString(),
                        Endereco_Complemento = row["complemento"].ToString(),
                        Bairro = row["bairro"].ToString(),
                        DDD_Telefone = row["telefone_ddd"].ToString(),
                        Telefone = row["telefone_numero"].ToString(),
                        DDD_Celular = row["celular_ddd"].ToString(),
                        Celular = row["celular_numero"].ToString(),
                        Sexo = row["sexo"].ToString(),
                        DataNascimento = row["data_nascimento"].ToString(),
                        Email = row["email"].ToString(),
                        Congregacao_ID = row["congregacao_id"].ToString()
                    };

                    Pessoas.Add(pessoa);
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
