using AppCarrinhoWFBiblioteca.agendamentos;
using AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1;
using AppCarrinhoWFBiblioteca.agendamentos.Situacao;
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

        private ICollection<Agendameto1> RetornoBairros = new List<Agendameto1>();


        public FrmLocalPregacao()
        {
            InitializeComponent();


            conexaoDB = new ConexaoDB();
            metodos = new Metodos();

            AddColumnDataGridView();

        }

        private void FrmLocalPregacao_Load(object sender, EventArgs e)
        {
            //metodos.IncluirCamposBairro(conexaoDB, RetornoBairros, Cbox_Bairros, true);


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

                // Adicionar linha ao DataGridView
                DGV_Dados.Rows.Add(
                    localPregacao.Id,
                    localPregacao.Nome,
                    localPregacao.Endereco,
                    localPregacao.Bairro,
                    localPregacao.Cidade,
                    localPregacao.UF
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
                    DGV_Dados.Columns.Add("complemento", "Complemento");
                    DGV_Dados.Columns.Add("bairro", "Bairro");
                    DGV_Dados.Columns.Add("cidade", "Cidade");
                    DGV_Dados.Columns.Add("uf", "UF");
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
    }
}
