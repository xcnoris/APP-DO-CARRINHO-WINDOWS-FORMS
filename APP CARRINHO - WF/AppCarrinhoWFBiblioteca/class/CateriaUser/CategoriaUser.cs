
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using AppCarrinhoWFBiblioteca.Users;

namespace AppCarrinhoWFBiblioteca.CateriaUser
{
    public class CategoriaUser
    {

        ICollection<User1> usuarios = new List<User1>();

        public bool Status;
        public string Mensagem;

        public CategoriaUser()
        {
            Status = true;
        }


        public int Id { get; set; }


        [Required(ErrorMessage = "CPF do cliente é obrigatorio!")]
        [StringLength(100, MinimumLength = 11, ErrorMessage = "CPF do cliente deve ter 11 digitos!")]
        public string Nome { get; set; }


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
        }
    }
}
