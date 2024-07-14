using AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1;
using AppCarrinhoWFBiblioteca.carrinho;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Text;

namespace AppCarrinhoWFBiblioteca.classagendamento
{ 
    public class Agendameto1
    {
        public bool Status;
        public string Mensagem;


        public string Id { get; set; }

        [Required(ErrorMessage = "Situação do Agendamento é Obrigatorio!")]
        public string IdSituacao { get; set; }
        [Required(ErrorMessage = "Categoria do Agendamento é Obrigatorio!")]
        public string IdCategoria { get; set; }
        [Required(ErrorMessage = "Pessoa do Agendamento é Obrigatorio!")]
        public string IdPessoa { get; set; }
        [Required(ErrorMessage = "Carrinho do Agendamento é Obrigatorio!")]
        public string CodCarrinho { get; set; }
        [Required(ErrorMessage = "Dia da semana do Agendamento é Obrigatorio!")]
        public DateTime DataAgendamento { get; set; }
        [Required(ErrorMessage = "Hora do Agendamento é Obrigatorio!")]
        public TimeSpan Hora1 { get; set; }
        [Required(ErrorMessage = "hora até do Agendamento é Obrigatorio!")]
        public TimeSpan Hora2 { get; set; }
        [Required(ErrorMessage = "Local do Agendamento é Obrigatorio!")]
        public LocalPregracao Local { get; set; }
        
        public DateTime DataCriacao { get; set; }


        public Agendameto1()
        {
            Status = true;
        }


        public void ValidarClasse()
        {
            // Captura os results dos testes de validação dos campos
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            // retorna um false caso algum dos teste de problema
            bool isValid = Validator.TryValidateObject(this, context, results, true);
            // se retorna false, ele entra no loop
            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    // Adiciona no string(stringBuilder) todos os erros retornados das validaçoes
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                // Add as mensagens de erro para um exeção do tipo validationexception.
                // E força a mensagem da exceção
                throw new ValidationException(sbrErrors.ToString());
            }
            if (this.IdSituacao == "0")
            {
                throw new ValidationException("Situação não pode ser todas!");
            }

        }



        // Metodo de inclusao no banco de dados
        public void IncluirNoBanco(ConexaoDB conexaoDB)
        {
            //CarrinhoService CS = new CarrinhoService();
            //try
            //{
            //    CS.CreateInDB(conexaoDB, this);
            //    if (CS.Status)
            //    {

            //        Status = true;
            //        Mensagem = CS.Mensagem;
            //    }
            //    else
            //    {
            //        Status = false;
            //        Mensagem = CS.Mensagem;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Status = false;
            //    Mensagem = ex.Message;
            //}
        }

        // Metodo de Atualização no banco de dados
        public void AtualizarNoBanco(ConexaoDB conexaoDB)
        {
            //CarrinhoService CS = new CarrinhoService();
            //try
            //{
            //    CS.UpdateInDB(conexaoDB, this);
            //    if (CS.Status)
            //    {
            //        Status = true;
            //        Mensagem = CS.Mensagem;
            //    }
            //    else
            //    {
            //        Status = false;
            //        Mensagem = CS.Mensagem;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Status = false;
            //    Mensagem = ex.Message;
            //}
        }
    }
}
