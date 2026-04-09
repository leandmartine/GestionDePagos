using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.LimitesGasto
{
    public class EncontrarLimiteGastoPorId : InterfacesCasosDeUso.LimitesGasto.IEncontrarLimiteGastoPorId
    {
        private readonly ILimiteGastoRepositorio _repositorio;

        public EncontrarLimiteGastoPorId(ILimiteGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public LimiteGastoDTO Ejecutar(int id)
        {
            var entidad = _repositorio.FindById(id);
            return LimiteGastoMapper.ToDTO(entidad);
        }
    }
}
