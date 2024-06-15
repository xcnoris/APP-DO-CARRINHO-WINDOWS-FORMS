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
    public partial class Frm_Geral_Usuarios_UC : UserControl
    {
        public Frm_Geral_Usuarios_UC()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            

        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            
        }

        private void Frm_Geral_Usuarios_UC_Load(object sender, EventArgs e)
        {
            Cbox_Sexo.Items.Clear();
            Cbox_Sexo.Items.Add("Masculino");
            Cbox_Sexo.Items.Add("Feminino");
        }
    }
}
