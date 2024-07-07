using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCarrinhoWFBiblioteca.cep;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.clientes;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using banco.DataBases;


namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Geral_Carrinho_UC : UserControl
    {

        private ConexaoDB conexaoDB;
        private Metodos metodos;
        private ICollection<Situacao> RetornoSituacoes = new List<Situacao>();



        public string Carrinho_Id
        {
            get { return Txt_ID.Text; }
        }
        public string Nome
        {
            get { return Txt_Nome.Text; }
        }
        public string Situacao
        {
            get
            {
                if (Cbox_Situacao.SelectedIndex < 0)
                {
                    return "";
                }
                else
                {
                    int index = Cbox_Situacao.SelectedIndex + 1;
                    return index.ToString();
                }
            }
        }
        public string Congregacao_ID
        {
            get { return Txt_Congregacao_ID.Text; }
        }
        public string Congregacao_Nome
        {
            get { return Txt_Congregacao_Nome.Text; }
        }
        public string Carrinho_Codigo
        {
            get { return Txt_Codigo_Carrinho.Text; }
        }


        // ======> Construtor  <=============
        public Frm_Geral_Carrinho_UC()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
            metodos = new Metodos();
            metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao);

            
        }

        private void Frm_Geral_Carrinho_UC_Load(object sender, EventArgs e)
        {

            //Situacao situacao = situacao.ConsultarDisponibilidadeInDB();

        }

        public void InserirSituacao()
        {
            
        }

        // Função para inserir dados quando é dado um duplo clique em um data grid view
        public void SetCarrinhoData(string id, string nome,string situacao, string congregacaoId,  string congregacaoNome, string codigoCarrinho)
        {
            Txt_ID.Text = id;
            Txt_Nome.Text = nome;
            Txt_Congregacao_ID.Text = congregacaoId;
            Txt_Congregacao_Nome.Text = congregacaoNome;
            Txt_Codigo_Carrinho.Text = codigoCarrinho;

            // Configurar o valor do ComboBox de Situação
            foreach (var item in Cbox_Situacao.Items)
            {
                // Assuming each item in Cbox_Situacao is of type Situacao
                if (item is Situacao situacaoItem && situacaoItem.Nome == situacao)
                {
                    Cbox_Situacao.SelectedItem = item;
                    break;
                }
            }
        }

        private void Lbl_Nome_Carrinho_Click(object sender, EventArgs e)
        {

        }
    }
}
