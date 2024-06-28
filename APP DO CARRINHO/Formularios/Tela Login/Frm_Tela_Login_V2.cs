using APP_DO_CARRINHO.Formularios.Tela_Login;
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
        public string NomeUser { get; set; }


        public Frm_Tela_Login_V2()
        {
            InitializeComponent();
        }

        private void Btn_Acessar_Click(object sender, EventArgs e)
        {
          
            DialogResult = DialogResult.Yes;
            NomeUser = Txt_NomeUser.Text;
            this.Hide();
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Conexoes_Click(object sender, EventArgs e)
        {
            Frm_Tela_ConexoesDB frm = new Frm_Tela_ConexoesDB();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Lbl_Senha_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
