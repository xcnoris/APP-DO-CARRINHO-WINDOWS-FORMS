using AppCarrinhoWFBiblioteca.carrinho1;
using banco.DataBases;
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

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Cadastro_Carrinho_UC_Edit : Form
    {
        private Frm_Geral_Carrinho_UC frmGeralCarrinho;

        private ConexaoDB conexaoDB;

        public Frm_Cadastro_Carrinho_UC_Edit()
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
                // Instancia a class e puxa os dados do formulario
                Carrinho1 carrinho = LeituraFormulario();
                // Valida os dados
                carrinho.ValidarClasse();
                // Tenta incluir os dados no banco de dados
                carrinho.AtualizarNoBanco(conexaoDB);
                if (carrinho.Status)
                {
                    MessageBox.Show($"OK: {carrinho.Mensagem} Carrinho incluído com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{carrinho.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetCarrinhoData(string id, string nome, string congregacaoId, string nome_congregacao, string situacao, string codigoCarrinho)
        {
            frmGeralCarrinho.SetCarrinhoData(id, nome, congregacaoId, nome_congregacao, situacao, codigoCarrinho);
        }

    }
}
