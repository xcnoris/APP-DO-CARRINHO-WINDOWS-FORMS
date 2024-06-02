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
    public partial class Frm_Tela_Login_Registro : Form
    {
        public Frm_Tela_Login_Registro()
        {
            InitializeComponent();
        }

        private void Btn_Entrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Tela_Login_Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
