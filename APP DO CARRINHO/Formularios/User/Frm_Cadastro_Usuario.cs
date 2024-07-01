using AppCarrinhoWFBiblioteca;
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

namespace APP_DO_CARRINHO.Formularios.User
{
    public partial class Frm_Cadastro_Usuario : Form
    {
        private ConexaoDB conexaoDB;

        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();

        public Frm_Cadastro_Usuario()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
        }

        private void Frm_Cadastro_Usuario_Load(object sender, EventArgs e)
        {

            Metodos m = new Metodos();
            m.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao);

        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
