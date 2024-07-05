using APP_DO_CARRINHO.Formularios.Pessoas;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.clientes;
using AppCarrinhoWFBiblioteca.User;
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
        private Metodos metodos;

        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();
        public ICollection<TipoUser> RetornoTipos = new List<TipoUser>();

        private bool ControleSalvarIncluirUser;

        public Frm_Cadastro_Usuario()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
            metodos = new Metodos();

            
            metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao);
            metodos.IncluirCamposTipoUser(conexaoDB, RetornoTipos, Cbox_Tipo);
            ControleSalvarIncluirUser = true;
        }

        private void Frm_Cadastro_Usuario_Load(object sender, EventArgs e)
        {
            

        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Insere os dados no formularios quando é necessario atualizar algum valor
        internal void InserirDadosInFrm(string id, string cpf, string nome, string situacao, string login, string tipo)
        {
            ControleSalvarIncluirUser = false;

            Txt_Id.Text = id;
            MSK_CPF.Text = cpf;
            Txt_Nome.Text = nome;
            Txt_Login.Text = login;
            

            // Configurar o valor do ComboBox de Situação
            foreach (var item in Cbox_Situacao.Items)
            {
                // Checando se o item é do tipo Situacao e se o nome da situação bate com o parâmetro passado
                if (item is Situacao situacaoItem && situacaoItem.Nome == situacao)
                {
                    Cbox_Situacao.SelectedItem = item;
                    break;
                }
            }

            // Configurar o valor do ComboBox de Situação
            foreach (var item in Cbox_Tipo.Items)
            {
                // Checando se o item é do tipo Situacao e se o nome da situação bate com o parâmetro passado
                if (item is TipoUser tipoItem && tipoItem.Nome == tipo)
                {
                    Cbox_Tipo.SelectedItem = item;
                    break;
                }
            }
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
            int idSituacao = Cbox_Situacao.SelectedIndex + 1;
            int idTipo = Cbox_Tipo.SelectedIndex + 1;

            User1 user = new User1
            {
                Id = Txt_Id.Text,
                CPF = Regex.Replace(MSK_CPF.Text, @"[^\d]", ""),
                Nome = Txt_Nome.Text,
                Id_Tipo = idTipo.ToString(),
                Login = Txt_Login.Text.Trim().ToLower(),
                Id_Situacao = idSituacao.ToString(),
            };

            return user;
        }

     
    }
}
