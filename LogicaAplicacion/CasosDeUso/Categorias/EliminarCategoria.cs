using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Categorias
{
    public class EliminarCategoria : InterfacesCasosDeUso.Categorias.IEliminarCategoria
    {
        private readonly ICategoriaRepositorio _repositorio;

        public EliminarCategoria(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(int id)
        {
            _repositorio.Remove(id);
        }
    }
}
