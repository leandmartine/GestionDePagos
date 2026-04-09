using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos
{
    public interface IEncontrarMetodoPagoPorId
    {
        MetodoPagoDTO Ejecutar(int id);
    }
}
