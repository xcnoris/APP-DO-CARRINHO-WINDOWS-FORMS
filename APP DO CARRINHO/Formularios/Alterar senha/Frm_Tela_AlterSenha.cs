using AppCarrinhoWFBiblioteca.User;
using banco.DAL.DataBases;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APP_DO_CARRINHO.Formularios.Alterar_senha
{
    public partial class Frm_Tela_AlterSenha : Form
    {
        // Propriedades públicas para armazenar os dados do usuário logado
        public string Id_User { get; set; }
        public string Nome_User { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        private ConexaoDB conexaoDB;

        public Frm_Tela_AlterSenha()
        {
            InitializeComponent();

            conexaoDB = new ConexaoDB();
        }

        private void Frm_Tela_AlterSenha_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CarregarDados()
        {
            // Preenche os campos com os dados do usuário logado
            Txt_User.Text = Nome_User;
            
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            // Implementação para confirmar a alteração de senha
            VerificarDados();
        }
        private void VerificarDados()
        {
            try
            {
                string senhaAtualHash = ComandosDB.GetMD5Hasg(Txt_SenhaAtual.Text);
                string senhaNova = Txt_NovaSenha.Text;
                string senhaNovaConfirm = Txt_NovaSenha_Confirm.Text;

                if (senhaAtualHash == Senha)
                {
                    if (senhaNova == senhaNovaConfirm)
                    {
                        AlterarSenha(senhaNovaConfirm);
                    }
                    else
                    {
                        MessageBox.Show("[ERROR]: A nova senha e a confirmação não são iguais.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("[ERROR]: A senha atual não está correta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: Ocorreu um erro ao verificar os dados. Detalhes: {ex.Message}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterarSenha(string novaSenha)
        {
            try
            {
                UserServices userService = new UserServices();
                userService.UpdatePassWordInDB(conexaoDB, Id_User, ComandosDB.GetMD5Hasg(novaSenha));

                if (userService.Status)
                {
                    MessageBox.Show("OK: Senha alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"[ERROR]: {userService.Mensagem}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: Ocorreu um erro ao alterar a senha. Detalhes: {ex.Message}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
