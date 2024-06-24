using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}
