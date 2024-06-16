using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCarrinhoWFBiblioteca.clientes;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.cep;

namespace APP_DO_CARRINHO.Formularios.Pessoas
{
    public partial class Frm_CadastroPessoa_UC : Form
    {
        private Frm_Geral_Usuarios_UC frmGeralUsuarios;
        public Frm_CadastroPessoa_UC()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_CadastroPessoa_UC_Load(object sender, EventArgs e)
        {
            frmGeralUsuarios = new Frm_Geral_Usuarios_UC();
            frmGeralUsuarios.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frmGeralUsuarios);
            Tbc_CadastroUsuario.TabPages.Add(TB);

        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit cliente = new Cliente.Unit();
                cliente = LeituraFormulario();
                cliente.ValidarClasse();
                MessageBox.Show($"Class foi inicializada sem erros!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show($" {Ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit c = new Cliente.Unit();

            c.ID = frmGeralUsuarios.Id;
            c.CPF = Regex.Replace(frmGeralUsuarios.CPF, @"[^\d]", ""); // Remove todos os caracteres não numéricos
            c.Nome = frmGeralUsuarios.Nome;
            c.CEP = frmGeralUsuarios.CEP_Numero;
            c.ID_Cidade = frmGeralUsuarios.Cidade_Cod;
            c.Nome_Cidade = frmGeralUsuarios.Cidade_Nome;
            c.UF = frmGeralUsuarios.UF;
            c.Endereco = frmGeralUsuarios.Endereco;
            c.Endereco_Numero = frmGeralUsuarios.Endereco_Numero;
            c.Endereco_Complemento = frmGeralUsuarios.Endereco_Complemento;
            c.Bairro = frmGeralUsuarios.Endereco_Bairro;
            c.DDD_Telefone = frmGeralUsuarios.Telefone_DDD;
            c.Telefone = frmGeralUsuarios.Telefone_Numero;
            c.DDD_Celular = frmGeralUsuarios.Celular_DDD;
            c.Celular = frmGeralUsuarios.Celular_Numero;
            c.Sexo = frmGeralUsuarios.Sexo;
            c.DataNascimento = frmGeralUsuarios.Data_Nascimento;
            c.Email = frmGeralUsuarios.Email;

            return c;
        }
    }
}
