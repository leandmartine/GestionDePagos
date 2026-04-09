using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Pagos
{
    public interface IAltaPagoUnico
    {
        void Ejecutar(PagoUnicoDTO dto);
    }
}
