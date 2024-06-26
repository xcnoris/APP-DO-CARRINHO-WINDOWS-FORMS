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


namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Geral_Carrinho_UC : UserControl
    {
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
                    return Cbox_Situacao.SelectedIndex.ToString();
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
        public Frm_Geral_Carrinho_UC()
        {
            InitializeComponent();
        }

        private void Frm_Geral_Carrinho_UC_Load(object sender, EventArgs e)
        {
            //Situacao situacao = situacao.ConsultarDisponibilidadeInDB();
            
        }

        public void InserirSituacao()
        {
            
        }

        // Função para inserir dados quando é dado um duplo clique em um data grid view
        public void SetCarrinhoData(string id, string nome, string congregacaoId,  string congregacaoNome, string situacao, string codigoCarrinho)
        {
            Txt_ID.Text = id;
            Txt_Nome.Text = nome;
            Txt_Congregacao_ID.Text = congregacaoId;
            Txt_Congregacao_Nome.Text = congregacaoNome;
            Cbox_Situacao.SelectedIndex = Cbox_Situacao.FindStringExact(situacao); // Or set the value directly if you have the value member
            Txt_Codigo_Carrinho.Text = codigoCarrinho;
        }


    }
}
