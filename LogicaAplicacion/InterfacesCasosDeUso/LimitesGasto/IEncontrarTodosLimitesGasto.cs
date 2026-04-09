using CasosUso.DTOs;
using System.Collections.Generic;

namespace LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto
{
    public interface IEncontrarTodosLimitesGasto
    {
        IEnumerable<LimiteGastoDTO> Ejecutar();
    }
}
