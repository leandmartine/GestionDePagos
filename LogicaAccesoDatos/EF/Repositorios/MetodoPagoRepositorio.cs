using System.Collections.Generic;
using System.Linq;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAccesoDatos.EF.Repositorios
{
    public class MetodoPagoRepositorio : IMetodoPagoRepositorio
    {
        private readonly ManagerContext _context;

        public MetodoPagoRepositorio(ManagerContext context)
        {
            _context = context;
        }

        public void Add(MetodoPago obj)
        {
            _context.MetodosPago.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<MetodoPago> FindAll()
        {
            return _context.MetodosPago.AsQueryable().ToList();
        }

        public MetodoPago FindById(int id)
        {
            var e = _context.MetodosPago.Find(id);
            if (e == null) throw new KeyNotFoundException($"MetodoPago with id {id} not found.");
            return e;
        }

        public void Remove(int id)
        {
            var e = _context.MetodosPago.Find(id);
            if (e == null) return;
            _context.MetodosPago.Remove(e);
            _context.SaveChanges();
        }

        public void Update(MetodoPago obj)
        {
            _context.MetodosPago.Update(obj);
            _context.SaveChanges();
        }
    }
}
