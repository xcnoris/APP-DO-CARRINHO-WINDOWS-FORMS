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
                cliente.ID = frmGeralUsuarios.Id;
                cliente.ValidarClasse();
                MessageBox.Show($"Class foi inicializada sem erros!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show(Ex.Message, "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
