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
    public partial class Frm_Geral_AgendamentoUC : UserControl
    {
        public Frm_Geral_AgendamentoUC()
        {
            InitializeComponent();

            AjustarFiltro();
        }

        private void Frm_Geral_AgendamentoUC_Load(object sender, EventArgs e)
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

            DTP_Data.Format = DateTimePickerFormat.Custom;
            DTP_Data.CustomFormat = "dd/MM/yyyy";

        }
    }
}
