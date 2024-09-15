using APP_DO_CARRINHO.Formularios.Pessoas;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.Situacao;
using banco.DataBases;
using DataBase.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Tela_Carrinho : Form
    {
        private ConexaoDB conexaoDB;
        private Metodos metodos;

        public ICollection<Situacao1> RetornoSituacoes = new List<Situacao1>();

        // Construtor
        public Frm_Tela_Carrinho()
        {
            InitializeComponent();

            conexaoDB = new ConexaoDB();
            metodos = new Metodos();

            AddColumnDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Cadastro_Carrinho_UC frm = new Frm_Cadastro_Carrinho_UC();
            frm.ShowDialog();
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Tela_Pessoas_Load(object sender, EventArgs e)
        {
       
            Metodos m = new Metodos();
            m.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao, true);
            
            CarregarTodosCarrinhos();
        }

        private void Btn_Filtrar_Click(object sender, EventArgs e)
        {
            var IndexDaSituacao = Cbox_Situacao.SelectedIndex;
            string codigoCarrinho = Txt_Carrinho_Cod.Text; // Novo campo para o código do carrinho
            string nomeCarrinho = Txt_Nome.Text;


            if (IndexDaSituacao == 0 && string.IsNullOrWhiteSpace(nomeCarrinho) && string.IsNullOrWhiteSpace(codigoCarrinho))
            {
                try
                {
                    DGV_Dados.Rows.Clear();
                    CarregarTodosCarrinhos();
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

                    CarrinhoService CS = new CarrinhoService();
                    if (CS.Status)
                    {
                        if (IndexDaSituacao > 0)
                        {
                            if (!string.IsNullOrWhiteSpace(codigoCarrinho) && !string.IsNullOrWhiteSpace(nomeCarrinho))
                            {
                                CS.FiltrarPorIDESituacaoNomeECodigoCarrinho(conexaoDB, IndexDaSituacao.ToString(), nomeCarrinho, codigoCarrinho);
                            }
                            else if (!string.IsNullOrWhiteSpace(nomeCarrinho))
                            {
                                CS.FiltrarPorSituacaoENome(conexaoDB, IndexDaSituacao.ToString(), nomeCarrinho);
                            }
                            else if (!string.IsNullOrWhiteSpace(codigoCarrinho))
                            {
                                CS.FiltrarPorSituacaoECodigoCarrinho(conexaoDB, IndexDaSituacao.ToString(), codigoCarrinho);
                            }
                            else
                            {
                                CS.FiltrarPorSituacao(conexaoDB, IndexDaSituacao.ToString());
                            }
                        }
                        else if (IndexDaSituacao == 0)
                        {
                            if (!string.IsNullOrWhiteSpace(nomeCarrinho) && !string.IsNullOrWhiteSpace(codigoCarrinho))
                            {
                                CS.FiltrarPorCodigoCarrinhoENome(conexaoDB, nomeCarrinho, codigoCarrinho);
                            }
                            else if (!string.IsNullOrWhiteSpace(nomeCarrinho))
                            {
                                CS.FiltrarPorNome(conexaoDB, nomeCarrinho);
                            }
                            else
                            {
                                CS.FiltrarPorCodigoCarrinho(conexaoDB, codigoCarrinho);
                            }
                        }
                        if (CS.Status)
                        {
                            foreach (Carrinho1 carrinhos in CS.Carrinhos)
                            {
                                AddCarrinhoToDataGridView(carrinhos);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Registro não encontrado na base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: {CS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
                    DGV_Dados.Columns.Add("congregacao_id", "Congregação ID");
                    DGV_Dados.Columns.Add("congregacao_nome", "Congregação Nome");
                    DGV_Dados.Columns.Add("situacao", "Situação");
                    DGV_Dados.Columns.Add("codigo_carrinho", "Código Carrinho");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Recebe um object Carrinho1 e convert para uma linha do DataGridView
        private void AddCarrinhoToDataGridView(Carrinho1 carrinho)
        {
            try
            {
                AddColumnDataGridView();

                string situacaoNome = metodos.IncluirValorSituacaoInDGV(Cbox_Situacao, Convert.ToInt32(carrinho.Situacao));
                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(
                    carrinho.ID,
                    carrinho.Nome,
                    carrinho.Congregacao_ID,
                    carrinho.Congregacao_Nome,
                    situacaoNome,
                    carrinho.Codigo_Carrinho
                );
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CarregarTodosCarrinhos()
        {
            
            try
            {
                DGV_Dados.Rows.Clear();
                //Carrinho1 carrinho1 = new Carrinho1();
                CarrinhoService CS = new CarrinhoService();
                
                if (CS.Status)
                {
                    CS.ReadAllInDB(conexaoDB);
                    
                    if (CS.Status)
                    {
                        // Pecorre a lista
                        foreach (Carrinho1 carrinhos in CS.Carrinhos)
                        {
                            
                            AddCarrinhoToDataGridView(carrinhos);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{CS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{CS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abre um
        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                string id = selectedRow.Cells["ID"].Value.ToString();
                string nome = selectedRow.Cells["nome"].Value.ToString();
                string congregacaoId = selectedRow.Cells["congregacao_id"].Value.ToString();
                //string congregacaoNome = selectedRow.Cells["congregacao_nome"].Value.ToString();
                string congregacaoNome = "Congregacao Areias";
                string situacao = selectedRow.Cells["situacao"].Value.ToString();
                string codigoCarrinho = selectedRow.Cells["codigo_carrinho"].Value.ToString();

                // Pass the data to the Frm_Cadastro_Carrinho_UC form
                Frm_Cadastro_Carrinho_UC frm = new Frm_Cadastro_Carrinho_UC();
                frm.InserirDadosInUserControl(id, nome, situacao, congregacaoId, congregacaoNome, codigoCarrinho);
                frm.ShowDialog();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void Btn_Alterar_Pessoas_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                string id = selectedRow.Cells["ID"].Value.ToString();
                string nome = selectedRow.Cells["nome"].Value.ToString();
                string congregacaoId = selectedRow.Cells["congregacao_id"].Value.ToString();
                //string congregacaoNome = selectedRow.Cells["congregacao_nome"].Value.ToString();
                string congregacaoNome = "Congregacao Areias";
                string situacao = selectedRow.Cells["situacao"].Value.ToString();
                string codigoCarrinho = selectedRow.Cells["codigo_carrinho"].Value.ToString();

                // Pass the data to the Frm_Cadastro_Carrinho_UC form
                Frm_Cadastro_Carrinho_UC frm = new Frm_Cadastro_Carrinho_UC();
                frm.InserirDadosInUserControl(id, nome, situacao, congregacaoId, congregacaoNome, codigoCarrinho);
                frm.ShowDialog();
                
                
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Btn_Excluir_Pessoas_Click(object sender, EventArgs e)
        {
            
            try
            {
                var resposta = MessageBox.Show("Você Realmente quer excluir o carrinho selecionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resposta == DialogResult.Yes)
                {
                    CarrinhoService carrinho = new CarrinhoService();
                    var selectedRow = DGV_Dados.CurrentRow;
                    int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    carrinho.DeleteInDB(conexaoDB, id);

                    if (carrinho.Status)
                    {
                        MessageBox.Show($"OK: {carrinho.Mensagem} Carrinho Excluido com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregarTodosCarrinhos();
                    }
                    else
                    {
                        MessageBox.Show($"{carrinho.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }  
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

