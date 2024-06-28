using APP_DO_CARRINHO.Formularios.Agendamento;
using APP_DO_CARRINHO.Formularios.Carrinho;
using APP_DO_CARRINHO.Formularios.Configuração;
using APP_DO_CARRINHO.Formularios.Pessoas;
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
                // Define o nome de exibicao do usuario logado como sendo o valor que foi informado na tela de login
                Lbl_Nome_User.Text = frm.NomeUser; 

                this.Show();
            }
        }

    

        private void HideSubMenu()
        {
            if (panelEntidadesSubMenu.Visible == true)
                panelEntidadesSubMenu.Visible = false;
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
            
        }

        // Adicione manipuladores de eventos para seus botões de submenu aqui, se necessário.
        private void btnCadastrarEntidade_Click(object sender, EventArgs e)
        {
            // Código para lidar com o clique no botão "Cadastrar Entidade"
            HideSubMenu();
        }

        private void btnAlterarEntidade_Click(object sender, EventArgs e)
        {
            // Código para lidar com o clique no botão "Alterar Entidade"
            HideSubMenu();
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
            Pnl_Configuracoes.Visible = false;
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
    }
}
