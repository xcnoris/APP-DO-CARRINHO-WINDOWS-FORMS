using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.User;
using AppCarrinhoWFBiblioteca.Users;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace APP_DO_CARRINHO.Formularios
{
    internal class Metodos
    {
        internal string FormatCPF(string cpf)
        {
            if (cpf.Length == 11)
            {
                return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
            }
            return cpf; // Retorna o CPF sem formatação se ele não tiver 11 caracteres
        }

        public void IncluirCamposSituacao(ConexaoDB conexao, ICollection<Situacao> situacoes, ComboBox CboxSituacao)
        {
            try
            {
                if (CboxSituacao == null)
                {
                    throw new ArgumentNullException(nameof(CboxSituacao), "ComboBox CboxSituacao não pode ser nulo.");
                }

                Situacao situacao = new Situacao();

                if (situacao.Status)
                {
                    situacao.ConsultarDisponibilidadeInDB(conexao);

                    if (situacao.Status)
                    {
                        situacoes = Situacao.Situacoes;

                        // Converte o ICollection<Situacao> para uma List<Situacao> para adicionar a opção "Todos"
                        List<Situacao> situacaoList = situacoes.ToList();

                        // Adiciona a opção "Todos"
                        situacaoList.Insert(0, new Situacao { Id = "0", Nome = "Todos" });

                        CboxSituacao.DataSource = situacaoList;
                        CboxSituacao.DisplayMember = "Nome";
                        CboxSituacao.ValueMember = "Id";
                        CboxSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
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


        // -----------------
        public void IncluirCamposTipoUser(ConexaoDB conexao, ICollection<TipoUser> tipos, ComboBox CboxTipoUser)
        {
            try
            {
                if (CboxTipoUser == null)
                {
                    throw new ArgumentNullException(nameof(CboxTipoUser), "ComboBox CboxTipoUser não pode ser nulo.");
                }

                TipoUser tipoUser = new TipoUser();

                if (tipoUser.Status)
                {
                    tipoUser.ConsultarTiposDeUsuarioInDB(conexao);

                    if (tipoUser.Status)
                    {
                        tipos = TipoUser.Tipos;

                        // Converte o ICollection<TipoUser> para uma List<TipoUser> para adicionar a opção "Todos"
                        List<TipoUser> tipoUserList = tipos.ToList();

                        // Adiciona a opção "Todos"
                        tipoUserList.Insert(0, new TipoUser { Id = "0", Nome = "Todos" });

                        CboxTipoUser.DataSource = tipoUserList;
                        CboxTipoUser.DisplayMember = "Nome";
                        CboxTipoUser.ValueMember = "Id";
                        CboxTipoUser.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{tipoUser.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{tipoUser.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal string IncluirValorTipoInDGV(ComboBox Cbox , User1 user)
        {

            // Verifica se o ComboBox tem itens
            if (Cbox.Items.Count > 0)
            {
                // Loop pelos itens do ComboBox
                foreach (var item in Cbox.Items)
                {
                    // Verifica se o item é do tipo TipoUser e se o ID do item coincide com o ID do usuário
                    if (item is TipoUser tipoItem && tipoItem.Id == user.Id_Tipo)
                    {
                        return tipoItem.Nome; // Retorna o nome do tipo de usuário
                    }
                }
            }

            return "null"; // Retorna "null" se não encontrar uma correspondência
        }
        internal string IncluirValorSituacaoInDGV(ComboBox Cbox,string idsituacao)
        {

            // Verifica se o ComboBox tem itens
            if (Cbox.Items.Count > 0)
            {
                // Loop pelos itens do ComboBox
                foreach (var item in Cbox.Items)
                {
                    // Verifica se o item é do tipo Situacao e se o ID do item coincide com o ID da situacao
                    if (item is Situacao situacaoItem && situacaoItem.Id == idsituacao)
                    {
                        return situacaoItem.Nome; // Retorna o nome da situacao
                    }
                }
            }

            return "null"; // Retorna "null" se não encontrar uma correspondência
        }
    }
}

