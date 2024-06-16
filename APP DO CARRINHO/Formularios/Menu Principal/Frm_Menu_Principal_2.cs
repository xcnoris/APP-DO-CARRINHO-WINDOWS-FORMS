using APP_DO_CARRINHO.Formularios.Carrinho;
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
            CustomizeDesign(); // Certifique-se de que os submenus estão ocultos ao iniciar o formulário
        }

        private void Frm_Menu_Principal_2_Load(object sender, EventArgs e)
        {

            // Inicialização ou configurações adicionais, se necessário.
            Frm_Tela_Login_Registro frm = new Frm_Tela_Login_Registro();
            frm.ShowDialog();
        }

        private void CustomizeDesign()
        {
            panelEntidadesSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelEntidadesSubMenu.Visible == true)
                panelEntidadesSubMenu.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnEntidades_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelEntidadesSubMenu);
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
    }
}
