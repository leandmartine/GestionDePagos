using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.MetodosPagos
{
    public class EditarMetodoPago : InterfacesCasosDeUso.MetodosPagos.IEditarMetodoPago
    {
        private readonly IMetodoPagoRepositorio _repositorio;

        public EditarMetodoPago(IMetodoPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(MetodoPagoDTO dto)
        {
            if (dto == null) return;
            MetodoPago entidad = MetodoPagoMapper.FromDTO(dto);
            entidad.Validar();
            _repositorio.Update(entidad);
        }
    }
}
