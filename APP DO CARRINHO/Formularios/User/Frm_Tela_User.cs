using APP_DO_CARRINHO.Formularios.Carrinho;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.User;
using AppCarrinhoWFBiblioteca.Users;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.User
{
    public partial class Frm_Tela_User : Form
    {

        private ConexaoDB conexaoDB;

        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();

        public Frm_Tela_User()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
            AddColumnDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Tela_User_Load(object sender, EventArgs e)
        {

            Metodos m = new Metodos();
            m.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao);

            AddColumnDataGridView();
            CarregarTodosCarrinhos();
        }


        private void AddColumnDataGridView()
        {
            // Se o DataGridView não tiver colunas, adicione-as
            if (DGV_Dados.Columns.Count == 0)
            {
                DGV_Dados.Columns.Add("ID", "ID");
                DGV_Dados.Columns.Add("CPF", "CPF");
                DGV_Dados.Columns.Add("Nome", "Nome");
                DGV_Dados.Columns.Add("Situação", "Situação");
                DGV_Dados.Columns.Add("Login", "Login");
                DGV_Dados.Columns.Add("Tipo", "Tipo");

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CarregarTodosCarrinhos()
        {

            try
            {
                DGV_Dados.Rows.Clear();
                //Carrinho1 carrinho1 = new Carrinho1();
                UserServices US = new UserServices();

                if (US.Status)
                {
                    US.ReadAllInDB(conexaoDB);

                    if (US.Status)
                    {
                        // Pecorre a lista
                        foreach (User1 user in US.usuarios)
                        {

                            AddCarrinhoToDataGridView(user);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{US.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{US.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Recebe um object Carrinho1 e convert para uma linha do DataGridView
        private void AddCarrinhoToDataGridView(User1 user)
        {
            try
            {
                AddColumnDataGridView();

                string situacao;
                if (user.Id_Situacao == "1")
                {
                    user.Id_Situacao = "Ativo";

                }
                if (user.Id_Situacao == "2")
                {
                    user.Id_Situacao = "Inativo";

                }

                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(user.Id, user.CPF, user.Nome,user.Id_Situacao, user.Login, user.Id_Tipo);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Incluir_User_Click(object sender, EventArgs e)
        {
            Frm_Cadastro_Usuario frm = new Frm_Cadastro_Usuario();
            frm.Show();
        }

        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                if (selectedRow != null) 
                {

                    string id = selectedRow.Cells["ID"].Value.ToString();
                    string cpf = selectedRow.Cells["CPF"].Value.ToString();
                    string nome = selectedRow.Cells["Nome"].Value.ToString();
                    string situacao = selectedRow.Cells["Situacao"].Value.ToString();
                    string login = selectedRow.Cells["Login"].Value.ToString();
                    string tipo = selectedRow.Cells["Tipo"].Value.ToString();

                    // Pass the data to the Frm_Cadastro_Carrinho_UC form
                    Frm_Cadastro_Usuario frm = new Frm_Cadastro_Usuario();
                    frm.InserirDadosInFrm(id, cpf, nome, situacao, login, tipo);
                    frm.ShowDialog();
                }
           
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_Dados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
