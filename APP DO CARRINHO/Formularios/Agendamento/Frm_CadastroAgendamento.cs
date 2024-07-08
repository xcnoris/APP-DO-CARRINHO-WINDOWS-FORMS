using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.classagendamento;
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

namespace APP_DO_CARRINHO.Formularios.Agendamento
{
    public partial class Frm_CadastroAgendamento : Form
    {
        private Frm_Local_AgendamentoUC frmLocalAgendamento;
        private Frm_Geral_AgendamentoUC frmgeralAgendamentoUC;
        private ConexaoDB conexaoDB;

        // Controla se o clinte vai incluir um novo carrinho, ou atualizar um existente
        private bool ControleSalvarIncluirCarrinho = true;

        public Frm_CadastroAgendamento()
        {
            InitializeComponent();

            frmgeralAgendamentoUC = new Frm_Geral_AgendamentoUC();
            frmLocalAgendamento = new Frm_Local_AgendamentoUC();
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

            frmLocalAgendamento.Dock = DockStyle.Fill;
            TabPage TB2 = new TabPage();
            TB2.Name = "Local";
            TB2.Text = "Local";
            TB2.Controls.Add(frmLocalAgendamento);

            Tbc_Cad_Agendamento.TabPages.Add(TB1);
            Tbc_Cad_Agendamento.TabPages.Add(TB2);
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Função de incluir no banco o novo carrinho
                if (ControleSalvarIncluirCarrinho)
                {
                    // Instancia a class e puxa os dados do formulario
                    Agendameto1 agendamento = LeituraFormulario();
                    // Valida os dados
                    agendamento.ValidarClasse();
                    // Tenta incluir os dados no banco de dados
                    agendamento.IncluirNoBanco(conexaoDB);
                    if (agendamento.Status)
                    {
                        ControleSalvarIncluirCarrinho = true;
                        MessageBox.Show($"OK: {agendamento.Mensagem} Carrinho incluído com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirCarrinho = true;
                        MessageBox.Show($"{agendamento.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.Close();
                    }
                }
                // Funcao de atualizar carrinho no banco
                else
                {
                    // Instancia a class e puxa os dados do formulario
                    Agendameto1 carrinho = LeituraFormulario();
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

        private Agendameto1 LeituraFormulario()
        {
            return new Agendameto1
            {

                Id = frmgeralAgendamentoUC.IdAgendamento,
                IdSituacao = frmgeralAgendamentoUC.SituacaoAgendamento,
                IdCategoria = frmgeralAgendamentoUC.CategoriaAgendamento,
                IdPessoa = frmgeralAgendamentoUC.IdPessoa,
                CodCarrinho = frmgeralAgendamentoUC.IdCarrinho,
                DataAgendamento = frmgeralAgendamentoUC.DataAgendamento,
                Hora1 = frmgeralAgendamentoUC.HoraInicio,
                Hora2 = frmgeralAgendamentoUC.HoraFim,
              

            };
        }
    }
}
