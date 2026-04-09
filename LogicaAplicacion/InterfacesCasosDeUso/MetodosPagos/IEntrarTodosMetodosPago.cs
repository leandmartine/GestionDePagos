using System.Collections.Generic;
using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos
{
    public interface IEncontrarTodosMetodosPago
    {
        IEnumerable<MetodoPagoDTO> Ejecutar();
    }
}
