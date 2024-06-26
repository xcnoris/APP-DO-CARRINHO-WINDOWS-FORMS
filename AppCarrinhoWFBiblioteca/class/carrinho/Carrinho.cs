using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AppCarrinhoWFBiblioteca.carrinho;
using banco.DataBases;
using banco.DAL.DataBases;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppCarrinhoWFBiblioteca.carrinho1
{
    public class Carrinho1
    {

        public bool Status;
        public string Mensagem;
        public string ID { get; set; }

        [Required(ErrorMessage = "Nome do Carrinho é Obrigatorio!")]
        [StringLength(30, ErrorMessage = "Nome do Carrinho Deve ter no Maximo 30 Caracteres!")]
        public string Nome { get; set; }
        public string Congregacao_ID { get; set; }
        public string Congregacao_Nome { get; set; }

        [Required(ErrorMessage = "Situação do Carrinho é Obrigatorio!")]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "Codigo do Carrinho é obrigatorio!")]
        public string Codigo_Carrinho { get; set; }

        public Carrinho1()
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
    

        // Metodo de inclusao no banco de dados
        public void IncluirNoBanco(ConexaoDB conexaoDB)
        {
            CarrinhoService CS = new CarrinhoService();
            try
            {
                CS.IncluirCarrinhoInDB(conexaoDB, this);
                if (CS.Status)
                {
                    
                    Status = true;
                    Mensagem = CS.Mensagem;
                }
                else
                {
                    Status = false;
                    Mensagem = CS.Mensagem;
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
            CarrinhoService CS = new CarrinhoService();
            try
            {
                CS.AtualizarCarrinhoInDB(conexaoDB, this);
                if (CS.Status)
                {
                    Status = true;
                    Mensagem = CS.Mensagem;
                }
                else
                {
                    Status = false;
                    Mensagem = CS.Mensagem;
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
