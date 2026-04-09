using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class AltaPagoCuotas : InterfacesCasosDeUso.Pagos.IAltaPagoCuotas
    {
        private readonly IPagoRepositorio _repositorio;

        public AltaPagoCuotas(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(PagoCuotasDTO dto)
        {
            if (dto == null) return;
            Pago pago = PagoMapper.FromDTO(dto);
            pago.Validar();
            _repositorio.Add(pago);
        }
    }
}
