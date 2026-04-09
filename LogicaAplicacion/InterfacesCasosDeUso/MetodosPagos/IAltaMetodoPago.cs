using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos
{
    public interface IAltaMetodoPago
    {
        void Ejecutar(MetodoPagoDTO dto);
    }
}
