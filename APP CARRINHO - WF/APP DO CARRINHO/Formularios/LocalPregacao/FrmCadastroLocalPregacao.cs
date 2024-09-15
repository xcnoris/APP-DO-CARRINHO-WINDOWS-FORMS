using AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.Situacao;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.FrmLocalPregacao
{
    public partial class FrmCadastroLocalPregacao : Form
    {
        private ConexaoDB conexaoDB;
        private FrmGeralCadastroLocalPregUC frmGeralCadLocalPreg;

        // Controla se o clinte vai incluir um novo Local de pregacao, ou atualizar um existente
        private bool ControleSalvarIncluirLocalPregacao = true;

        public FrmCadastroLocalPregacao()
        {
            InitializeComponent();

            conexaoDB = new ConexaoDB();
            frmGeralCadLocalPreg = new FrmGeralCadastroLocalPregUC();
        }

        private void FrmCadastroLocalPregacao_Load(object sender, EventArgs e)
        {
            frmGeralCadLocalPreg.Dock = DockStyle.Fill;
            TabPage TB = new TabPage();
            TB.Name = "Geral";
            TB.Text = "Geral";
            TB.Controls.Add(frmGeralCadLocalPreg);
            Tbc_Cad_Carrinho.TabPages.Add(TB);
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // Função de incluir no banco o novo carrinho
                if (ControleSalvarIncluirLocalPregacao)
                {
                    // Instancia a class e puxa os dados do formulario
                    LocalPregacao localPregacao = LeituraFormulario();
                    // Valida os dados
                    localPregacao.ValidarClasse();
                    // Tenta incluir os dados no banco de dados
                    localPregacao.IncluirNoBanco(conexaoDB);
                    if (localPregacao.Status)
                    {
                        ControleSalvarIncluirLocalPregacao = true;
                        MessageBox.Show($"OK: {localPregacao.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirLocalPregacao = true;
                        MessageBox.Show($"{localPregacao.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.Close();
                    }
                }
                // Funcao de atualizar carrinho no banco
                else
                {
                    // Instancia a class e puxa os dados do formulario

                    LocalPregacao localPregacao = LeituraFormulario();
                    // Valida os dados
                    localPregacao.ValidarClasse();
                    // Tenta incluir os dados no banco de dados
                    localPregacao.AtualizarNoBanco(conexaoDB);
                    if (localPregacao.Status)
                    {
                        ControleSalvarIncluirLocalPregacao = true;
                        MessageBox.Show($"OK: {localPregacao.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        ControleSalvarIncluirLocalPregacao = true;
                        MessageBox.Show($"{localPregacao.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.Close();
                    }
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        private LocalPregacao LeituraFormulario()
        {
            return new LocalPregacao
            {

                Id = frmGeralCadLocalPreg.ID,
                Nome = frmGeralCadLocalPreg.Nome,
                Descricao = frmGeralCadLocalPreg.Descricao,
                Endereco = frmGeralCadLocalPreg.Endereco,
                Complemento = frmGeralCadLocalPreg.Complemento,
                Bairro = frmGeralCadLocalPreg.Bairro,
                Cidade = frmGeralCadLocalPreg.Cidade,
                UF = frmGeralCadLocalPreg.UF,
                IdSituacao = new Situacao1
                {
                    Id = frmGeralCadLocalPreg.Situacao
                }


            };
        }

        internal void InserirDadosInFrm(int id, string nome, string nomeSituacao, string endereco, string complemento, string bairro, string cidade)
        {
            ControleSalvarIncluirLocalPregacao = false;
            frmGeralCadLocalPreg.InserirDadosInFrm(id, nome, nomeSituacao, endereco, complemento, bairro, cidade);
        }
    }
}
