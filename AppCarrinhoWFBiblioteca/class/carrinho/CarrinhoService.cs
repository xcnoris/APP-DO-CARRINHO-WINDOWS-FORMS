using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.clientes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.carrinho
{
    public class CarrinhoService
    {

        public ICollection<Carrinho1> Carrinhos { get; set; } = new List<Carrinho1>();
  
        public void AdicionarCarrinho(Carrinho1 carrinho)
        {
            carrinho.ValidarClasse();
            Carrinhos.Add(carrinho);
        }

        public Carrinho1 BuscarPorID(string Id)
        {
            return Carrinhos.FirstOrDefault(c => c.ID == Id);
        }
        public static Carrinho1 DesSerializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Carrinho1>(vJson);
        }
        public static string SerializedClassUnit(Carrinho1 unit)
        {
            return JsonConvert.SerializeObject(unit);
        }

    }
}
