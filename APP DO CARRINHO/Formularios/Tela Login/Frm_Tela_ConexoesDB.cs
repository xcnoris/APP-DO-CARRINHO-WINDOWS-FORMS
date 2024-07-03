using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Tela_Login
{
    public partial class Frm_Tela_ConexoesDB : Form
    {
        public Frm_Tela_ConexoesDB()
        {
            InitializeComponent();
            CarregarConfig();
        }

        private void CarregarConfig()
        {
            Txt_Servidor.Text = Properties.Settings.Default.Server;
            Txt_BD.Text = Properties.Settings.Default.Database;
            Txt_UsuarioBD.Text = Properties.Settings.Default.Username;
            Txt_SenhaBD.Text = Properties.Settings.Default.Password;
        }

        private void SalvarConfig()
        {
            Properties.Settings.Default.Server = Txt_Servidor.Text;
            Properties.Settings.Default.Database = Txt_BD.Text;
            Properties.Settings.Default.Username = Txt_UsuarioBD.Text;
            Properties.Settings.Default.Password = Txt_SenhaBD.Text;
            Properties.Settings.Default.Save();
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
