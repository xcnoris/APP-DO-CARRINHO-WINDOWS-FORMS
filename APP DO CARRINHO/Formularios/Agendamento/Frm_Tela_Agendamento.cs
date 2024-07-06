using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Agendamento
{
    public partial class Frm_Tela_Agendamento : Form
    {
        public Frm_Tela_Agendamento()
        {
            InitializeComponent();
            
            AjustarFiltro();

            DTP_Hora1.Enabled = false;
            DTP_Hora2.Enabled = false;


        }

        private void Frm_Tela_Agendamento_Load(object sender, EventArgs e)
        {

        }

        private void AjustarFiltro()
        {
            DTP_Hora1.Format = DateTimePickerFormat.Custom;
            DTP_Hora1.CustomFormat = "HH:mm"; // Formato para hora e minutos (24 horas)
            DTP_Hora1.ShowUpDown = true; // Exibe um controle tipo "up-down" para seleção de hora/minutos


            DTP_Hora2.Format = DateTimePickerFormat.Custom;
            DTP_Hora2.CustomFormat = "HH:mm"; // Formato para hora e minutos (24 horas)
            DTP_Hora2.ShowUpDown = true; // Exibe um controle tipo "up-down" para seleção de hora/minutos

            DTP_Data1.Format = DateTimePickerFormat.Custom;
            DTP_Data1.CustomFormat = "dd/MM/yyyy";

            DTP_Data2.Format = DateTimePickerFormat.Custom;
            DTP_Data2.CustomFormat = "dd/MM/yyyy";

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica o estado do CheckBox
            if (ChBox_FiltrarPorHora.Checked)
            {
                DTP_Hora1.Enabled = true;
                DTP_Hora2.Enabled = true;
            }
            else
            {
                DTP_Hora1.Enabled = false;
                DTP_Hora2.Enabled = false;
               
            }
        }
    }
}
