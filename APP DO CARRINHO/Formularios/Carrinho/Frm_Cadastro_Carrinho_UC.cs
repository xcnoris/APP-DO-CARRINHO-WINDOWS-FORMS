using APP_DO_CARRINHO.Formularios.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.clientes;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using AppCarrinhoWFBiblioteca.cep;
using DataBase.DataBases;
using System.IO;
using AppCarrinhoWFBiblioteca.carrinho;

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Cadastro_Carrinho_UC : Form
    {

        private Frm_Geral_Carrinho_UC frmGeralCarrinho;

        public Frm_Cadastro_Carrinho_UC()
        {
            InitializeComponent();
        }

        private void Frm_Cadastro_Carrinho_UC_Load(object sender, EventArgs e)
        {
            frmGeralCarrinho = new Frm_Geral_Carrinho_UC();
            frmGeralCarrinho.Dock = DockStyle.Fill;
            //Frm_Geral_Carrinho_UC frm = new Frm_Geral_Carrinho_UC();
            //frm.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frmGeralCarrinho);
            Tbc_Cad_Carrinho.TabPages.Add(TB);
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Carrinho1 carrinho = LeituraFormulario();
                carrinho.ValidarClasse();
                string carrinhoJson = CarrinhoService.SerializedClassUnit(carrinho);

                Fichario F = new Fichario("C:\\Users\\augus\\OneDrive\\Documentos\\PROJETOS PESSOAIS\\PROJETOS COM C#\\APP CARRINHO - WINDOWS FORMS\\Fichario");
                if (F.Status)
                {
                    F.Incluir(carrinho.ID, carrinhoJson);
                    if(F.Status)
                    {
                        MessageBox.Show($"OK: {F.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: {F.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: {F.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show($" {Ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Instancia a class Carrinho1 com os dados dos TextBox 
        private Carrinho1 LeituraFormulario()
        {
            return new Carrinho1
            {

                ID = frmGeralCarrinho.Carrinho_Id,
                Nome = frmGeralCarrinho.Nome,
                Situacao = frmGeralCarrinho.Situacao,
                Congregacao_ID = frmGeralCarrinho.Congregacao_ID,
                Congregacao_Nome = frmGeralCarrinho.Congregacao_Nome,
                Codigo_Carrinho = frmGeralCarrinho.Carrinho_Codigo

            };
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


