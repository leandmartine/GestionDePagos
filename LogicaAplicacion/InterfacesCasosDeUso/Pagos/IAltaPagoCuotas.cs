using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Pagos
{
    public interface IAltaPagoCuotas
    {
        void Ejecutar(PagoCuotasDTO dto);
    }
}
