using APP_DO_CARRINHO.Formularios.Pessoas;
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
            // Caso tenha algum caracter no TextBox ele tenta filtrar
            if((Txt_Id.Text == ""))
            {
                try
                {

                    DGV_Dados.Rows.Clear();
                    CarregarTodosCarrinhos();
                }
                catch(Exception ex)
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
                    // Caso consiga criar/acessar o diretorio ele entra no if
                    if (CS.Status)
                    {
                        CS.ConsultarCarrinhosPorID(conexaoDB, Txt_Id.Text);
                        
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
                            MessageBox.Show($"ID {Txt_Id.Text} Não Localizado Na Base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //MessageBox.Show(carrinhoJson);

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
                //DGV_Dados.Columns.Add("congregacao_nome", "Congregação Nome");
                DGV_Dados.Columns.Add("situacao", "Situação");
                DGV_Dados.Columns.Add("codigo_carrinho", "Código Carrinho");
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
                    CS.ConsultarCarrinhosInDB(conexaoDB);
                    
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

    }
}
