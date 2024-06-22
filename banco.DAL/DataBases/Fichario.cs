using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;


namespace DataBase.DataBases
{
    public class Fichario
    {
        public string Diretorio;
        public string Mensagem;
        public bool Status;

        public Fichario(string diretorio)
        {
            Status = true;
            try
            {
                // Verifica se o diretorio informado existe, caso nao exista, cria um diretoro com o caminho informado
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }
                
                Diretorio = diretorio;
                Mensagem = "Conexão Com o Fichario Criada Com Sucesso!";
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Conexão Com o Fichario Não foi Criada Com Sucesso! " + ex.Message;
            }
        }

        public void Incluir(string Id, string jsonUnit)
        {
            Status = true;
            try
            {
                // Verifica se já exist um arquivo com o mesmo nome
                if (File.Exists(Diretorio + "\\" + Id + ".json"))
                {
                    Status = false;
                    Mensagem = $"Inclusão Negada. ID {Id} já existe na Base de Dados";
                }
                else
                {
                    // Caso não exista ele cria o arquivo | MEtodo WriteAllText Escreve os dados dentro do arquivo
                    File.WriteAllText(Diretorio + "\\" + Id + ".json", jsonUnit);
                    Status = true;
                    Mensagem = $"Inclusão Executada com Sucesso!. ID do Carrinho {Id}";
                }


            }
            catch (Exception ex) 
            {
                Status = false;
                Mensagem = "Conexão Com o Fichario Não foi Criada Com Sucesso! " + ex.Message;
            }


        }

        // BUsca dentro do diretorio se existe um arquivo Json com o id passado, caso tenha ele retorna a string do Json
        public string Buscar(string Id)
        {
            Status = true;
            try
            {

                // Verifica se já exist um arquivo com o mesmo nome
                if (!File.Exists(Diretorio + "\\" + Id + ".json"))
                {
                    Status = false;
                    Mensagem = $"Id {Id} Não existe na Base de dados!";
                }
                else
                {
                    string conteudo = File.ReadAllText(Diretorio + "\\" + Id + ".json");
                    Status = true;
                    Mensagem = $"Inclusão Executada com Sucesso!. ID do Carrinho {Id}";
                    return conteudo;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao buscar os carrinhos cadastrados:  " + ex.Message;
            }
            return "";
        }

        public List<string> ListarTodos()
        {
            List<string> lista = new List<string>();
            try
            {
                var arquivos = Directory.GetFiles(this.Diretorio, "*.json");
                foreach (var arquivo in arquivos)
                {
                    // Para cada arquivo dentro do for, eu leio o conteudo e jogo dentro da lista
                    lista.Add(File.ReadAllText(arquivo));
                }
                this.Status = true;
            }
            catch (Exception ex)
            {
                this.Status = false;
                this.Mensagem = $"[ERROR]: {ex.Message}";
            }
            return lista;
        }


    }
}
