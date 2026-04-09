using System.Collections.Generic;
using System.Linq;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAccesoDatos.EF.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ManagerContext _context;

        public UsuarioRepositorio(ManagerContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios.AsQueryable().ToList();
        }

        public Usuario FindById(int id)
        {
            var e = _context.Usuarios.Find(id);
            if (e == null) throw new KeyNotFoundException($"Usuario with id {id} not found.");
            return e;
        }

        public void Remove(int id)
        {
            var e = _context.Usuarios.Find(id);
            if (e == null) return;
            _context.Usuarios.Remove(e);
            _context.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
        }
    }
}
