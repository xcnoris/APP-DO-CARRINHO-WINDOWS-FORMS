using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCarrinhoWFBiblioteca.clientes;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.cep;
using AppCarrinhoWFBiblioteca.carrinho1;
using banco.DataBases;
using APP_DO_CARRINHO.Formularios.Carrinho;

namespace APP_DO_CARRINHO.Formularios.Pessoas
{
    public partial class Frm_CadastroPessoa_UC : Form
    {
        private Frm_Geral_Pessoa_UC frmGeralUSPessoas;

        private ConexaoDB conexaoDB;
        // Controla se o clinte vai incluir um novo carrinho, ou atualizar um existente
        private bool ControleSalvarIncluirPessoa = true;

        public Frm_CadastroPessoa_UC()
        {
            InitializeComponent();
            conexaoDB = new ConexaoDB();
            frmGeralUSPessoas = new Frm_Geral_Pessoa_UC(); // Inicialize o objeto aqui
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_CadastroPessoa_UC_Load(object sender, EventArgs e)
        {
            frmGeralUSPessoas.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frmGeralUSPessoas);
            Tbc_CadastroUsuario.TabPages.Add(TB);

        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Função de incluir no banco o nova pessoa
                if (ControleSalvarIncluirPessoa)
                {
                    // Instancia a class e puxa os dados do formulario
                    Pessoa pessoa = LeituraFormulario();
                    // Valida os dados
                    pessoa.ValidarClass();
                    // Tenta incluir os dados no banco de dados
                    pessoa.IncluirNoBanco(conexaoDB);
                    if (pessoa.Status)
                    {
                        ControleSalvarIncluirPessoa = true;
                        MessageBox.Show($"OK: {pessoa.Mensagem} Carrinho incluído com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirPessoa = true;
                        MessageBox.Show($"{pessoa.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                // Funcao de atualizar Pessoa no banco
                else
                {
                    // Instancia a class e puxa os dados do formulario
                    Pessoa pessoa = LeituraFormulario();
                    // Valida os dados
                    pessoa.ValidarClass();
                    // Tenta incluir os dados no banco de dados
                    pessoa.AtualizarNoBanco(conexaoDB);
                    if (pessoa.Status)
                    {
                        ControleSalvarIncluirPessoa = true;
                        MessageBox.Show($"OK: {pessoa.Mensagem} Carrinho Atualizado com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirPessoa = true;
                        MessageBox.Show($"{pessoa.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Pessoa LeituraFormulario()
        {

            Pessoa cliente = new Pessoa
            {
                ID = frmGeralUSPessoas.Id,
                CPF = Regex.Replace(frmGeralUSPessoas.CPF, @"[^\d]", ""),
                Nome = frmGeralUSPessoas.Nome,
                CEP = frmGeralUSPessoas.CEP_Numero,
                //ID_Cidade = frmGeralUSPessoas.Cidade_Cod,
                Cidade_Nome = frmGeralUSPessoas.Cidade_Nome,
                UF = frmGeralUSPessoas.UF,
                Endereco = frmGeralUSPessoas.Endereco,
                Endereco_Numero = frmGeralUSPessoas.Endereco_Numero,
                Endereco_Complemento = frmGeralUSPessoas.Endereco_Complemento,
                Bairro = frmGeralUSPessoas.Endereco_Bairro,
                DDD_Telefone = frmGeralUSPessoas.Telefone_DDD,
                Telefone = frmGeralUSPessoas.Telefone_Numero,
                DDD_Celular = frmGeralUSPessoas.Celular_DDD,
                Celular = frmGeralUSPessoas.Celular_Numero,
                Sexo = frmGeralUSPessoas.Sexo,
                DataNascimento = frmGeralUSPessoas.Data_Nascimento,
                Email = frmGeralUSPessoas.Email
            };

            return cliente;
        }

        public void InserirDadosInUserControlPessoa(string id, string cpf, string nome, string cep, string cidade, string uf, string endereco, string numero, string complemento, string bairro, string telefoneDDD, string telefoneNumero, string celularDDD, string celularNumero, string sexo, string dataNascimento, string email, string congregacaoId, string situacao)
        {
            ControleSalvarIncluirPessoa = false;
            frmGeralUSPessoas.SetPessoaData(id, cpf, nome, cep, cidade, uf, endereco, numero, complemento, bairro, telefoneDDD, telefoneNumero, celularDDD, celularNumero, sexo, dataNascimento, email, congregacaoId, situacao);
        }

        private void Tbc_CadastroUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
