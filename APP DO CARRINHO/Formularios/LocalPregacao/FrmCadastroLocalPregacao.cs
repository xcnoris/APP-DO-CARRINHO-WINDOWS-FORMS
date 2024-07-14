using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.LocalPregacao
{
    public partial class FrmCadastroLocalPregacao : Form
    {
        private FrmGeralCadastroLocalPregUC frmGeralCadLocalPreg;
        public FrmCadastroLocalPregacao()
        {
            InitializeComponent();
            frmGeralCadLocalPreg = new FrmGeralCadastroLocalPregUC();
        }

        private void FrmCadastroLocalPregacao_Load(object sender, EventArgs e)
        {
            frmGeralCadLocalPreg.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frmGeralCadLocalPreg);
            Tbc_Cad_Carrinho.TabPages.Add(TB);
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
