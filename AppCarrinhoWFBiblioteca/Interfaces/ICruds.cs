using banco.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCarrinhoWFBiblioteca.Interfaces
{
    internal interface ICrud<T>
    {
        void CreateInDB(ConexaoDB conexaoDB, T obejectUnit);
        void ReadInDB(ConexaoDB conexaoDB, string id);
        void ReadAllInDB(ConexaoDB conexaoDB);
        void UpdateInDB(ConexaoDB conexaoDB, T entity);
        void DeleteInDB(ConexaoDB conexaoDB, string id);
    }
}
