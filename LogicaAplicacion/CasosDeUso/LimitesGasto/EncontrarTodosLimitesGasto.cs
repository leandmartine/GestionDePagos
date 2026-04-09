using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;
using System.Collections.Generic;
using System.Linq;

namespace LogicaAplicacion.CasosDeUso.LimitesGasto
{
    public class EncontrarTodosLimitesGasto : InterfacesCasosDeUso.LimitesGasto.IEncontrarTodosLimitesGasto
    {
        private readonly ILimiteGastoRepositorio _repositorio;

        public EncontrarTodosLimitesGasto(ILimiteGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<LimiteGastoDTO> Ejecutar()
        {
            return _repositorio.FindAll().Select(l => LimiteGastoMapper.ToDTO(l)).ToList();
        }
    }
}
