using banco.DAL.DataBases;
using MySqlConnector;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APP_DO_CARRINHO.Formularios.Tela_Login
{
    public partial class Frm_Tela_ConexoesDB : Form
    {
        private string connectionString;

        public Frm_Tela_ConexoesDB()
        {
            InitializeComponent();
            CarregarConfig();
        }

        private void CarregarConfig()
        {
            var config = ConfigControl.LoadConfig();
            if (config != null)
            {
                Txt_Servidor.Text = config.Servidor;
                Txt_BD.Text = config.BD;
                Txt_UsuarioBD.Text = config.Usuario;
                Txt_SenhaBD.Text = config.Senha;
            }
        }

        private void SalvarConfig()
        {
            var config = new BDConfig
            {
                Servidor = Txt_Servidor.Text,
                BD = Txt_BD.Text,
                Usuario = Txt_UsuarioBD.Text,
                Senha = Txt_SenhaBD.Text
            };
            ConfigControl.SalvarConfig(config);
            InitializeConnectionString();
        }

        private void InitializeConnectionString()
        {
            var config = ConfigControl.LoadConfig();
            if (config != null)
            {
                connectionString = $"Server={config.Servidor};Database={config.BD};User ID={config.Usuario};Password={config.Senha};";
            }
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            string server = Txt_Servidor.Text;
            string database = Txt_BD.Text;
            string username = Txt_UsuarioBD.Text;
            string password = Txt_SenhaBD.Text;

            string connectionString = $"Server={server};Database={database};User ID={username};Password={password};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão bem sucedida!", "Conexão", MessageBoxButtons.OK);
                    SalvarConfig();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Falha na conexão: {ex.Message}", "Conexão", MessageBoxButtons.OK);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
