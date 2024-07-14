using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace AppCarrinhoWFBiblioteca.agendamentos.LocalPregracao1
{
    public class LocalPregracao
    {
        public bool Status;
        public string Mensagem;



        public string Id { get; set; }

        [Required(ErrorMessage = "Nome do Local de pregação é Obrigatorio!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Endereço é Obrigatorio!")]
        public string Endereco { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é Obrigatorio!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é Obrigatoria!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF é Obrigatoria!")]
        public string UF { get; set; }


        public LocalPregracao()
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
        }


        public void IncluirNoBanco(ConexaoDB conexaoDB)
        {
            LocalPregracaoServices LPS = new LocalPregracaoServices();
            try
            {
                LPS.CreateInDB(conexaoDB, this);
                if (LPS.Status)
                {

                    Status = true;
                    Mensagem = LPS.Mensagem;
                }
                else
                {
                    Status = false;
                    Mensagem = LPS.Mensagem;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = ex.Message;
            }
        }

        // Metodo de Atualização no banco de dados
        public void AtualizarNoBanco(ConexaoDB conexaoDB)
        {
            LocalPregracaoServices LPS = new LocalPregracaoServices();
            try
            {
                LPS.UpdateInDB(conexaoDB, this);
                if (LPS.Status)
                {
                    Status = true;
                    Mensagem = LPS.Mensagem;
                }
                else
                {
                    Status = false;
                    Mensagem = LPS.Mensagem;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = ex.Message;
            }

        }
    }
}
