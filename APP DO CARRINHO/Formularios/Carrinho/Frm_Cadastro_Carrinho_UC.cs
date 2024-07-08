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
using banco.DataBases;

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Cadastro_Carrinho_UC : Form
    {

        private Frm_Geral_Carrinho_UC frmGeralCarrinho;
        
        private ConexaoDB conexaoDB;
        // Controla se o clinte vai incluir um novo carrinho, ou atualizar um existente
        private bool ControleSalvarIncluirCarrinho = true;

        public Frm_Cadastro_Carrinho_UC()
        {
            InitializeComponent();

            conexaoDB = new ConexaoDB();
            frmGeralCarrinho = new Frm_Geral_Carrinho_UC(); // Inicialize o objeto aqui
        }

        private void Frm_Cadastro_Carrinho_UC_Load(object sender, EventArgs e)
        {
            frmGeralCarrinho.Dock = DockStyle.Fill;
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
                // Função de incluir no banco o novo carrinho
                if (ControleSalvarIncluirCarrinho)
                {
                    // Instancia a class e puxa os dados do formulario
                    Carrinho1 carrinho = LeituraFormulario();
                    // Valida os dados
                    carrinho.ValidarClasse();
                    // Tenta incluir os dados no banco de dados
                    carrinho.IncluirNoBanco(conexaoDB);
                    if (carrinho.Status)
                    {
                        ControleSalvarIncluirCarrinho = true;
                        MessageBox.Show($"OK: {carrinho.Mensagem} Carrinho incluído com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirCarrinho = true;
                        MessageBox.Show($"{carrinho.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        this.Close();
                    }
                }
                // Funcao de atualizar carrinho no banco
                else
                {
                    // Instancia a class e puxa os dados do formulario
                    Carrinho1 carrinho = LeituraFormulario();
                    // Valida os dados
                    carrinho.ValidarClasse();
                    // Tenta incluir os dados no banco de dados
                    carrinho.AtualizarNoBanco(conexaoDB);
                    if (carrinho.Status)
                    {
                        ControleSalvarIncluirCarrinho = true;
                        MessageBox.Show($"OK: {carrinho.Mensagem} Carrinho Atualizado com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirCarrinho = true;
                        MessageBox.Show($"{carrinho.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                        this.Close();
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void InserirDadosInUserControl(string id, string nome, string situacao, string congregacaoId, string nome_congregacao, string codigoCarrinho)
        {
            ControleSalvarIncluirCarrinho = false;
            frmGeralCarrinho.SetCarrinhoData(id, nome, situacao, congregacaoId, nome_congregacao, codigoCarrinho);
        }
        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


