using AppCarrinhoWFBiblioteca;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios
{
    internal class Metodos
    {

       
        public void IncluirCamposSituacao(ConexaoDB conexao, ICollection<Situacao> situacoes, ComboBox CboxSituacao)
        {
            try
            {

                Situacao situacao = new Situacao();

                if (situacao.Status)
                {
                    situacao.ConsultarDisponibilidadeInDB(conexao);

                    if (situacao.Status)
                    {
                        situacoes = Situacao.Situacoes;

                        // Convert the ICollection<Situacao> to a List<Situacao> to add the "Todos" option
                        List<Situacao> situacaoList = situacoes.ToList();

                        // Add the "Todos" option
                        situacaoList.Insert(0, new Situacao { Id = "0", Nome = "Todos" });

                        CboxSituacao.DataSource = situacaoList;
                        CboxSituacao.DisplayMember = "Nome";
                        CboxSituacao.ValueMember = "Id";
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{situacao.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{situacao.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
