using APP_DO_CARRINHO.Formularios.Carrinho;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.clientes;
using AppCarrinhoWFBiblioteca.User;
using AppCarrinhoWFBiblioteca.Users;
using banco.DAL.DataBases;
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

        // Icolletion usaddo para armazenar o retorno da consulta no DB
        public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();
        public ICollection<TipoUser> RetornoTipos = new List<TipoUser>();

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
            m.IncluirCamposTipoUser(conexaoDB, RetornoTipos, Cbox_TipoUser);

            AddColumnDataGridView();
            CarregarTodosUsers();
        }


        private void AddColumnDataGridView()
        {
            // Se o DataGridView não tiver colunas, adicione-as
            if (DGV_Dados.Columns.Count == 0)
            {
                DGV_Dados.Columns.Add("ID", "ID");
                DGV_Dados.Columns.Add("CPF", "CPF");
                DGV_Dados.Columns.Add("Nome", "Nome");
                DGV_Dados.Columns.Add("Login", "Login");
                DGV_Dados.Columns.Add("Tipo", "Tipo");
                DGV_Dados.Columns.Add("Situação", "Situação");

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CarregarTodosUsers()
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

                            AddUserToDataGridView(user);
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
        private void AddUserToDataGridView(User1 user)
        {
            try
            {
                AddColumnDataGridView();

                
                if (user.Id_Situacao == "1")
                {
                    user.Id_Situacao = "Ativo";

                }
                if (user.Id_Situacao == "2")
                {
                    user.Id_Situacao = "Inativo";

                }
                Metodos m = new Metodos();
                string cpfFormatado = m.FormatCPF(user.CPF);

                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(user.Id, cpfFormatado, user.Nome,  user.Login, user.Id_Tipo, user.Id_Situacao);
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
                    string situacao = selectedRow.Cells["Situação"].Value.ToString();
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

        private void Btn_Filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome_Cliente = Txt_Nome.Text;
                string login = Txt_Login.Text;
                string situacao = Cbox_Situacao.Text;
                string tipo = Cbox_TipoUser.Text;


                // Caso todos os campos estejam em branco, ele busca todos os carrinho
                //if ((id_Cliente == "") && string.IsNullOrWhiteSpace(nome_Cliente) && (cpf_Cliente == ""))
                if (string.IsNullOrEmpty(nome_Cliente))
                {
                    try
                    {
                        DGV_Dados.Rows.Clear();
                        CarregarTodosUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Caso o campo do id não seja nulo, ele busca pelo id do cliente
                //else if (!string.IsNullOrWhiteSpace(id_Cliente))
                else if (1 ==1 )
                {
                    try
                    {
                        UserServices US = new UserServices();

                        if (US.Status)
                        {
                            // Busca a pessoa pelo id
                            US.ReadInDB(conexaoDB, Txt_Nome.Text);

                            if (US.Status)
                            {
                                DGV_Dados.Rows.Clear();
                                // Pecorre a lista
                                foreach (User1 pessoa in US.usuarios)
                                {

                                    AddUserToDataGridView(pessoa);
                                }

                            }
                            else
                            {
                                MessageBox.Show($"ID {Txt_Nome.Text} Não Localizado Na Base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"[ERROR]: {US.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                string id;
                if (selectedRow != null)
                {
                    // Atribui o valor do id da linha selecionada a variavel id
                    id = selectedRow.Cells["ID"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Nenhuma linha selecionada.", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Instancia a classe
                UserServices US = new UserServices();

                if (US.Status)
                {
                    // Busca o usuário pelo id
                    US.ReadInDB(conexaoDB, id);

                    if (US.Status)
                    {
                        //DGV_Dados.Rows.Clear();

                        // Percorre a lista
                        foreach (User1 user in US.usuarios)
                        {
                            // Caso o user tenha o campo senha em branco no DB, entra no if
                            if (string.IsNullOrEmpty(user.Senha))
                            {
                                Random random = new Random();

                                // Gera um número aleatório de 4 dígitos
                                string randomNumber = random.Next(1000, 10000).ToString();

                                // transforma o numero gerado em hash
                                string senhaInHasg = ComandosDB.GetMD5Hasg(randomNumber);
                                user.Senha = senhaInHasg;

                                // Atualiza no banco
                                user.AtualizarNoBanco(conexaoDB);
                                if (user.Status)
                                {
                                    MessageBox.Show($"Senha {randomNumber} gerada com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"[ERROR]: {user.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                // Caso nao seja branco o campo, mostra a imagem
                                MessageBox.Show("Usuario já tem senha gerada!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"ID {id} não localizado na base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: {US.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Excluir_User_Click(object sender, EventArgs e)
        {


            try
            {

                var selectedRow = DGV_Dados.CurrentRow;


                string idnumero = selectedRow.Cells["ID"].Value.ToString();
                string cpf = selectedRow.Cells["CPF"].Value.ToString();
                string nome = selectedRow.Cells["Nome"].Value.ToString();


                if (selectedRow != null)
                {
                    var resposta = MessageBox.Show($"Você Realmente quer excluir o usuario  selecionado, {nome}?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resposta == DialogResult.Yes)
                    {
                        UserServices US = new UserServices();

                        string id = selectedRow.Cells["ID"].Value.ToString();
                        US.DeleteInDB(conexaoDB, id);

                        if (US.Status)
                        {
                            MessageBox.Show($"OK: {US.Mensagem} user Excluido com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CarregarTodosUsers();
                        }
                        else
                        {
                            MessageBox.Show($"{US.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Btn_Alterar_User_Click(object sender, EventArgs e)
        {

            try
            {

                var selectedRow = DGV_Dados.CurrentRow;

                if (selectedRow != null)
                {


                    string idnumero = selectedRow.Cells["ID"].Value.ToString();
                    string cpf = selectedRow.Cells["CPF"].Value.ToString();
                    string nome = selectedRow.Cells["Nome"].Value.ToString();
                    string login = selectedRow.Cells["Login"].Value.ToString();
                    string tipo = selectedRow.Cells["Tipo"].Value.ToString();
                    string situacao = selectedRow.Cells["Situação"].Value.ToString();


                    Frm_Cadastro_Usuario frm = new Frm_Cadastro_Usuario();
                    frm.InserirDadosInFrm(idnumero, cpf, nome,situacao , login,tipo);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show($"Nenhuma linha selecionada!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
