
using System;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Alterar_senha
{
    public partial class Frm_Tela_AlterSenha : Form
    {
        // Propriedades públicas para armazenar os dados do usuário logado
        public int Id_User { get; set; }
        public string Nome_User { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }


        public Frm_Tela_AlterSenha()
        {
            InitializeComponent();

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
                if (string.IsNullOrWhiteSpace(Txt_SenhaAtual.Text))
                {
                    MessageBox.Show("[ERROR]: Senha atual não digitada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //string senhaAtualHash = ComandosDB.GetMD5Hasg(Txt_SenhaAtual.Text); // Correção do método GetMD5Hash
                string senhaNova = Txt_NovaSenha.Text;
                string senhaNovaConfirm = Txt_NovaSenha_Confirm.Text;

                //if (senhaAtualHash != Senha)
                //{
                //    MessageBox.Show("[ERROR]: Senha atual errada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (string.IsNullOrWhiteSpace(senhaNova) || string.IsNullOrWhiteSpace(senhaNovaConfirm))
                {
                    MessageBox.Show("[ERROR]: A nova senha ou a confirmação não foram digitadas.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (senhaNova != senhaNovaConfirm)
                {
                    MessageBox.Show("[ERROR]: A nova senha e a confirmação não são iguais.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AlterarSenha(senhaNovaConfirm);
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
                //UserServices US = new UserServices();
                //US.UpdatePassWordInDB(conexaoDB, Id_User, ComandosDB.GetMD5Hasg(novaSenha));

                //if (US.Status)
                //{
                //    MessageBox.Show("OK: Senha alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show($"[ERROR]: {US.Mensagem}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: Ocorreu um erro ao alterar a senha. Detalhes: {ex.Message}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
