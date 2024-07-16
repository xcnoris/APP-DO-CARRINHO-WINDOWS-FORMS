using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace banco.DataBases
{
    public class ConfiguracaoBanco
    {
        public string Servidor { get; set; }
        public string BancoDeDados { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public static class GerenciadorConfiguracao
    {
        private const string CaminhoArqConfig = "dbconfig.json";

        public static ConfiguracaoBanco CarregarConfiguracao()
        {
            if (File.Exists(CaminhoArqConfig))
            {
                string json = File.ReadAllText(CaminhoArqConfig);
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonConvert.DeserializeObject<ConfiguracaoBanco>(json);
                }
            }
            return null;
        }

        public static void SalvarConfiguracao(ConfiguracaoBanco config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(CaminhoArqConfig, json);
        }
    }

    public class ConexaoDB
    {
        private MySqlConnection connection;
        private string connectionString;


        // Dados da conexão
        //string server = "26.219.25.12";       // Altere para o IP da sua VPN se necessário
        //string database = "appcarrinho";
        //string user = "augusto";
        //string password = "4ppc4rr1nh0";

        public ConexaoDB(ConfiguracaoBanco config)
        {
            // Ajustando a string de conexão para incluir a senha
            //connectionString = $"Server={server};Database={database};User ID={user};Password={password}";
            //connection = new MySqlConnection(connectionString);
            
            if(config != null)
            {
                connectionString = $"Server={config.Servidor};Database={config.BancoDeDados} User ID={config.Usuario};Password={config.Senha}";
                connection = new MySqlConnection(connectionString);
            }
            else
            {
                throw new Exception("Configuração do banco de dados não foi fornecida.");
            }
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
                Console.WriteLine($"Erro ao abrir a conexão: {ex.Message}");
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
                Console.WriteLine($"Erro ao fechar a conexão: {ex.Message}");
            }
        }
    }

}
