
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace APP_DO_CARRINHO.Formularios.Agendamento
{
    public partial class Frm_Geral_AgendamentoUC : UserControl
    {
        private Metodos metodos;

        //private ICollection<SituacaoAgendamento> RetornoSituacoes = new List<SituacaoAgendamento>();
        //private ICollection<CategoriaAgendamento> RetornoCategorias = new List<CategoriaAgendamento>();
        //private ICollection<Carrinho1> RetornoCarrinhos = new List<Carrinho1>();
        //private ICollection<Pessoa> RetornoPessoas = new List<Pessoa>();

        public string IdAgendamento
        {
            get { return Txt_ID.Text; }
        }

        public string CategoriaAgendamento
        {
            get
            {
                if (Cbox_CategoriaAgendamento.SelectedIndex < 0)
                {
                    return "";
                }
                else
                {
                    int index = Cbox_CategoriaAgendamento.SelectedIndex + 1;
                    return index.ToString();
                }
            }
        }

        public string SituacaoAgendamento
        {
            get
            {
                if (Cbox_Situacao.SelectedIndex < 0)
                {
                    return "";
                }
                else
                {
                    int index = Cbox_Situacao.SelectedIndex + 1;
                    return index.ToString();
                }
            }
        }

        public DateTime DataAgendamento
        {
            get { return DTP_Data.Value; }
        }

        public TimeSpan HoraInicio
        {
            get { return DTP_Hora1.Value.TimeOfDay; }
        }

        public TimeSpan HoraFim
        {
            get { return DTP_Hora2.Value.TimeOfDay; }
        }

        public string IdCarrinho
        {
            get
            {
                if (Cbox_Carrinhos.SelectedIndex < 0)
                {
                    return "";
                }
                else
                {
                    int index = Cbox_Carrinhos.SelectedIndex + 1;
                    return index.ToString();
                }
            }
        }

        public string IdPessoa
        {
            get { return Txt_IdPessoa.Text; }
        }

        public string PessoaNome
        {
            get { return Txt_NomePessoa.Text; }
        }
        public string Email
        {
            get { return Txt_EmailPessoa.Text; }
        }
        public string Endereco
        {
            get { return Txt_EnderecoPessoa.Text; }
        }
        public string Complemento
        {
            get { return Txt_Endereco_Complemento.Text; }
        }
        public string Bairro
        {
            get { return Txt_Endereco_Bairro.Text; }
        }
        public string DDD_Telefone
        {
            get { return Txt_DDD_Telefone.Text; }
        }
        public string Numero_Telefone
        {
            get { return Txt_Telefone.Text; }
        }
        public string DDD_Celular
        {
            get { return Txt_DDD_Celular.Text; }
        }
        public string Numero_Celular
        {
            get { return Txt_Celular.Text; }
        }



        public Frm_Geral_AgendamentoUC()
        {
            //InitializeComponent();

            //conexaoDB = new ConexaoDB();
            //metodos = new Metodos();

            //// Metodos para incluir valores nos combo box dos filtros, passamos o ultimo valor como true para incluir a opção "Todos"
            //metodos.IncluirCamposSituacaoAgendamento(conexaoDB, RetornoSituacoes, Cbox_Situacao);
            //metodos.IncluirCamposCategoriaAgendamento(conexaoDB, RetornoCategorias, Cbox_CategoriaAgendamento);
            //metodos.IncluirCamposCarrinho(conexaoDB, RetornoCarrinhos, Cbox_Carrinhos);
            //RetornoPessoas = metodos.IncluirValoresPessoasInIcolletion(conexaoDB, RetornoPessoas);

            //AjustarFiltro();
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


        // Função para inserir dados quando é dado um duplo clique em um data grid view
        public void SetAgendamentoGeralData(string id, string categoriaAgendamento, string situacaoAgendamento, DateTime dataAgendamento, TimeSpan horaInicio, TimeSpan horaFim, string codCarrinho, string idPessoa, string nomePessoa, string email, string endereco, string complemento, string bairro, string dddTelefone, string numeroTelefone, string dddCelular, string numeroCelular)
        {
            Txt_ID.Text = id;

            // Configurar o valor do ComboBox de CategoriaAgendamento
            foreach (var item in Cbox_CategoriaAgendamento.Items)
            {
                //if (item is CategoriaAgendamento categoriaItem && categoriaItem.Nome == categoriaAgendamento)
                //{
                //    Cbox_CategoriaAgendamento.SelectedItem = item;
                //    break;
                //}
            }

            // Configurar o valor do ComboBox de Situação
            foreach (var item in Cbox_Situacao.Items)
            {
                //if (item is SituacaoAgendamento situacaoItem && situacaoItem.Nome == situacaoAgendamento)
                //{
                //    Cbox_Situacao.SelectedItem = item;
                //    break;
                //}
            }

            DTP_Data.Value = dataAgendamento;
            DTP_Hora1.Value = DateTime.Today.Add(horaInicio);
            DTP_Hora2.Value = DateTime.Today.Add(horaFim);

            // Configurar o valor do ComboBox de Carrinho
            foreach (var item in Cbox_Carrinhos.Items)
            {
                //if (item is Carrinho1 carrinhoItem && carrinhoItem.Codigo_Carrinho == codCarrinho)
                //{
                //    Cbox_Carrinhos.SelectedItem = item;
                //    break;
                //}
            }

            Txt_IdPessoa.Text = idPessoa;
            Txt_NomePessoa.Text = nomePessoa;
            Txt_EmailPessoa.Text = email;
            Txt_EnderecoPessoa.Text = endereco;
            Txt_Endereco_Complemento.Text = complemento;
            Txt_Endereco_Bairro.Text = bairro;
            Txt_DDD_Telefone.Text = dddTelefone;
            Txt_Telefone.Text = numeroTelefone;
            Txt_DDD_Celular.Text = dddCelular;
            Txt_Celular.Text = numeroCelular;
        }



    }
}
