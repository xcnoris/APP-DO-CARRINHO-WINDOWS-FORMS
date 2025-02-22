using APP_DO_CARRINHO.Formularios.Tela_Login;
using System;
using System.Linq;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Menu_Principal
{
    public partial class Frm_Tela_Login_V2 : Form
    {
        public bool Status { get; set; }
        public string Id_User {  get; set; }
        public string Nome_User { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }


        public Frm_Tela_Login_V2()
        {
            InitializeComponent();

        }

        private void Btn_Acessar_Click(object sender, EventArgs e)
        {
            VerificarLogin();

            if (Status == true)
            {
                DialogResult = DialogResult.Yes;
                this.Hide();
            }
       
        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Conexoes_Click(object sender, EventArgs e)
        {
            Frm_Tela_ConexoesDB frm = new Frm_Tela_ConexoesDB();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Lbl_Senha_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VerificarLogin()
        {
            try
            {
                string loginUser = Txt_LoginUser.Text.Trim().ToLower();
                //string senha = ComandosDB.GetMD5Hasg(Txt_Senha.Text);

                //UserServices US = new UserServices();
                //US.BuscarPorNomeESenha(conexaoDB, loginUser, senha);

                //if (US.Status && US.usuarios.Count > 0)
                //{
                //    // Usuário encontrado, prossiga com o login
                //    foreach (var user in US.usuarios)
                //    {
                //        Id_User = user.Id;
                //        Nome_User = user.Nome;
                //        Login = user.Login;
                //        Senha = user.Senha;
                //    }
                //    Status = true;
                   
                //    // Continue o fluxo de login...
                //}
                //else
                //{
                //    MessageBox.Show("Usuário ou senha invalidos.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Status = false;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Status = false;
            }
        }

    }
}
