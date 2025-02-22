
using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace APP_DO_CARRINHO.Formularios.FrmLocalPregacao
{
    public partial class FrmLocalPregacao : Form
    {
        private Metodos metodos;

        //private ICollection<AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao> RetornoBairros = new List<AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao>();
        //public ICollection<Situacao> RetornoSituacoes = new List<Situacao>();


        public FrmLocalPregacao()
        {
            InitializeComponent();


            metodos = new Metodos();

            AddColumnDataGridView();

        }

        //private void FrmLocalPregacao_Load(object sender, EventArgs e)
        ////{
        ////    metodos.IncluirCamposBairro(conexaoDB, RetornoBairros, Cbox_Bairros, true);
        ////    metodos.IncluirCamposSituacao(conexaoDB, RetornoSituacoes, Cbox_Situacao, true);

        //    //CarregarTodosLocaisPregracao();
        //}



        //private void CarregarTodosLocaisPregracao()
        //{

        //    try
        //    {
        //        DGV_Dados.Rows.Clear();

        //        LocalPregracaoServices LPS = new LocalPregracaoServices();

        //        if (LPS.Status)
        //        {
        //            LPS.ReadAllInDB(conexaoDB);

        //            if (LPS.Status)
        //            {
        //                // Pecorre a lista
        //                foreach (AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao localPregacao in LPS.LocaisPregracao)
        //                {

        //                    AddLocalPregacaoToDataGridView(localPregacao);
        //                }
        //                RetornoBairros = LPS.LocaisPregracao ;
        //            }
        //            else
        //            {
        //                MessageBox.Show($"[ERROR]: 1{LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show($"[ERROR]: 2{LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        // Recebe um object LocalPregacao e convert para uma linha do DataGridView
        //private void AddLocalPregacaoToDataGridView(AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1.LocalPregacao localPregacao)
        //{
        //    try
        //    {
        //        AddColumnDataGridView();

        //        string situacaoNome = metodos.IncluirValorSituacaoInDGV(Cbox_Situacao, localPregacao.IdSituacao.Id);
                
        //        // Adicionar linha ao DataGridView
        //        DGV_Dados.Rows.Add(
        //            localPregacao.Id,
        //            localPregacao.Nome,
        //            localPregacao.Endereco,
        //            localPregacao.Bairro,
        //            localPregacao.Cidade,
        //            localPregacao.UF,
        //            situacaoNome
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void AddColumnDataGridView()
        {
            try
            {
                // Se o DataGridView não tiver colunas, adicione-as
                if (DGV_Dados.Columns.Count == 0)
                {
                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns.Add("nome", "Nome");
                    DGV_Dados.Columns.Add("endereco", "Endereço");
                    DGV_Dados.Columns.Add("bairro", "Bairro");
                    DGV_Dados.Columns.Add("cidade", "Cidade");
                    DGV_Dados.Columns.Add("uf", "UF");
                    DGV_Dados.Columns.Add("situacao", "Situação");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Filtrar_Click(object sender, EventArgs e)
        {
            try
            {

                int IndexDoBairro = Cbox_Bairros.SelectedIndex;
                string ID = Txt_Id.Text;
                string nome = Txt_Nome.Text;
                int IndexSituacao = Cbox_Situacao.SelectedIndex;

                // Se nao tiver nenhum filtro selecionado. Puxa todos os Locais de pregação
                if (IndexDoBairro == 0 && IndexSituacao == 0 && string.IsNullOrWhiteSpace(ID.ToString()) && string.IsNullOrWhiteSpace(nome))
                {
                    try
                    {
                        DGV_Dados.Rows.Clear();
                        //CarregarTodosLocaisPregracao();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        DGV_Dados.Rows.Clear();

                        //LocalPregracaoServices LPS = new LocalPregracaoServices();

                        //if (LPS.Status)
                        //{
                        //    if (!string.IsNullOrEmpty(ID))
                        //    {
                        //        LPS.ReadInDB(conexaoDB, Convert.ToInt32(ID));
                        //    }
                        //    else if (IndexSituacao > 0)
                        //    {
                        //        if (IndexDoBairro == 0 && string.IsNullOrWhiteSpace(ID.ToString()) && string.IsNullOrWhiteSpace(nome))
                        //        {
                        //            LPS.ReadInDB(conexaoDB, Convert.ToInt32(ID));

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show($"Registro não encontrado na base de dados", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //    }
                        //    foreach (LocalPregacao localPregacao in LPS.LocaisPregracao)
                        //    {
                        //        AddLocalPregacaoToDataGridView(localPregacao);
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show($"[ERROR]: {LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Incluir_Pessoas_Click(object sender, EventArgs e)
        {
            FrmCadastroLocalPregacao frm = new FrmCadastroLocalPregacao();
            frm.ShowDialog();
        }

        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string nome = selectedRow.Cells["nome"].Value.ToString();
                string endereco = selectedRow.Cells["endereco"].Value.ToString();
                string bairro = selectedRow.Cells["bairro"].Value.ToString();
                string cidade = selectedRow.Cells["cidade"].Value.ToString();
                string uf = selectedRow.Cells["uf"].Value.ToString();
                string situacao = selectedRow.Cells["situacao"].Value.ToString();
                string complemento = "";

                // Pass the data to the Frm_Cadastro_Carrinho_UC form
                FrmCadastroLocalPregacao frm = new FrmCadastroLocalPregacao();
                frm.InserirDadosInFrm(id, nome, situacao, endereco, complemento, bairro, cidade);
                frm.ShowDialog();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Alterar_Pessoas_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the selected row data
                var selectedRow = DGV_Dados.CurrentRow;
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string nome = selectedRow.Cells["nome"].Value.ToString();
                string endereco = selectedRow.Cells["endereco"].Value.ToString();
                string bairro = selectedRow.Cells["bairro"].Value.ToString();
                string cidade = selectedRow.Cells["cidade"].Value.ToString();
                string uf = selectedRow.Cells["uf"].Value.ToString();
                string situacao = selectedRow.Cells["situacao"].Value.ToString();
                string complemento = "";

                // Pass the data to the Frm_Cadastro_Carrinho_UC form
                FrmCadastroLocalPregacao frm = new FrmCadastroLocalPregacao();
                frm.InserirDadosInFrm(id, nome, situacao, endereco, complemento, bairro, cidade);
                frm.ShowDialog();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Excluir_LocalPregacao_Click(object sender, EventArgs e)
        {

            try
            {
                //var resposta = MessageBox.Show("Você Realmente quer excluir o local de pregação selecionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (resposta == DialogResult.Yes)
                //{
                //    //LocalPregracaoServices LPS = new LocalPregracaoServices();
                //    var selectedRow = DGV_Dados.CurrentRow;
                //    int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                //    LPS.DeleteInDB(conexaoDB, id);

                //    if (LPS.Status)
                //    {
                //        MessageBox.Show($"OK: {LPS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        CarregarTodosLocaisPregracao();
                //    }
                //    else
                //    {
                //        MessageBox.Show($"{LPS.Mensagem}!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"[ERROR]: {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
