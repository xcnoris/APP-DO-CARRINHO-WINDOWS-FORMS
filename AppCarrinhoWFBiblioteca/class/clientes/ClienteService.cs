using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.clientes
{
    public class ClienteService
    {

        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

        public void AddCliente(Cliente cliente)
        {
            cliente.ValidarClass();
            Clientes.Add(cliente);
        }

        public Cliente BuscarPorID(string id)
        {
            return Clientes.FirstOrDefault(c => c.ID == id);
        }

        // Transforma Json em Class
        public static Cliente DeserializeCliente(string vJson)
        {
            return JsonConvert.DeserializeObject<Cliente>(vJson);
        }

        // Transforma Class em Json
        public static string SerializeCliente(Cliente cliente)
        {
            return JsonConvert.SerializeObject(cliente);
        }
    }
}
