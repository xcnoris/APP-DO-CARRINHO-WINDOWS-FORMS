using banco.DAL.DataBases;
using banco.DataBases;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Tela_Login
{
    public partial class Frm_Tela_ConexoesDB : Form
    {
        private ConexaoDB conexaoDb;
        private ComandosDB comandosDb;

        public Frm_Tela_ConexoesDB()
        {
            InitializeComponent();
            CarregarConfig();
        }

        private void CarregarConfig()
        {
            var config = GerenciadorConfiguracao.CarregarConfiguracao();
            if (config != null)
            {
                Txt_Servidor.Text = config.Servidor;
                Txt_BD.Text = config.BancoDeDados;
                Txt_UsuarioBD.Text = config.Usuario;
                Txt_SenhaBD.Text = config.Senha;
                InicializarConexao(config); // Inicializar a conexão se a configuração existir
            }
        }

        private void SalvarConfiguracao()
        {
            var config = new ConfiguracaoBanco
            {
                Servidor = Txt_Servidor.Text,
                BancoDeDados = Txt_BD.Text,
                Usuario = Txt_UsuarioBD.Text,
                Senha = Txt_SenhaBD.Text
            };
            GerenciadorConfiguracao.SalvarConfiguracao(config);
            InicializarConexao(config); // Atualiza a string de conexao
        }

        private void InicializarConexao(ConfiguracaoBanco config)
        {
            try
            {
                conexaoDb = new ConexaoDB(config);
                comandosDb = new ComandosDB(conexaoDb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            string servidor = Txt_Servidor.Text;
            string bancoDeDados = Txt_BD.Text;
            string usuario = Txt_UsuarioBD.Text;
            string senha = Txt_SenhaBD.Text;

            var config = new ConfiguracaoBanco()
            {
                Servidor = servidor,
                BancoDeDados = bancoDeDados,
                Usuario = usuario,
                Senha = senha
            };

            string connectionStringTest = $"Server={config.Servidor};Database={config.BancoDeDados}; User ID={config.Usuario};Password={config.Senha};";

            using (MySqlConnection conexao = new MySqlConnection(connectionStringTest))
            {
                try
                {
                    conexao.Open();
                    MessageBox.Show("Conexão bem sucedida!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SalvarConfiguracao(); // Sava as configurações após a uma conexão bem sucedida
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao.State == ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                }
            }
        }
    }
}
