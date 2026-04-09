using System.Collections.Generic;
using System.Linq;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAccesoDatos.EF.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ManagerContext _context;

        public CategoriaRepositorio(ManagerContext context)
        {
            _context = context;
        }

        public void Add(Categoria obj)
        {
            _context.Categorias.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Categoria> FindAll()
        {
            return _context.Categorias.AsQueryable().ToList();
        }

        public Categoria FindById(int id)
        {
            var e = _context.Categorias.Find(id);
            if (e == null) throw new KeyNotFoundException($"Categoria with id {id} not found.");
            return e;
        }

        public void Remove(int id)
        {
            var e = _context.Categorias.Find(id);
            if (e == null) return;
            _context.Categorias.Remove(e);
            _context.SaveChanges();
        }

        public void Update(Categoria obj)
        {
            _context.Categorias.Update(obj);
            _context.SaveChanges();
        }
    }
}
