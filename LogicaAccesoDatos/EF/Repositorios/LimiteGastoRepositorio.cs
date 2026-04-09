using System.Collections.Generic;
using System.Linq;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAccesoDatos.EF.Repositorios
{
    public class LimiteGastoRepositorio : ILimiteGastoRepositorio
    {
        private readonly ManagerContext _context;

        public LimiteGastoRepositorio(ManagerContext context)
        {
            _context = context;
        }

        public void Add(LimiteGasto obj)
        {
            _context.LimitesGasto.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<LimiteGasto> FindAll()
        {
            return _context.LimitesGasto.ToList();
        }

        public LimiteGasto FindById(int id)
        {
            var e = _context.LimitesGasto.Find(id);
            if (e == null) throw new KeyNotFoundException($"LimiteGasto with id {id} not found.");
            return e;
        }

        public void Remove(int id)
        {
            var e = _context.LimitesGasto.Find(id);
            if (e == null) return;
            _context.LimitesGasto.Remove(e);
            _context.SaveChanges();
        }

        public void Update(LimiteGasto obj)
        {
            _context.LimitesGasto.Update(obj);
            _context.SaveChanges();
        }

        public bool ExisteParaUsuarioYCategoria(int usuarioId, int categoriaId)
        {
            return _context.LimitesGasto.Any(l => l.UsuarioId == usuarioId && l.CategoriaId == categoriaId);
        }

        public IEnumerable<LimiteGasto> FindByUsuario(int usuarioId)
        {
            return _context.LimitesGasto.Where(l => l.UsuarioId == usuarioId).ToList();
        }
    }
}
