using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto
{
    public interface IEncontrarLimiteGastoPorId
    {
        LimiteGastoDTO Ejecutar(int id);
    }
}
