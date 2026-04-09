using System;

namespace CasosUso.DTOs
{
    public class SuscripcionDTO : PagoDTO
    {
        // Use ints for enum-like fields in DTOs to keep them primitive
        public int Periodicidad { get; set; }
        public DateTime FechaProximoVencimiento { get; set; }
        public int Estado { get; set; }
    }
}
