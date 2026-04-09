using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class AltaSuscripcion : InterfacesCasosDeUso.Pagos.IAltaSuscripcion
    {
        private readonly IPagoRepositorio _repositorio;

        public AltaSuscripcion(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(SuscripcionDTO dto)
        {
            if (dto == null) return;
            Pago pago = PagoMapper.FromDTO(dto);
            pago.Validar();
            _repositorio.Add(pago);
        }
    }
}
