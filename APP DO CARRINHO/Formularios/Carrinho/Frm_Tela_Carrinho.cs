using APP_DO_CARRINHO.Formularios.Pessoas;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
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
        public Frm_Tela_Carrinho()
        {
            InitializeComponent();
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
                   
                    Carrinho1 carrinho1 = new Carrinho1();
                    Fichario F = new Fichario("C:\\Users\\augus\\OneDrive\\Documentos\\PROJETOS PESSOAIS\\PROJETOS COM C#\\APP CARRINHO - WINDOWS FORMS\\Fichario");
                    // Caso consiga criar/acessar o diretorio ele entra no if
                    if (F.Status)
                    {
                        string carrinhoJson = F.Buscar(Txt_Id.Text);
                        if (F.Status)
                        {
                            
                            // Desserializar o JSON para a classe Carrinho1.Unit
                            Carrinho1 carrinho = CarrinhoService.DesSerializedClassUnit(carrinhoJson);

                            // Adicionar o carrinho desserializado ao DataGridView
                            AddCarrinhoToDataGridView(carrinho);
                            Txt_Id.Text = "";
                        }
                        else
                        {
                            MessageBox.Show($"ID {Txt_Id.Text} Não Localizado Na Base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //MessageBox.Show(carrinhoJson);

                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: {F.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DGV_Dados.Columns.Add("Nome", "Nome");
                DGV_Dados.Columns.Add("Congregacao_ID", "Congregação ID");
                DGV_Dados.Columns.Add("Congregacao_Nome", "Congregação Nome");
                DGV_Dados.Columns.Add("Situacao", "Situação");
                DGV_Dados.Columns.Add("Codigo_Carrinho", "Código Carrinho");
            }

            // Adicionar a linha ao DataGridView
            DGV_Dados.Rows.Add(carrinho.ID, carrinho.Nome, carrinho.Congregacao_ID, carrinho.Congregacao_Nome, carrinho.Situacao, carrinho.Codigo_Carrinho);
        }


        private void CarregarTodosCarrinhos()
        {
            try
            {
                Carrinho1 carrinho1 = new Carrinho1();
                Fichario fichario = new Fichario("C:\\Users\\augus\\OneDrive\\Documentos\\PROJETOS PESSOAIS\\PROJETOS COM C#\\APP CARRINHO - WINDOWS FORMS\\Fichario");
                if (fichario.Status)
                {
                    // Cria uma lista com os Json dos carrinho
                    List<string> carrinhosJson = fichario.ListarTodos();
                    if (fichario.Status)
                    {
                        // Pecorre a lista
                        foreach (string carrinhoJson in carrinhosJson)
                        {
                            Carrinho1 carrinho = CarrinhoService.DesSerializedClassUnit(carrinhoJson);
                            AddCarrinhoToDataGridView(carrinho);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: {fichario.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: {fichario.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
