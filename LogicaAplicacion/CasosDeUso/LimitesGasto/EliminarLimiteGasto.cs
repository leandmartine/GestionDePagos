using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.LimitesGasto
{
    public class EliminarLimiteGasto : InterfacesCasosDeUso.LimitesGasto.IEliminarLimiteGasto
    {
        private readonly ILimiteGastoRepositorio _repositorio;

        public EliminarLimiteGasto(ILimiteGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(int id)
        {
            _repositorio.Remove(id);
        }
    }
}
