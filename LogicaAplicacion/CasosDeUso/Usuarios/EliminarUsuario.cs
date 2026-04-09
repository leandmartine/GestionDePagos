using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class EliminarUsuario : InterfacesCasosDeUso.Usuarios.IEliminarUsuario
    {
        private readonly IUsuarioRepositorio _repositorio;

        public EliminarUsuario(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(int id)
        {
            _repositorio.Remove(id);
        }
    }
}
