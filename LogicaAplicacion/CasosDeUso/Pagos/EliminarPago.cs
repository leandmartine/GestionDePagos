using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class EliminarPago : InterfacesCasosDeUso.Pagos.IEliminarPago
    {
        private readonly IPagoRepositorio _repositorio;

        public EliminarPago(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(int id)
        {
            _repositorio.Remove(id);
        }
    }
}
