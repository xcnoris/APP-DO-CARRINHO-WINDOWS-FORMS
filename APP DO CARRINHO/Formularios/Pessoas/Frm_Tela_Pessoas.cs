using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.clientes;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Pessoas
{
    public partial class Frm_Tela_Pessoas : Form
    {
        private ConexaoDB conexaoDB;
        public Frm_Tela_Pessoas()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_CadastroPessoa_UC frm = new Frm_CadastroPessoa_UC();
            frm.ShowDialog();
          
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Tela_Pessoas_Load(object sender, EventArgs e)
        {
            CarregarTodasAsPessoas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void CarregarTodasAsPessoas()
        {
            try
            {
                PessoaService PS = new PessoaService();

                if (PS.Status)
                {
                    PS.ConsultarPessoasInDB(conexaoDB);

                    if (PS.Status)
                    {
                        // Pecorre a lista
                        foreach (Pessoa pessoa in PS.Pessoas)
                        {

                            AddPessoaToDataGridView(pessoa);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{PS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{PS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPessoaToDataGridView(Pessoa pessoa)
        {
            // Se o DataGridView não tiver colunas, adicione-as (isso pode ser opcional dependendo da estrutura do seu código)
            if (DGV_Dados.Columns.Count == 0)
            {
                DGV_Dados.Columns.Add("ID", "ID");
                DGV_Dados.Columns.Add("CPF", "CPF");
                DGV_Dados.Columns.Add("Nome", "Nome");
                DGV_Dados.Columns.Add("CEP", "CEP");
                DGV_Dados.Columns.Add("Cidade", "Cidade");
                DGV_Dados.Columns.Add("UF", "UF");
                DGV_Dados.Columns.Add("Endereço", "Endereço");
                DGV_Dados.Columns.Add("Número", "Número");
                DGV_Dados.Columns.Add("Complemento", "Complemento");
                DGV_Dados.Columns.Add("Bairro", "Bairro");
                DGV_Dados.Columns.Add("DDD Telefone", "DDD Telefone");
                DGV_Dados.Columns.Add("Telefone", "Telefone");
                DGV_Dados.Columns.Add("DDD Celular", "DDD Celular");
                DGV_Dados.Columns.Add("Celular", "Celular");
                DGV_Dados.Columns.Add("Sexo", "Sexo");
                DGV_Dados.Columns.Add("Data de Nascimento", "Data de Nascimento");
                DGV_Dados.Columns.Add("Email", "Email");
                DGV_Dados.Columns.Add("Congregação ID", "Congregação ID");
            }

            // Adicionar a linha ao DataGridView
            DGV_Dados.Rows.Add(
                pessoa.ID,
                pessoa.CPF,
                pessoa.Nome,
                pessoa.CEP,
                pessoa.Cidade_Nome,
                pessoa.UF,
                pessoa.Endereco,
                pessoa.Endereco_Numero,
                pessoa.Endereco_Complemento,
                pessoa.Bairro,
                pessoa.DDD_Telefone,
                pessoa.Telefone,
                pessoa.DDD_Celular,
                pessoa.Celular,
                pessoa.Sexo,
                pessoa.DataNascimento,
                pessoa.Email,
                pessoa.Congregacao_ID
            );
        }


    }
}
