using APP_DO_CARRINHO.Formularios.Agendamento;
using APP_DO_CARRINHO.Formularios.Alterar_senha;
using APP_DO_CARRINHO.Formularios.Carrinho;
using APP_DO_CARRINHO.Formularios.Configuração;
using APP_DO_CARRINHO.Formularios.Pessoas;
using APP_DO_CARRINHO.Formularios.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Menu_Principal
{
    public partial class Frm_Menu_Principal_2 : Form
    {
        private string Id_User;
        private string nomeUser;
        private string login;
        private string senha;


        public Frm_Menu_Principal_2()
        {
            InitializeComponent();
        }

        private void Frm_Menu_Principal_2_Load(object sender, EventArgs e)
        {
            OcutarSubMenus();
            this.Hide();
            //Inicialização ou configurações adicionais, se necessário.
            Frm_Tela_Login_V2 frm = new Frm_Tela_Login_V2();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Yes)
            {
                // Define o nome de exibição do usuário logado como sendo o valor que foi informado na tela de login
                Lbl_Nome_User.Text = frm.Nome_User;

                // Armazena os dados do usuário logado
                nomeUser = frm.Nome_User;
                login = frm.Login;
                senha = frm.Senha;
                Id_User = frm.Id_User;

                this.Show();
            }
        }

    

     

        private void ShowSubMenu(Button subMenu)
        {
            if (subMenu.Visible == false)
            {
                //HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnEntidades_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Pnl_Pessoas);
            ShowSubMenu(Btn_User);
        }

        private void btnCadastrarEntidade_Click_1(object sender, EventArgs e)
        {
            Frm_Tela_Pessoas frm = new Frm_Tela_Pessoas();
            frm.Show();
        }

 
        private void button7_Click(object sender, EventArgs e)
        {
            //ShowSubMenu2(Btn_9);
            //Btn_9.Visible = false;
            
        }
        public void OcutarSubMenus()
        {
            Pnl_Pessoas.Visible = false;
            Pnl_Agendamentos.Visible = false;
            Pnl_Carrinhos.Visible = false;
            Btn_Ferramentas.Visible = false;
            Pnl_Configuracoes.Visible = false;
            Btn_User.Visible = false;
        }

        private void Pnl_Carrinho_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Pnl_Carrinhos);
        }

        private void Pnl_Agendamento_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Pnl_Agendamentos);
        }

        private void Pnl_Configuracao_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Pnl_Configuracoes);
        }

        private void Pnl_Carrinhos_Click(object sender, EventArgs e)
        {
            Frm_Tela_Carrinho Frm = new Frm_Tela_Carrinho();
            Frm.Show();
        }

        private void Pnl_Agendamentos_Click(object sender, EventArgs e)
        {
            Frm_Tela_Agendamento frm = new Frm_Tela_Agendamento();
            frm.Show();
        }

        private void Pnl_Configuracoes_Click(object sender, EventArgs e)
        {
            Frm_Tela_Configuracao frm = new Frm_Tela_Configuracao();
            frm.Show();
        }

        private void Btn_User_Click(object sender, EventArgs e)
        {
            Frm_Tela_User frm = new Frm_Tela_User();
            frm.Show();
        }

        private void Btn_Ferramenta_Click(object sender, EventArgs e)
        {
            ShowSubMenu(Btn_Ferramentas);
        }

        private void Btn_Ferramentas_Click(object sender, EventArgs e)
        {
            // Passa os dados do usuário logado para o formulário de alteração de senha
            Frm_Tela_AlterSenha frm = new Frm_Tela_AlterSenha
            {
                Id_User = Convert.ToInt32(Id_User),
                Nome_User = nomeUser,
                Login = login,
                Senha = senha
            };
            frm.Show();
        }
    }
}
