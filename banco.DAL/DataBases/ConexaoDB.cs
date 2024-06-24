using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace banco.DataBases
{

    public class ConexaoDB
    {
        private MySqlConnection connection;
        private string connectionString;


        string server = "localhost";
        string database = "appcarrinho";
        string user = "root";
        string password = "password";

        public ConexaoDB()
        {
            connectionString = $"Server={server};Database={database};User ID={user}";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao abrir a conexão: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
            }
        }
    }

}
