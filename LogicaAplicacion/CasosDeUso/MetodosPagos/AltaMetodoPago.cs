using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.MetodosPagos
{
    public class AltaMetodoPago : InterfacesCasosDeUso.MetodosPagos.IAltaMetodoPago
    {
        private readonly IMetodoPagoRepositorio _repositorio;

        public AltaMetodoPago(IMetodoPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(MetodoPagoDTO dto)
        {
            if (dto == null) return;
            MetodoPago entidad = MetodoPagoMapper.FromDTO(dto);
            entidad.Validar();
            _repositorio.Add(entidad);
        }
    }
}
