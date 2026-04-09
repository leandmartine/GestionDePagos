using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.MetodosPagos
{
    public class EncontrarMetodoPagoPorId : InterfacesCasosDeUso.MetodosPagos.IEncontrarMetodoPagoPorId
    {
        private readonly IMetodoPagoRepositorio _repositorio;

        public EncontrarMetodoPagoPorId(IMetodoPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public MetodoPagoDTO Ejecutar(int id)
        {
            MetodoPago entidad = _repositorio.FindById(id);
            return MetodoPagoMapper.ToDTO(entidad);
        }
    }
}
