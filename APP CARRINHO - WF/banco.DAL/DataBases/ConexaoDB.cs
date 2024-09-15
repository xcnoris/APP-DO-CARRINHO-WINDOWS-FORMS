using System;
using MySql.Data.MySqlClient;

namespace banco.DataBases
{

    public class ConexaoDB
    {
        private MySqlConnection connection;
        private string connectionString;


        // Dados da conexão
        string server = "26.219.25.12";       // Altere para o IP da sua VPN se necessário
        string database = "appcarrinho";
        string user = "augusto";
        string password = "4ppc4rr1nh0";

        public ConexaoDB()
        {
            // Ajustando a string de conexão para incluir a senha
            connectionString = $"Server={server};Database={database};User ID={user};Password={password}";
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
