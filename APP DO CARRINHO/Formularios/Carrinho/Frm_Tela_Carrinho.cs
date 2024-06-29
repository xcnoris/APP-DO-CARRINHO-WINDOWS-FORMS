using APP_DO_CARRINHO.Formularios.Pessoas;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using banco.DataBases;
using DataBase.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    public partial class Frm_Tela_Carrinho : Form
    {
        private ConexaoDB conexaoDB;

        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();

        // Construtor
        public Frm_Tela_Carrinho()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
        }

        private void Frm_Tela_Carrinho_Load(object sender, EventArgs e)
        {
    
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
            m.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao);
            CarregarTodosCarrinhos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Filtrar_Click(object sender, EventArgs e)
        {
            // Caso não tenha caracter no TextBox ele filtra todos os carrinhos
            var IndexDaSituacao = Cbox_Situacao.SelectedIndex;
            

            if (string.IsNullOrWhiteSpace(Txt_Id.Text) && IndexDaSituacao == 0)
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
                // Caso tenha algum valor no Txt_Id ou Situação ele tenta buscar no Banco de dados
                try
                {
                    DGV_Dados.Rows.Clear();

                    CarrinhoService CS = new CarrinhoService();
                    // Caso consiga criar/acessar o diretorio ele entra no if
                    if (CS.Status)
                    {
                        
                        if (!string.IsNullOrWhiteSpace(Txt_Id.Text) && IndexDaSituacao > 0)
                        {
                            // Filtrar por ID e Situação
                            
                            
                            CS.ReadInDBWithFilter(conexaoDB, Txt_Id.Text, IndexDaSituacao.ToString());
                        }
                        else if (!string.IsNullOrWhiteSpace(Txt_Id.Text))
                        {
                            // Filtrar apenas por ID
                            CS.ReadInDB(conexaoDB, Txt_Id.Text);
                        }
                        else if (IndexDaSituacao > 0)
                        {
                            // Filtrar apenas por Situação
                            //string situacao = Cbox_Situacao.SelectedItem.ToString();
                            CS.ReadInDBBySituacao(conexaoDB, IndexDaSituacao.ToString());
                        }

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
        private void AddCarrinhoToDataGridView(Carrinho1 carrinho)
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
            string situacao;
            if(carrinho.Situacao == "1")
            {
                carrinho.Situacao = "Ativo";
                
            }
            if (carrinho.Situacao == "2")
            {
                carrinho.Situacao = "Inativo";
                
            }

            // Adicionar a linha ao DataGridView
            DGV_Dados.Rows.Add(carrinho.ID, carrinho.Nome, carrinho.Congregacao_ID, carrinho.Congregacao_Nome, carrinho.Situacao, carrinho.Codigo_Carrinho);
        }


        private void CarregarTodosCarrinhos()
        {
            try
            {
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
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Abre um
        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
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

        private void Btn_Alterar_Pessoas_Click(object sender, EventArgs e)
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
    }
}

