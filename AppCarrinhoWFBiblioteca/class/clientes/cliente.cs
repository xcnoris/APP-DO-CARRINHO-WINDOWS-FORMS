using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppCarrinhoWFBiblioteca.clientes
{
    public class Cliente
    {
        public class Unit
        {
            [Required(ErrorMessage ="ID do cliente é obrigatorio!")]
            // Expressão regular para testar numeros
            [RegularExpression("([0-9]+)", ErrorMessage ="Codigo do cliente aceita somente numericos!")]
            [StringLength(12, MinimumLength = 2, ErrorMessage ="Codigo do cliente deve ter 2 digitos no minimo")]
            public string ID { get; set; }
            public string CPF { get; set; }
            [Required(ErrorMessage = "Nome do cliente é obrigatorio!")]
            public string Nome { get; set; }
            public string CEP { get; set; }
            public int ID_Cidade { get; set; }
            public string Nome_Cidade { get; set; }
            public string UF { get; set; }
            public string Endereco { get; set; }
            public string Endereco_Numero { get; set; }
            public string Endereco_Complemento { get; set; }
            public string Bairro { get; set; }
            public int DDD_Telefone { get; set; }
            public int Telefone { get; set; }
            public int DDD_Celular { get; set; }
            public int Celular { get; set; }
            [Required(ErrorMessage = "Nome do cliente é obrigatorio!")]
            public int Sexo { get; set; }
            public string DataNascimento { get; set; }
            public string Email { get; set; }

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


        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }
    }
}
