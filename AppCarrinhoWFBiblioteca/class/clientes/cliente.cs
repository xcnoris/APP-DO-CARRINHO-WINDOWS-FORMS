using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AppCarrinhoWFBiblioteca;
using Newtonsoft.Json;

namespace AppCarrinhoWFBiblioteca.clientes
{
    public class Cliente
    {
        public class Unit
        {
            #region Propriedades
            [Required(ErrorMessage ="ID do cliente é obrigatorio!")]
            // Expressão regular para testar numeros
            //[RegularExpression("([0-9]+)", ErrorMessage ="Codigo do cliente aceita somente numericos!")]
            public string ID { get; set; }

           
            [Required(ErrorMessage = "CPF do cliente é obrigatorio!")]
            [RegularExpression("([0-9]+)", ErrorMessage ="Codigo do cliente aceita somente numericos!")]
            [StringLength(11, MinimumLength = 11,ErrorMessage = "CPF do cliente deve ter 11 digitos!")]
            public string CPF { get; set; }

            [Required(ErrorMessage = "Nome do cliente é obrigatorio!")]
            [StringLength(70, ErrorMessage = "Nome do Cliente deve ter no Maximo 70 Caracteres!")]
            public string Nome { get; set; }
            public string CEP { get; set; }
            public string ID_Cidade { get; set; }
            public string Nome_Cidade { get; set; }
            public string UF { get; set; }
            public string Endereco { get; set; }
            public string Endereco_Numero { get; set; }

            [StringLength(70, ErrorMessage = "Complemento do Endereço deve ter no Maximo 70 Caracteres!")]
            public string Endereco_Complemento { get; set; }
            public string Bairro { get; set; }
            public string DDD_Telefone { get; set; }

            [StringLength(9, ErrorMessage = "Numero de Telefone deve ter no Maximo 9 Caracteres!")]
            public string Telefone { get; set; }
            public string DDD_Celular { get; set; }

            [StringLength(9, ErrorMessage = "Numero de Celular deve ter no Maximo 9 Caracteres!")]
            public string Celular { get; set; }
            public string Sexo { get; set; }
            public string DataNascimento { get; set; }
            public string Email { get; set; }
            #endregion

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

                // Valida CPF
                if (!Cls_Uteis.Valida(this.CPF))
                {
                    throw new ValidationException("Cpf Inválido!");
                }
            }
            
        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }

        public static Unit DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Unit>(vJson);
        }
        public static string SerializedClassUnit(Unit unit)
        {
            return JsonConvert.SerializeObject(unit);
        }
    }
}
