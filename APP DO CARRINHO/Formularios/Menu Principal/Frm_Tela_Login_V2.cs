using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Menu_Principal
{
    public partial class Frm_Tela_Login_V2 : Form
    {
        public Frm_Tela_Login_V2()
        {
            InitializeComponent();
        }

        private void Btn_Acessar_Click(object sender, EventArgs e)
        {
          
            DialogResult = DialogResult.Yes;
            this.Hide();
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
