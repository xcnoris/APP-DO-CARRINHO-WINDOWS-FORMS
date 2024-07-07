using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.agendamentos;
using AppCarrinhoWFBiblioteca.carrinho;
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
    public partial class Frm_Tela_Agendamento : Form
    {

        private Metodos metodos;
        private ConexaoDB conexaoDB;
        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();


        public Frm_Tela_Agendamento()
        {
            InitializeComponent();
            
            conexaoDB = new ConexaoDB();
            metodos = new Metodos();

            DTP_Hora1.Enabled = false;
            DTP_Hora2.Enabled = false;


            AjustarFiltro();
            AddColumnDataGridView();

        }

        private void Frm_Tela_Agendamento_Load(object sender, EventArgs e)
        {
            metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao, true);
            CarregarTodosAgendamento();
        }

        private void AjustarFiltro()
        {
            DTP_Hora1.Format = DateTimePickerFormat.Custom;
            DTP_Hora1.CustomFormat = "HH:mm"; // Formato para hora e minutos (24 horas)
            DTP_Hora1.ShowUpDown = true; // Exibe um controle tipo "up-down" para seleção de hora/minutos


            DTP_Hora2.Format = DateTimePickerFormat.Custom;
            DTP_Hora2.CustomFormat = "HH:mm"; // Formato para hora e minutos (24 horas)
            DTP_Hora2.ShowUpDown = true; // Exibe um controle tipo "up-down" para seleção de hora/minutos

            DTP_Data1.Format = DateTimePickerFormat.Custom;
            DTP_Data1.CustomFormat = "dd/MM/yyyy";

            DTP_Data2.Format = DateTimePickerFormat.Custom;
            DTP_Data2.CustomFormat = "dd/MM/yyyy";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica o estado do CheckBox
            if (ChBox_FiltrarPorHora.Checked)
            {
                DTP_Hora1.Enabled = true;
                DTP_Hora2.Enabled = true;
            }
            else
            {
                DTP_Hora1.Enabled = false;
                DTP_Hora2.Enabled = false;
               
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Incluir_Pessoas_Click(object sender, EventArgs e)
        {
            Frm_CadastroAgendamento frm = new Frm_CadastroAgendamento();
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddColumnDataGridView()
        {
            try
            {
                // Se o DataGridView não tiver colunas, adicione-as
                if (DGV_Dados.Columns.Count == 0)
                {
                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns.Add("IdCategoria", "Categoria");
                    DGV_Dados.Columns.Add("pessoa", "Pessoa");
                    DGV_Dados.Columns.Add("DataAgendamento", "Data Agendamento");
                    DGV_Dados.Columns.Add("Hora1", "Hora inicio");
                    DGV_Dados.Columns.Add("Hora2", "Hora Fim");
                    DGV_Dados.Columns.Add("Local1", "Local");
                    DGV_Dados.Columns.Add("IdCarrinho", "Carrinho");
                    DGV_Dados.Columns.Add("IdSituacao", "Situação");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTodosAgendamento()
        {

            try
            {
                DGV_Dados.Rows.Clear();
                //Carrinho1 carrinho1 = new Carrinho1();
                AgendamentoServices AS = new AgendamentoServices();

                if (AS.Status)
                {
                    AS.ReadAllInDB(conexaoDB);

                    if (AS.Status)
                    {
                        // Pecorre a lista
                        foreach (Agendameto1 carrinhos in AS.Agendamentos)
                        {

                            AddAgendamentoToDataGridView(carrinhos);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{AS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{AS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Recebe um object Agendamento e convert para uma linha do DataGridView
        private void AddAgendamentoToDataGridView(Agendameto1 agendamento)
        {
            try
            {
                AddColumnDataGridView();

                string situacaoNome = metodos.IncluirValorSituacaoInDGV(Cbox_Situacao, agendamento.IdSituacao.ToString());
                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(agendamento.Id, agendamento.IdCategoria, agendamento.IdPessoa, agendamento.DataAgendamento, agendamento.Hora1, agendamento.Hora2, agendamento.Local, agendamento.IdCarrinho, situacaoNome);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
