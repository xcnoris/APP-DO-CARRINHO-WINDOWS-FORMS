using AppCarrinhoWFBiblioteca.cep;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace APP_DO_CARRINHO.Formularios.Pessoas
{
    public partial class Frm_Geral_Usuarios_UC : UserControl
    {
        public string Id
        {
            get{ return Txt_Id.Text; }
        
        }
        public  string Nome 
        {
            get { return Txt_Nome.Text; }
        }
        public string CPF
        {
            get{ return MSK_CPF.Text; }
        }
        public string Sexo
        {
            get
            {
                if (Cbox_Sexo.SelectedIndex < 0)
                {
                    return "";
                }
                else
                {
                    return Cbox_Sexo.SelectedIndex.ToString();
                }
            }
        }
        
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MSK_CEP_Leave(object sender, EventArgs e)
        {
            var vCep = Regex.Replace(MSK_CEP.Text, @"[^\d]", ""); // Remove todos os caracteres não numéricos

            if (vCep != "")
            {
                if(vCep.Length == 8)
                {
                    // Consulta o cep informado, e retorna uma varial string, no formato Json 
                    var vJson = Cls_Uteis.GeraJSONCEP(vCep);
                    // Instancia a class
                    CEP.Unit Cep = new CEP.Unit();
                    // DesSerialized o Json na class CEP.Unit(), transforma o texto em class
                    Cep = CEP.DesSerializedClassUnit(vJson);

                    Txt_Cidade_Nome.Text = Cep.localidade;
                    Txt_Sigla_Uf.Text = Cep.uf;
                    Txt_Endereco.Text = Cep.logradouro;
                    Txt_Endereco_Complemento.Text = Cep.complemento;
                    Txt_Endereco_Bairro.Text = Cep.bairro;
                }
            }
        }
    }
}
