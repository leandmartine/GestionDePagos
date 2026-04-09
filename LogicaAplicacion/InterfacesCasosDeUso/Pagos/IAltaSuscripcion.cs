using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Pagos
{
    public interface IAltaSuscripcion
    {
        void Ejecutar(SuscripcionDTO dto);
    }
}
