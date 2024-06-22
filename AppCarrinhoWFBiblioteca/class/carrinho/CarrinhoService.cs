using AppCarrinhoWFBiblioteca.carrinho1;
using AppCarrinhoWFBiblioteca.clientes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.DataBases;
using System.Net.Http;

namespace AppCarrinhoWFBiblioteca.carrinho
{
    public class CarrinhoService
    {
        public string Menssage {  get; set; }
        public bool Status;

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

        public void IncluirFicharioCarrinho(string conexao, Carrinho1 carrinhoUnit)
        {
            Status = true;
            // Transforma a class Carrinho1 em Json
            string clienteJson = CarrinhoService.SerializedClassUnit(carrinhoUnit);
            // Instancia o Fichario passando o diretorio
            Fichario F = new Fichario(conexao);
            if (F.Status)
            {
                // Passa o Json do Carrinho1 para o fichario salvar no diretorio
                F.Incluir(carrinhoUnit.ID, clienteJson);
                if (!(F.Status))
                {
                    Status = true;
                    F.Incluir(carrinhoUnit.ID, clienteJson);
                    // Caso não consiga adiconar o novo carrinho, retorna mensagem de erro
                    if (!F.Status)
                    {
                        // caso o id já exista na base de dados, retorna uma mensagem de erro
                        throw new Exception(Menssage = F.Mensagem);   
                    }
                }
       
            }
            else
            {
                Menssage = F.Mensagem;
                throw new Exception(F.Mensagem);
            }
        }

    }
}
