using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.MetodosPagos
{
    public class EliminarMetodoPago : InterfacesCasosDeUso.MetodosPagos.IEliminarMetodoPago
    {
        private readonly IMetodoPagoRepositorio _repositorio;

        public EliminarMetodoPago(IMetodoPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(int id)
        {
            _repositorio.Remove(id);
        }
    }
}
