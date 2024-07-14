using AppCarrinhoWFBiblioteca;
using AppCarrinhoWFBiblioteca.agendamentos.Categoria_Agendamento;
using AppCarrinhoWFBiblioteca.agendamentos.Situacao;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.classagendamento;
using AppCarrinhoWFBiblioteca.clientes;
using AppCarrinhoWFBiblioteca.User;
using AppCarrinhoWFBiblioteca.Users;
using banco.DataBases;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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

        public void IncluirCamposSituacao(ConexaoDB conexao, ICollection<Situacao> situacoes, ComboBox CboxSituacao, bool incluirTodos = false)
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
                        if (incluirTodos)
                        {
                            // Adiciona a opção "Todos"
                            situacaoList.Insert(0, new Situacao { Id = "0", Nome = "Todos" });
                        }
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

        public void IncluirCamposSituacaoAgendamento(ConexaoDB conexao, ICollection<SituacaoAgendamento> situacoes1, ComboBox CboxSituacao, bool incluirTodos = false)
        {
            try
            {
                if (CboxSituacao == null)
                {
                    throw new ArgumentNullException(nameof(CboxSituacao), "ComboBox CboxSituacao não pode ser nulo.");
                }

                SituacaoAgendamento situacao = new SituacaoAgendamento();

                if (situacao.Status)
                {
                    situacao.ConsultarDisponibilidadeInDB(conexao);

                    if (situacao.Status)
                    {
                        situacoes1 = SituacaoAgendamento.Situacoes;

                        // Converte o ICollection<Situacao> para uma List<Situacao> para adicionar a opção "Todos"
                        List<SituacaoAgendamento> situacaoList = situacoes1.ToList();
                        if (incluirTodos)
                        {
                            // Adiciona a opção "Todos"
                            situacaoList.Insert(0, new SituacaoAgendamento { Id = "0", Nome = "Todos" });
                        }
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

        //internal void IncluirCamposBairro(ConexaoDB conexao, ICollection<Agendameto1> situacoes1, ComboBox CboxSituacao, bool incluirTodos = false)
        //{
        //    try
        //    {
        //        if (CboxSituacao == null)
        //        {
        //            throw new ArgumentNullException(nameof(CboxSituacao), "ComboBox CboxSituacao não pode ser nulo.");
        //        }

        //        Agendameto1 Agendamento = new Agendameto1();

        //        if (Agendamento.Status)
        //        {
        //            Agendamento.Rea(conexao);

        //            if (Agendamento.Status)
        //            {
        //                situacoes1 = SituacaoAgendamento.Situacoes;

        //                // Converte o ICollection<Situacao> para uma List<Situacao> para adicionar a opção "Todos"
        //                List<SituacaoAgendamento> situacaoList = situacoes1.ToList();
        //                if (incluirTodos)
        //                {
        //                    // Adiciona a opção "Todos"
        //                    situacaoList.Insert(0, new SituacaoAgendamento { Id = "0", Nome = "Todos" });
        //                }
        //                CboxSituacao.DataSource = situacaoList;
        //                CboxSituacao.DisplayMember = "Nome";
        //                CboxSituacao.ValueMember = "Id";
        //                CboxSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
        //            }
        //            else
        //            {
        //                MessageBox.Show($"[ERROR]: 1{Agendamento.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show($"[ERROR]: 2{Agendamento.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        public void IncluirCamposCategoriaAgendamento(ConexaoDB conexao, ICollection<CategoriaAgendamento> categorias, ComboBox cboxCategorias, bool incluirTodos = false)
        {
            try
            {
                if (cboxCategorias == null)
                {
                    throw new ArgumentNullException(nameof(cboxCategorias), "ComboBox Cbox_CategoriasAgendamento não pode ser nulo.");
                }

                CategoriaAgendamento categoria = new CategoriaAgendamento();

                if (categoria.Status)
                {
                    categoria.ConsultarCategoriaInDB(conexao);

                    if (categoria.Status)
                    {
                        categorias = CategoriaAgendamento.categorias;

                        // Converte o ICollection<Situacao> para uma List<Situacao> para adicionar a opção "Todos"
                        List<CategoriaAgendamento> categotiaList = categorias.ToList();
                        if (incluirTodos)
                        {
                            // Adiciona a opção "Todos"
                            categotiaList.Insert(0, new CategoriaAgendamento { Id = "0", Nome = "Todos" });
                        }
                        cboxCategorias.DataSource = categotiaList;
                        cboxCategorias.DisplayMember = "Nome";
                        cboxCategorias.ValueMember = "Id";
                        cboxCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{categoria.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{categoria.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void IncluirCamposCarrinho(ConexaoDB conexao, ICollection<Carrinho1> carrinhos, ComboBox CboxCarrinho, bool incluirTodos = false)
        {
            try
            {
                if (CboxCarrinho == null)
                {
                    throw new ArgumentNullException(nameof(CboxCarrinho), "ComboBox Cbox_Carrinho não pode ser nulo.");
                }

                CarrinhoService US = new CarrinhoService();

                if (US.Status)
                {
                    US.ConsultarIdENomeDeCarrinhoInDB(conexao);

                    if (US.Status)
                    {
                        carrinhos = US.Carrinhos;

                        // Converte o ICollection<Situacao> para uma List<Situacao> para adicionar a opção "Todos"
                        List<Carrinho1> carrinhoList = carrinhos.ToList();
                        if (incluirTodos)
                        {
                            // Adiciona a opção "Todos"
                            carrinhoList.Insert(0, new Carrinho1 { ID = "0", Nome = "Todos" });
                        }
                        CboxCarrinho.DataSource = carrinhoList;
                        CboxCarrinho.DisplayMember = "Nome";
                        CboxCarrinho.ValueMember = "Id";
                        CboxCarrinho.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{US.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{US.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        public void IncluirCamposTipoUser(ConexaoDB conexao, ICollection<TipoUser> tipos, ComboBox CboxTipoUser, bool incluirTodos = false)
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
                        if (incluirTodos)
                        {
                            // Adiciona a opção "Todos"
                            tipoUserList.Insert(0, new TipoUser { Id = "0", Nome = "Todos" });
                        }
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


        public ICollection<Pessoa> IncluirValoresPessoasInIcolletion(ConexaoDB conexao, ICollection<Pessoa> pessoas)
        {
            try
            {

                PessoaService PS = new PessoaService();

                if (PS.Status)
                {
                    PS.ReadNomeAndIDInDB(conexao);

                    if (PS.Status)
                    {
                        return PS.Pessoas;
                    }
                    else
                    {
                        MessageBox.Show($"[ERROR]: 1{PS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return pessoas;
                    }
                }
                else
                {
                    MessageBox.Show($"[ERROR]: 2{PS.Mensagem}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return pessoas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[ERROR]:3 {ex.Message}", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pessoas; 
            }
        }


        // Metodos de incluir nomes nos DGV
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
        internal string IncluirValorSituacaoAgendamentoInDGV(ComboBox Cbox, string idsituacao)
        {

            // Verifica se o ComboBox tem itens
            if (Cbox.Items.Count > 0)
            {
                // Loop pelos itens do ComboBox
                foreach (var item in Cbox.Items)
                {
                    // Verifica se o item é do tipo Situacao e se o ID do item coincide com o ID da situacao
                    if (item is SituacaoAgendamento situacaoItem && situacaoItem.Id == idsituacao)
                    {
                        return situacaoItem.Nome; // Retorna o nome da situacao
                    }
                }
            }

            return "null"; // Retorna "null" se não encontrar uma correspondência
        }

        internal string IncluirValorCategoriInDGV(ComboBox Cbox, string idCategoria)
        {

            // Verifica se o ComboBox tem itens
            if (Cbox.Items.Count > 0)
            {
                // Loop pelos itens do ComboBox
                foreach (var item in Cbox.Items)
                {
                    // Verifica se o item é do tipo Situacao e se o ID do item coincide com o ID da situacao
                    if (item is CategoriaAgendamento categoriaItem && categoriaItem.Id == idCategoria)
                    {
                        return categoriaItem.Nome; // Retorna o nome da situacao
                    }
                }
            }

            return "null"; // Retorna "null" se não encontrar uma correspondência
        }
        
        internal string IncluirValorCarrinhoInDGV(ComboBox Cbox, string codCarrinho)
        {

            // Verifica se o ComboBox tem itens
            if (Cbox.Items.Count > 0)
            {
                // Loop pelos itens do ComboBox
                foreach (var item in Cbox.Items)
                {
                    // Verifica se o item é do tipo Situacao e se o ID do item coincide com o ID da situacao
                    if (item is Carrinho1 carrinhoItem && carrinhoItem.Codigo_Carrinho == codCarrinho)
                    {
                        return carrinhoItem.Nome; // Retorna o nome da situacao
                    }
                }
            }

            return "null"; // Retorna "null" se não encontrar uma correspondência
        }

        internal string IncluirValorPessoaInDGV(ICollection<Pessoa> pessoas, string idPessoa)
        {

            // Verifica se o ComboBox tem itens
            if (pessoas.Count > 0)
            {
                // Loop pelos itens do ComboBox
                foreach (var item in pessoas)
                {
                    // Verifica se o item é do tipo Situacao e se o ID do item coincide com o ID da situacao
                    if (item is Pessoa pessoa && pessoa.ID == idPessoa)
                    {
                        string idANDNome = $"{pessoa.ID} - {pessoa.Nome}";
                        return idANDNome; // Retorna o nome da situacao
                    }
                }
            }

            return "null"; // Retorna "null" se não encontrar uma correspondência
        }


    }
}

