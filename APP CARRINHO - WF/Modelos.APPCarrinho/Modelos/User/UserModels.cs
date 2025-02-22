using System.Text;
using System.ComponentModel.DataAnnotations;
using Modelos.APPCarrinho.Enuns;

namespace Modelos.APPCarrinho.Class.User
{
    public class UserModels 
    {
        public bool Status;
        public string Mensagem;

        public UserModels()
        {
            Status = true;
        }


        public string Id { get; set; }

        [Required(ErrorMessage = "CPF do cliente é obrigatorio!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Codigo do cliente aceita somente numericos!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF do cliente deve ter 11 digitos!")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "Nome do cliente é obrigatorio!")]
        [StringLength(200, ErrorMessage = "Nome do Cliente deve ter no Maximo 70 Caracteres!")]
        public string Nome { get; set; }


        //[Required(ErrorMessage = "Tipo de documentp é obrigatorio!")]
        public TipoUser TipoUserId { get; set; }


        [Required(ErrorMessage = "Login do cliente é obrigatorio!")]
        public string Login { get; set; }


        //[Required(ErrorMessage = "Cliente é obrigatorio!")]
        public string Senha { get; set; }

        public SituacaoModels SituacaoId { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }


        public void ValidarClass()
        {
            // Captura os results dos testes de validação dos campos
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            // retorna um false caso algum dos teste de problema
            bool isValid = Validator.TryValidateObject(this, context, results, true);
            // se retorna false, ele entra no loop
            if (!isValid)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    // Adiciona no string(stringBuilder) todos os erros 
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                // Add as mensagens de erro para um exeção do tipo 
                // E força a mensagem da exceção
                throw new ValidationException(sbrErrors.ToString());
            }
            // Valida CPF
            if (!Cls_Uteis.Valida(this.CPF))
            {
                throw new ValidationException("Cpf Inválido!");
            }
        }

    }
}
