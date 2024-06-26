using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AppCarrinhoWFBiblioteca;
using Newtonsoft.Json;
using AppCarrinhoWFBiblioteca.carrinho;
using AppCarrinhoWFBiblioteca.carrinho1;
using banco.DataBases;

namespace AppCarrinhoWFBiblioteca.clientes
{
    public class Pessoa
    {

        public bool Status;
        public string Mensagem;

        public Pessoa()
        {
            Status = true;
        }

        public string ID { get; set; }

        [Required(ErrorMessage = "CPF do cliente é obrigatorio!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Codigo do cliente aceita somente numericos!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF do cliente deve ter 11 digitos!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatorio!")]
        [StringLength(70, ErrorMessage = "Nome do Cliente deve ter no Maximo 70 Caracteres!")]
        public string Nome { get; set; }
        [StringLength(10, ErrorMessage = "Cep deve ter no maximo 10 caracteres!")]
        public string CEP { get; set; }
        //public string ID_Cidade { get; set; }
        public string Cidade_Nome { get; set; }
        public string UF { get; set; }
        [StringLength(150, ErrorMessage = "Endereço do Endereço deve ter no Maximo 70 Caracteres!")]
        public string Endereco { get; set; }
        public string Endereco_Numero { get; set; }

        [StringLength(100, ErrorMessage = "Complemento do Endereço deve ter no Maximo 70 Caracteres!")]
        public string Endereco_Complemento { get; set; }
        public string Bairro { get; set; }
        [StringLength(2, ErrorMessage = "DDD do Cliente deve ter no Maximo 2 Caracteres!")]
        public string DDD_Telefone { get; set; }

        [StringLength(9, ErrorMessage = "Numero de Telefone deve ter no Maximo 9 Caracteres!")]
        public string Telefone { get; set; }
        [StringLength(2, ErrorMessage = "DDD do Cliente deve ter no Maximo 2 Caracteres!")]
        public string DDD_Celular { get; set; }

        [StringLength(9, ErrorMessage = "Numero de Celular deve ter no Maximo 9 Caracteres!")]
        public string Celular { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Congregacao_ID { get; set; }
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

        // Metodo de inclusao no banco de dados
        public void IncluirNoBanco(ConexaoDB conexaoDB)
        {
            PessoaService PS = new PessoaService();
            try
            {
                PS.IncluirPessoaInDB(conexaoDB, this);
                if (PS.Status)
                {

                    Status = true;
                    Mensagem = PS.Mensagem;
                }
                else
                {
                    Status = false;
                    Mensagem = PS.Mensagem;
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
            PessoaService PS = new PessoaService();
            try
            {
                PS.AtualizarPessoaInDB(conexaoDB, this);
                if (PS.Status)
                {
                    Status = true;
                    Mensagem = PS.Mensagem;
                }
                else
                {
                    Status = false;
                    Mensagem = PS.Mensagem;
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