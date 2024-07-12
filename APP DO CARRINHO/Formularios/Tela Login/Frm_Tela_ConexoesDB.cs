using banco.DAL.DataBases;
using MySql.Data.MySqlClient;
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
            InitializeConnectionString();
        }

        private void CarregarConfig()
        {
            Txt_Servidor.Text = Properties.Settings.Default.Server;
            Txt_BD.Text = Properties.Settings.Default.Database;
            Txt_UsuarioBD.Text = Properties.Settings.Default.Username;
            Txt_SenhaBD.Text = Properties.Settings.Default.Password;

            var config = ControlConfig.LoadConfig();
            if (config != null)
            {
                Txt_Servidor.Text = config.Servidor;
                Txt_BD.Text = config.DB;
                Txt_UsuarioBD.Text = config.DB;
                Txt_SenhaBD.Text = config.DB;
            }
        }

        private void SalvarConfig()
        {
            Properties.Settings.Default.Server = Txt_Servidor.Text;
            Properties.Settings.Default.Database = Txt_BD.Text;
            Properties.Settings.Default.Username = Txt_UsuarioBD.Text;
            Properties.Settings.Default.Password = Txt_SenhaBD.Text;
            Properties.Settings.Default.Save();

            var config = new DBConfig
            {
                Servidor = Txt_Servidor.Text,
                DB = Txt_BD.Text,
                Usuario = Txt_UsuarioBD.Text,
                Senha = Txt_SenhaBD.Text
            };
            ControlConfig.SalvarConfig(config);
            InitializeConnectionString(); // Atualiza a connection String
        }

        private void InitializeConnectionString()
        {
            var config = ControlConfig.LoadConfig();
            if (config != null) 
            {
                connectionString = $"Server={config.Servidor} Database={config.DB};User ID={config.Usuario};Password={config.Senha};";
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
                    SalvarConfig(); // Salva as configurações bem sucedidas
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
