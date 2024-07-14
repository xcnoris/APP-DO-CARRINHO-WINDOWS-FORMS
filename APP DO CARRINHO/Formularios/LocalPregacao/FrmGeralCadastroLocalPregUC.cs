using AppCarrinhoWFBiblioteca.Situacao;
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

namespace APP_DO_CARRINHO.Formularios.LocalPregacao
{
    public partial class FrmGeralCadastroLocalPregUC : UserControl
    {
        private ConexaoDB conexaoDB;
        private Metodos metodos;

        private ICollection<Situacao1> RetornoSituacao = new List<Situacao1>();

        public FrmGeralCadastroLocalPregUC()
        {
            InitializeComponent();
            
            conexaoDB = new ConexaoDB();
            metodos = new Metodos();
        }

        private void FrmGeralCadastroLocalPregUC_Load(object sender, EventArgs e)
        {
            metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacao, Cbox_Situacao);
        }
    }
}
