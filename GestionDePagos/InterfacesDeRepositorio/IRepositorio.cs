using GestionDePagos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePagos.InterfacesDeRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(int id);
        IEnumerable<T> FindAll();
        T FindById(int id);       

    }
}
