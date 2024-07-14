using AppCarrinhoWFBiblioteca.Situacao;
using AppCarrinhoWFBiblioteca.agendamentos;
using AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1;
using AppCarrinhoWFBiblioteca.agendamentos.Situacao;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.classagendamento;
using banco.DataBases;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_DO_CARRINHO.Formularios.Carrinho;
using System.ComponentModel.DataAnnotations;

namespace APP_DO_CARRINHO.Formularios.FrmLocalPregacao
{
    public partial class FrmLocalPregacao : Form
    {
        private Metodos metodos;
        private ConexaoDB conexaoDB;

        private ICollection<AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao> RetornoBairros = new List<AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao>();
        public ICollection<Situacao1> RetornoSituacoes = new List<Situacao1>();


        public FrmLocalPregacao()
        {
            InitializeComponent();


            conexaoDB = new ConexaoDB();
            metodos = new Metodos();

            AddColumnDataGridView();

        }

        private void FrmLocalPregacao_Load(object sender, EventArgs e)
        {
            metodos.IncluirCamposBairro(conexaoDB, RetornoBairros, Cbox_Bairros, true);
            metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao, true);

            CarregarTodosLocaisPregracao();
        }



        private void CarregarTodosLocaisPregracao()
        {

            try
            {
                DGV_Dados.Rows.Clear();

                LocalPregracaoServices LPS = new LocalPregracaoServices();

                if (LPS.Status)
                {
                    LPS.ReadAllInDB(conexaoDB);

                    if (LPS.Status)
                    {
                        // Pecorre a lista
                        foreach (AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao localPregacao in LPS.LocaisPregracao)
                        {

                            AddLocalPregacaoToDataGridView(localPregacao);
                        }
                        RetornoBairros = LPS.LocaisPregracao ;
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Recebe um object LocalPregacao e convert para uma linha do DataGridView
        private void AddLocalPregacaoToDataGridView(AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao localPregacao)
        {
            try
            {
                AddColumnDataGridView();

                string situacaoNome = metodos.IncluirValorSituacaoInDGV(Cbox_Situacao, localPregacao.IdSituacao.Id);
                
                // Adicionar linha ao DataGridView
                DGV_Dados.Rows.Add(
                    localPregacao.Id,
                    localPregacao.Nome,
                    localPregacao.Endereco,
                    localPregacao.Bairro,
                    localPregacao.Cidade,
                    localPregacao.UF,
                    situacaoNome
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumnDataGridView()
        {
            try
            {
                // Se o DataGridView não tiver colunas, adicione-as
                if (DGV_Dados.Columns.Count == 0)
                {
                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns.Add("nome", "Nome");
                    DGV_Dados.Columns.Add("endereco", "Endereço");
                    DGV_Dados.Columns.Add("bairro", "Bairro");
                    DGV_Dados.Columns.Add("cidade", "Cidade");
                    DGV_Dados.Columns.Add("uf", "UF");
                    DGV_Dados.Columns.Add("situacao", "Situação");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Filtrar_Click(object sender, EventArgs e)
        {
            var IndexDoBairro = Cbox_Bairros.SelectedIndex;
            string ID = Txt_Id.Text;
            string nome = Txt_Nome.Text; 

            if (IndexDoBairro == 0 && string.IsNullOrWhiteSpace(ID) && string.IsNullOrWhiteSpace(nome))
            {
                try
                {
                    DGV_Dados.Rows.Clear();
                    CarregarTodosLocaisPregracao();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    DGV_Dados.Rows.Clear();

                    LocalPregracaoServices LPS = new LocalPregracaoServices();
                    if (LPS.Status)
                    {
                        if (!string.IsNullOrWhiteSpace(ID))
                        {
                            LPS.ReadInDB(conexaoDB, ID);
                        }
                        else if (IndexDoBairro > 0)
                        {
                        //    if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(ID))
                        //    {
                        //        LPS.FiltrarPorIDESituacaoNomeECodigoCarrinho(conexaoDB, IndexDoBairro.ToString(), nomeCarrinho, codigoCarrinho);
                        //    }
                        //    else if (!string.IsNullOrWhiteSpace(nomeCarrinho))
                        //    {
                        //        LPS.FiltrarPorSituacaoENome(conexaoDB, IndexDoBairro.ToString(), nomeCarrinho);
                        //    }
                        //    else if (!string.IsNullOrWhiteSpace(codigoCarrinho))
                        //    {
                        //        LPS.FiltrarPorSituacaoECodigoCarrinho(conexaoDB, IndexDoBairro.ToString(), codigoCarrinho);
                        //    }
                        //    else
                        //    {
                        //        LPS.FiltrarPorSituacao(conexaoDB, IndexDoBairro.ToString());
                        //    }
                        //}
                        //else if (IndexDoBairro == 0)
                        //{
                        //    if (!string.IsNullOrWhiteSpace(nomeCarrinho) && !string.IsNullOrWhiteSpace(codigoCarrinho))
                        //    {
                        //        LPS.FiltrarPorCodigoCarrinhoENome(conexaoDB, nomeCarrinho, codigoCarrinho);
                        //    }
                        //    else if (!string.IsNullOrWhiteSpace(nomeCarrinho))
                        //    {
                        //        LPS.FiltrarPorNome(conexaoDB, nomeCarrinho);
                        //    }
                        //    else
                        //    {
                        //        LPS.FiltrarPorCodigoCarrinho(conexaoDB, codigoCarrinho);
                        //    }
                        }
                        if (LPS.Status)
                        {
                            foreach (AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao localPregacao in LPS.LocaisPregracao)
                            {
                                AddLocalPregacaoToDataGridView(localPregacao);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Registro não encontrado na base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: {LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Btn_Incluir_Pessoas_Click(object sender, EventArgs e)
        {
            FrmCadastroLocalPregacao frm = new FrmCadastroLocalPregacao();
            frm.ShowDialog();
        }

        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string nome = selectedRow.Cells["nome"].Value.ToString();
                string endereco = selectedRow.Cells["endereco"].Value.ToString();
                string bairro = selectedRow.Cells["bairro"].Value.ToString();
                string cidade = selectedRow.Cells["cidade"].Value.ToString();
                string uf = selectedRow.Cells["uf"].Value.ToString();
                string situacao = selectedRow.Cells["situacao"].Value.ToString();
                string complemento = "";

                // Pass the data to the Frm_Cadastro_Carrinho_UC form
                FrmCadastroLocalPregacao frm = new FrmCadastroLocalPregacao();
                frm.InserirDadosInFrm(id, nome, situacao, endereco, complemento, bairro, cidade);
                frm.ShowDialog();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
