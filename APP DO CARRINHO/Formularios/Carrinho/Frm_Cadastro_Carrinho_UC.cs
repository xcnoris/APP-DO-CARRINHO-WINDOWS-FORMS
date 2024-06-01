using APP_DO_CARRINHO.Formularios.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Cadastro_Carrinho_UC : Form
    {
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

        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {

        }
    }
}
