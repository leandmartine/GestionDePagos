using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;
using GestionDePagos.ValueObjects;

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class AltaPagoUnico : InterfacesCasosDeUso.Pagos.IAltaPagoUnico
    {
        private readonly IPagoRepositorio _repositorio;

        public AltaPagoUnico(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(PagoUnicoDTO dto)
        {
            if (dto == null) return;
            Pago pago = PagoMapper.FromDTO(dto);
            pago.Validar();
            _repositorio.Add(pago);
        }
    }
}
