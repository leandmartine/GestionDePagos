using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Pagos
{
    public interface IEncontrarPagoPorId
    {
        PagoDTO Ejecutar(int id);
    }
}
