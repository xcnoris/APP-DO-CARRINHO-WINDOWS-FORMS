using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.clientes
{
    class cliente
    {
        public class Unit
        {
            public int ID { get; set; }
            public string CPF { get; set; }
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
            public int Sexo { get; set; }
            public string DataNascimento { get; set; }
            public string Email { get; set; }
        }

        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }
    }
}
