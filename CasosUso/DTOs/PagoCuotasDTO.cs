using System;

namespace CasosUso.DTOs
{
    public class PagoCuotasDTO : PagoDTO
    {
        public DateTime FechaInicio { get; set; }
        public int CantidadCuotas { get; set; }
        public int CuotasPagadas { get; set; }
    }
}
