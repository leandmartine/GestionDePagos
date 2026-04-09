using System.Collections.Generic;
using System.Linq;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAccesoDatos.EF.Repositorios
{
    public class PagoRepositorio : IPagoRepositorio
    {
        private readonly ManagerContext _context;

        public PagoRepositorio(ManagerContext context)
        {
            _context = context;
        }

        public void Add(Pago obj)
        {
            _context.Expenses.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Pago> FindAll()
        {
            return _context.Expenses.AsQueryable().ToList();
        }

        public Pago FindById(int id)
        {
            var e = _context.Expenses.Find(id);
            if (e == null) throw new KeyNotFoundException($"Pago with id {id} not found.");
            return e;
        }

        public void Remove(int id)
        {
            var e = _context.Expenses.Find(id);
            if (e == null) return;
            _context.Expenses.Remove(e);
            _context.SaveChanges();
        }

        public void Update(Pago obj)
        {
            _context.Expenses.Update(obj);
            _context.SaveChanges();
        }
    }
}
