using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace banco.DAL.DataBases
{
    public class ComandosDB
    {

        private ConexaoDB conexaoDB;
        public string Mensagem;
        public ComandosDB(ConexaoDB conexao)
        {
            conexaoDB = conexao;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                conexaoDB.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Mensagem =  "Erro ao executar a consulta: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
            Mensagem = "Consulta executada com sucesso!";
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            int affectedRows = 0;
            try
            {
                conexaoDB.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection());
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Mensagem = "Erro ao executar a consulta: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
            return affectedRows;
        }

        public object ExecuteScalar(string query)
        {
            object result = null;
            try
            {
                conexaoDB.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, conexaoDB.GetConnection());
                result = cmd.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                Mensagem = "Erro ao executar a consulta: " + ex.Message;
            }
            finally
            {
                conexaoDB.CloseConnection();
            }
            return result;
        }

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
    }
}
