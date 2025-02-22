using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.IntegradorCRM.Data.DataBase
{
    public class ComandosDB
    {
        private ConexaoDB _conexaoDB;
        public string Mensagem { get; private set; }



        // Metodo para transformar senha em hash
        public static string GetMD5Hasg(string senha)
        {
            MD5 md5 = MD5.Create();
            // Converte a string da senha para um array de byte e calcula o hash
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));

            // Cria uma nova stringbuilder para coletar os bytes e criar a string
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public async Task<DataTable> ExecuteQuery(string query, SqlParameter[] parametros = null)
        {
            _conexaoDB = new ConexaoDB("String para evitar loop");

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = _conexaoDB.GetConnection())
                {
                    await _conexaoDB.OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (parametros != null)
                        {
                            cmd.Parameters.AddRange(parametros);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                Mensagem = "Consulta executada com sucesso!";
            }
            catch (SqlException ex)
            {
                Mensagem = "Erro ao executar a consulta: " + ex.Message;
                MetodosGerais.RegistrarLog("CRUDs", $"[ERROR]: Ocorreu um erro ao executar o comando 'ExecuteQuery'. Mensagem: {ex.Message}");
            }
            finally
            {
                _conexaoDB.CloseConnection();
            }
            return dt;
        }

        public async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object> parametros = null)
        {

            _conexaoDB = new ConexaoDB("String para evitar loop");

            int linhasAfetadas = 0;
            try
            {
                using (SqlConnection connection = _conexaoDB.GetConnection())
                {
                    await _conexaoDB.OpenConnection();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (parametros != null)
                        {
                            foreach (var param in parametros)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        linhasAfetadas = await cmd.ExecuteNonQueryAsync();
                    }
                }
                Mensagem = "Operação realizada com sucesso!";
            }
            catch (SqlException ex)
            {
                Mensagem = "Erro ao executar a operação: " + ex.Message;
                MetodosGerais.RegistrarLog("CRUDs",$"[ERROR]: Ocorreu um erro ao executar o comando 'ExecuteNonQueryAsync'. Mensagem: {ex.Message}");
            }
            finally
            {
                _conexaoDB.CloseConnection();
            }
            return linhasAfetadas;
        }
    }
}
