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

namespace APP_DO_CARRINHO.Formularios.LocalPregacao
{
    public partial class FrmLocalPregacao : Form
    {
        private Metodos metodos;
        private ConexaoDB conexaoDB;

        private ICollection<LocalPregracao> RetornoBairros = new List<LocalPregracao>();
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
                        foreach (LocalPregracao localPregacao in LPS.LocaisPregracao)
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
        private void AddLocalPregacaoToDataGridView(LocalPregracao localPregacao)
        {
            try
            {
                AddColumnDataGridView();

                // Funcoes para comparar o id retornado do banco, com o id dos valores dos combo box, caso tenha um id igual no combox box
                // retorna o valor(nome) do id
                //string categoriaNome = metodos.IncluirValorCategoriInDGV(Cbox_CategoriaAgendamento, localPregacao.IdCategoria.ToString());
                //string carrinhoNome = metodos.IncluirValorCarrinhoInDGV(Cbox_Carrinhos, localPregacao.CodCarrinho.ToString());
                //string situacaoNome = metodos.IncluirValorSituacaoAgendamentoInDGV(Cbox_Situacao, localPregacao.IdSituacao.ToString());
                //string nomeCliente = metodos.IncluirValorPessoaInDGV(RetornoPessoas, localPregacao.IdPessoa);
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
                            foreach (LocalPregracao localPregacao in LPS.LocaisPregracao)
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
    }
}
