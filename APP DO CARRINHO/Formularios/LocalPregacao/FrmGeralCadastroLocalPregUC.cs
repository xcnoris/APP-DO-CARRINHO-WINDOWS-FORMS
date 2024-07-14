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

namespace APP_DO_CARRINHO.Formularios.FrmLocalPregacao
{
    public partial class FrmGeralCadastroLocalPregUC : UserControl
    {
        private ConexaoDB conexaoDB;
        private Metodos metodos;

        private ICollection<Situacao1> RetornoSituacao = new List<Situacao1>();

        public int ID
        {
            get 
            {
                if (Txt_ID.Text != "")
                {
                    return Convert.ToInt32(Txt_ID.Text);
                }
                else
                {
                    return 0; // ou qualquer outro valor padrão apropriado
                }
            }
        }
        public string Nome
        {
            get { return Txt_Nome.Text; }
        }
        public string Descricao
        {
            get { return Txt_Descricao.Text; }
        }
        public int Situacao
        {
            get
            {
                if (Cbox_Situacao.SelectedIndex < 0)
                {
                    return 0;
                }
                else
                {
                    int index = Cbox_Situacao.SelectedIndex + 1;
                    return index;
                }
            }
        }
        public string Endereco
        {
            get { return Txt_Endereco.Text; }
        }
        public string Complemento
        {
            get { return Txt_Complemento.Text; }
        }
        public string Bairro
        {
            get { return Txt_Bairro.Text; }
        }

        public string Cidade
        {
            get { return Txt_Cidade.Text; }
        }
        public string UF
        {
            get { return Txt_UF.Text; }
        }



        public FrmGeralCadastroLocalPregUC()
        {
            InitializeComponent();
            
            conexaoDB = new ConexaoDB();
            metodos = new Metodos();
            metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacao, Cbox_Situacao);
        }

        private void FrmGeralCadastroLocalPregUC_Load(object sender, EventArgs e)
        {
        }

        internal void InserirDadosInFrm(int id, string nome, string nomeSituacao, string endereco, string complemento, string bairro, string cidade)
        {
            Txt_ID.Text = id.ToString();
            Txt_Nome.Text = nome;
            // Configurar o valor do ComboBox de Situação
            foreach (var item in Cbox_Situacao.Items)
            {
                // Assuming each item in Cbox_Situacao is of type Situacao
                if (item is Situacao1 situacaoItem && situacaoItem.Nome == nomeSituacao)
                {
                    Cbox_Situacao.SelectedItem = item;
                    break;
                }
            }
            Txt_Endereco.Text = endereco;
            Txt_Complemento.Text = complemento;
            Txt_Bairro.Text = bairro;
            Txt_Cidade.Text = cidade;
        }
    
    }
}
