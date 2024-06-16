using APP_DO_CARRINHO.Formularios.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.clientes;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using AppCarrinhoWFBiblioteca.cep;

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Cadastro_Carrinho_UC : Form
    {
        private Frm_Geral_Carrinho_UC frmGeralCarrinho;
        public Frm_Cadastro_Carrinho_UC()
        {
            InitializeComponent();
        }

        private void Frm_Cadastro_Carrinho_UC_Load(object sender, EventArgs e)
        {
            Frm_Geral_Carrinho_UC frm = new Frm_Geral_Carrinho_UC();
            frm.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frm);
            Tbc_Cad_Carrinho.TabPages.Add(TB);
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Carrinho1.Unit cliente = new Carrinho1.Unit();
                cliente = LeituraFormulario();
                cliente.ValidarClasse();
                MessageBox.Show($"Class foi inicializada sem erros!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show($" {Ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Carrinho1.Unit LeituraFormulario()
        {
            Carrinho1.Unit c = new Carrinho1.Unit();

            c.ID = frmGeralCarrinho.Id;
            c.Nome = frmGeralCarrinho.Nome;
            c.Situacao = frmGeralCarrinho.Situacao;
            c.Congregacao_ID = frmGeralCarrinho.Congregacao_Nome;
            c.Codigo_Carrinho = frmGeralCarrinho.Carrinho_Codigo;

            return c;
        }
        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
