using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Pessoas
{
    public partial class Frm_CadastroPessoa_UC : Form
    {
        public Frm_CadastroPessoa_UC()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_CadastroPessoa_UC_Load(object sender, EventArgs e)
        {
            Frm_Geral_Usuarios_UC frm = new Frm_Geral_Usuarios_UC();
            frm.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frm);
            Tbc_CadastroUsuario.TabPages.Add(TB);

        }
    }
}
