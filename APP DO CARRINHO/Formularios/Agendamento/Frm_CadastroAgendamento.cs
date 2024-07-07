using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Agendamento
{
    public partial class Frm_CadastroAgendamento : Form
    {
        private Frm_Local_AgendamentoUC frmLocalCarrinho;
        private Frm_Geral_AgendamentoUC frmgeralAgendamentoUC;
        private ConexaoDB conexaoDB;

        public Frm_CadastroAgendamento()
        {
            InitializeComponent();

            frmgeralAgendamentoUC = new Frm_Geral_AgendamentoUC();
            frmLocalCarrinho = new Frm_Local_AgendamentoUC();
            conexaoDB = new ConexaoDB();


        }

        private void Frm_CadastroAgendamento_Load(object sender, EventArgs e)
        {
            CarregarUserControls();
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // --------------

        private void CarregarUserControls()
        {
            frmgeralAgendamentoUC.Dock = DockStyle.Fill;
            TabPage TB1 = new TabPage();
            TB1.Name = "Geral";
            TB1.Text = "Geral";
            TB1.Controls.Add(frmgeralAgendamentoUC);

            frmLocalCarrinho.Dock = DockStyle.Fill;
            TabPage TB2 = new TabPage();
            TB2.Name = "Local";
            TB2.Text = "Local";
            TB2.Controls.Add(frmLocalCarrinho);

            Tbc_Cad_Agendamento.TabPages.Add(TB1);
            Tbc_Cad_Agendamento.TabPages.Add(TB2);
        }

      
    }
}
