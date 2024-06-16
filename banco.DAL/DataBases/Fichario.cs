using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace banco.DAL.DataBases
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
                if (!(Directory.Exists(diretorio)))
                {
                    Directory.CreateDirectory(diretorio);

                }
                Diretorio = diretorio;
                Mensagem = "Conexão Com o Fichario Criada Com Sucesso!";

            }
            catch (Exception ex) 
            {
                Status = false;
                Mensagem = "Conexão Com o Fichario Não foi Criada Com Sucesso!" + ex.Message;
                Console.WriteLine(Mensagem);
            }
        }
    }
}
