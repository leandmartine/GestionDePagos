using CasosUso.DTOs;
using System.Collections.Generic;

namespace LogicaAplicacion.InterfacesCasosDeUso.Pagos
{
    public interface IEncontrarTodosPagos
    {
        IEnumerable<PagoDTO> Ejecutar();
    }
}
