using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class EncontrarPagoPorId : InterfacesCasosDeUso.Pagos.IEncontrarPagoPorId
    {
        private readonly IPagoRepositorio _repositorio;

        public EncontrarPagoPorId(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public PagoDTO Ejecutar(int id)
        {
            var pago = _repositorio.FindById(id);
            return PagoMapper.ToDTO(pago);
        }
    }
}
