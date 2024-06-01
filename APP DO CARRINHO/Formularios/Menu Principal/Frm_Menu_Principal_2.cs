using APP_DO_CARRINHO.Formularios.Carrinho;
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

namespace APP_DO_CARRINHO.Formularios.Menu_Principal
{
    public partial class Frm_Menu_Principal_2 : Form
    {
        public Frm_Menu_Principal_2()
        {
            InitializeComponent();
        }

        private void Btn_Pessoas_Click(object sender, EventArgs e)
        {
            Frm_Tela_Pessoas frm = new Frm_Tela_Pessoas();
            frm.Show();
        }

        private void Btn_Carrinho_Click(object sender, EventArgs e)
        {
            Frm_Tela_Carrinho frm = new Frm_Tela_Carrinho();
            frm.Show();
        }

        private void Frm_Menu_Principal_2_Load(object sender, EventArgs e)
        {

        }
    }
}
