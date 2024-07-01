using APP_DO_CARRINHO.Formularios.Pessoas;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.clientes;
using AppCarrinhoWFBiblioteca.Users;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.User
{
    public partial class Frm_Cadastro_Usuario : Form
    {
        private ConexaoDB conexaoDB;

        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();

        private bool ControleSalvarIncluirUser;

        public Frm_Cadastro_Usuario()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
            
            ControleSalvarIncluirUser = true;
        }

        private void Frm_Cadastro_Usuario_Load(object sender, EventArgs e)
        {

            Metodos m = new Metodos();
            m.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao);

        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal void InserirDadosInFrm(string id,string cpf,string nome,string situacao,string login,string tipo)
        {
            ControleSalvarIncluirUser = false;
            Txt_Id.Text = id;
            MSK_CPF.Text = cpf;
            Txt_Nome.Text = nome;
            Cbox_Situacao.Text = situacao;
            Txt_Login.Text = login;
            Cbox_Tipo.Text = tipo;
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Função de incluir no banco o nova pessoa
                // Se o controle de usuario for true ele inclui novo usuario
                if (ControleSalvarIncluirUser)
                {
                    // Instancia a class e puxa os dados do formulario
                    User1 user = LeituraFormulario();
                    // Valida os dados
                    user.ValidarClass();
                    // Tenta incluir os dados no banco de dados
                    user.IncluirNoBanco(conexaoDB);
                    if (user.Status)
                    {
                        ControleSalvarIncluirUser = true;
                        MessageBox.Show($"OK: {user.Mensagem} Usuario incluído com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirUser = true;
                        MessageBox.Show($"{user.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                // Funcao de atualizar Pessoa no banco
                else
                {
                    // Instancia a class e puxa os dados do formulario
                    User1 user = LeituraFormulario();
                    // Valida os dados
                    user.ValidarClass();
                    // Tenta incluir os dados no banco de dados
                    user.AtualizarNoBanco(conexaoDB);
                    if (user.Status)
                    {
                        ControleSalvarIncluirUser = true;
                        MessageBox.Show($"OK: {user.Mensagem} Carrinho Atualizado com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirUser = true;
                        MessageBox.Show($"{user.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        User1 LeituraFormulario()
        {

            User1 user = new User1
            {
                Id = Txt_Login.Text,
                CPF = Regex.Replace(MSK_CPF.Text, @"[^\d]", ""),
                Nome = Txt_Nome.Text,
                //Id_Tipo = Cbox_Tipo.Text,
                Login = Txt_Login.Text,
                Id_Situacao = Cbox_Situacao.Text

            };

            return user;
        }
    }
}
