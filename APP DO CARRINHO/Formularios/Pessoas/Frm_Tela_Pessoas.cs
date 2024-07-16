using APP_DO_CARRINHO.Formularios.Carrinho;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.clientes;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Pessoas
{
    public partial class Frm_Tela_Pessoas : Form
    {
        private ConexaoDB conexaoDB;
        public Frm_Tela_Pessoas()
        {
            InitializeComponent();
            //AddColumnDataGridView();
            // conexaoDB = new ConexaoDB();
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
            AddColumnDataGridView();
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
                DGV_Dados.Rows.Clear();
                PessoaService PS = new PessoaService();

                if (PS.Status)
                {
                    PS.ReadAllInDB(conexaoDB);

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


        private void Btn_Filtrar_Click(object sender, EventArgs e)
        {
            string nome_Cliente = Txt_Nome.Text;
            string id_Cliente = Txt_Id.Text;
            string cpf_Cliente = Txt_Cpf.Text; 


            // Caso todos os campos estejam em branco, ele busca todos os carrinho
            if ((id_Cliente == "") && string.IsNullOrWhiteSpace(nome_Cliente) && (cpf_Cliente == ""))
            {
                try
                {
                    DGV_Dados.Rows.Clear();
                    CarregarTodasAsPessoas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Caso o campo do id não seja nulo, ele busca pelo id do cliente
            else if(!string.IsNullOrWhiteSpace(id_Cliente))
            {
                try
                {
                    PessoaService PS = new PessoaService();
                    
                    if (PS.Status)
                    {
                        // Busca a pessoa pelo id
                        PS.ReadInDB(conexaoDB, Txt_Id.Text);

                        if (PS.Status)
                        {
                            DGV_Dados.Rows.Clear();
                            // Pecorre a lista
                            foreach (Pessoa pessoa in PS.Pessoas)
                            {

                                AddPessoaToDataGridView(pessoa);
                            }

                        }
                        else
                        {
                            MessageBox.Show($"ID {Txt_Id.Text} Não Localizado Na Base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: {PS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private void CarregarTodasPessoas()
        {
            try
            {
                // Instancia a class service
                PessoaService PS = new PessoaService();

                // Verifica se deu certo a instanciação
                if (PS.Status)
                {
                    // Chama o metodo de buscar todos os carrinho no banco de dados
                    PS.ReadAllInDB(conexaoDB);

                    // Verifica se deu certo a consulta no banco. Caso deu certo entra no if
                    if (PS.Status)
                    {
                        // Pecorre a lista de dados que retornou na consulta no banco
                        foreach (Pessoa pessoa in PS.Pessoas)
                        {
                            // Add linha por linha
                            AddPessoaToDataGridView(pessoa);
                        }
                    }
                    // Caso deu errado, entra no else
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

        private void AddColumnDataGridView() 
        {
            try
            {
                // Se o DataGridView não tiver colunas, adicione-as
                if (DGV_Dados.Columns.Count == 0)
                {
                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns.Add("CPF", "CPF");
                    DGV_Dados.Columns.Add("Nome", "Nome");
                    DGV_Dados.Columns.Add("CEP", "CEP");
                    DGV_Dados.Columns.Add("Cidade_Nome", "Cidade Nome");
                    DGV_Dados.Columns.Add("UF", "UF");
                    DGV_Dados.Columns.Add("Endereco", "Endereço");
                    DGV_Dados.Columns.Add("Endereco_Numero", "Endereço Número");
                    DGV_Dados.Columns.Add("Endereco_Complemento", "Endereço Complemento");
                    DGV_Dados.Columns.Add("Bairro", "Bairro");
                    DGV_Dados.Columns.Add("DDD_Telefone", "DDD Telefone");
                    DGV_Dados.Columns.Add("Telefone", "Telefone");
                    DGV_Dados.Columns.Add("DDD_Celular", "DDD Celular");
                    DGV_Dados.Columns.Add("Celular", "Celular");
                    DGV_Dados.Columns.Add("Sexo", "Sexo");
                    DGV_Dados.Columns.Add("DataNascimento", "Data Nascimento");
                    DGV_Dados.Columns.Add("Email", "Email");
                    DGV_Dados.Columns.Add("Congregacao_ID", "Congregação ID");
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


        // Recebe um object Pessoa, e inclui os valores em uma linha do DataGridView
        private void AddPessoaToDataGridView(Pessoa pessoa)
        {

            Metodos m = new Metodos();
            string cpfFormatado = m.FormatCPF(pessoa.CPF);

            AddColumnDataGridView();

            // Adicionar a linha ao DataGridView
            DGV_Dados.Rows.Add(
                pessoa.ID,
                cpfFormatado,
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

        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            // Verifique se há uma linha selecionada
            if (DGV_Dados.CurrentRow != null)
            {
                // Recupere os dados da linha selecionada
                var selectedRow = DGV_Dados.CurrentRow;
                string id = selectedRow.Cells["ID"].Value.ToString();
                string cpf = selectedRow.Cells["CPF"].Value.ToString();
                string nome = selectedRow.Cells["Nome"].Value.ToString();
                string cep = selectedRow.Cells["CEP"].Value.ToString();
                string cidadeNome = selectedRow.Cells["Cidade_Nome"].Value.ToString();
                string uf = selectedRow.Cells["UF"].Value.ToString();
                string endereco = selectedRow.Cells["Endereco"].Value.ToString();
                string enderecoNumero = selectedRow.Cells["Endereco_Numero"].Value.ToString();
                string enderecoComplemento = selectedRow.Cells["Endereco_Complemento"].Value.ToString();
                string bairro = selectedRow.Cells["Bairro"].Value.ToString();
                string dddTelefone = selectedRow.Cells["DDD_Telefone"].Value.ToString();
                string telefone = selectedRow.Cells["Telefone"].Value.ToString();
                string dddCelular = selectedRow.Cells["DDD_Celular"].Value.ToString();
                string celular = selectedRow.Cells["Celular"].Value.ToString();
                string sexo = selectedRow.Cells["Sexo"].Value.ToString();
                string dataNascimento = selectedRow.Cells["DataNascimento"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string congregacaoId = selectedRow.Cells["Congregacao_ID"].Value.ToString();
                string situacao = "1";
                // Passe os dados para o formulário Frm_CadastroPessoa_UC
                Frm_CadastroPessoa_UC frm = new Frm_CadastroPessoa_UC();
                frm.InserirDadosInUserControlPessoa(id, cpf, nome, cep, cidadeNome, uf, endereco, enderecoNumero, enderecoComplemento, bairro, dddTelefone, telefone, dddCelular, celular, sexo, dataNascimento, email, congregacaoId, situacao);
                frm.ShowDialog();
            }

        }

        private void Btn_Alterar_Pessoas_Click(object sender, EventArgs e)
        {
            try
            {

                // Verifique se há uma linha selecionada
                if (DGV_Dados.CurrentRow != null)
                {
                    // Recupere os dados da linha selecionada
                    var selectedRow = DGV_Dados.CurrentRow;
                    string id = selectedRow.Cells["ID"].Value.ToString();
                    string cpf = selectedRow.Cells["CPF"].Value.ToString();
                    string nome = selectedRow.Cells["Nome"].Value.ToString();
                    string cep = selectedRow.Cells["CEP"].Value.ToString();
                    string cidadeNome = selectedRow.Cells["Cidade_Nome"].Value.ToString();
                    string uf = selectedRow.Cells["UF"].Value.ToString();
                    string endereco = selectedRow.Cells["Endereco"].Value.ToString();
                    string enderecoNumero = selectedRow.Cells["Endereco_Numero"].Value.ToString();
                    string enderecoComplemento = selectedRow.Cells["Endereco_Complemento"].Value.ToString();
                    string bairro = selectedRow.Cells["Bairro"].Value.ToString();
                    string dddTelefone = selectedRow.Cells["DDD_Telefone"].Value.ToString();
                    string telefone = selectedRow.Cells["Telefone"].Value.ToString();
                    string dddCelular = selectedRow.Cells["DDD_Celular"].Value.ToString();
                    string celular = selectedRow.Cells["Celular"].Value.ToString();
                    string sexo = selectedRow.Cells["Sexo"].Value.ToString();
                    string dataNascimento = selectedRow.Cells["DataNascimento"].Value.ToString();
                    string email = selectedRow.Cells["Email"].Value.ToString();
                    string congregacaoId = selectedRow.Cells["Congregacao_ID"].Value.ToString();
                    string situacao = "1";
                    // Passe os dados para o formulário Frm_CadastroPessoa_UC
                    Frm_CadastroPessoa_UC frm = new Frm_CadastroPessoa_UC();
                    frm.InserirDadosInUserControlPessoa(id, cpf, nome, cep, cidadeNome, uf, endereco, enderecoNumero, enderecoComplemento, bairro, dddTelefone, telefone, dddCelular, celular, sexo, dataNascimento, email, congregacaoId, situacao);
                    frm.ShowDialog();
                }
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

                // Verifique se há uma linha selecionada
                if (DGV_Dados.CurrentRow != null)
                {
                    var resposta = MessageBox.Show("Você Realmente quer excluir a Pessoa selecionada?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resposta == DialogResult.Yes)
                    {
                        PessoaService pessoa = new PessoaService();
                        var selectedRow = DGV_Dados.CurrentRow;
                        string id = selectedRow.Cells["ID"].Value.ToString();
                        pessoa.DeleteInDB(conexaoDB, id);

                        if (pessoa.Status)
                        {
                            MessageBox.Show($"OK: {pessoa.Mensagem} Carrinho Excluido com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CarregarTodasAsPessoas();
                        }
                        else
                        {
                            MessageBox.Show($"{pessoa.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
