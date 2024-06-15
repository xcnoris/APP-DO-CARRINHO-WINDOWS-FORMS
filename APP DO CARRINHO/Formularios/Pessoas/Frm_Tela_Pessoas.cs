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
    public partial class Frm_Tela_Pessoas : Form
    {
        public Frm_Tela_Pessoas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_CadastroPessoa_UC frm = new Frm_CadastroPessoa_UC();
            frm.ShowDialog();
          
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Tela_Pessoas_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
