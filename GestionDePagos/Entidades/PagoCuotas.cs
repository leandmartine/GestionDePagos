using System;
using GestionDePagos.ValueObjects;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public class PagoCuotas : Pago
    {
        public DateTime FechaInicio { get; set; }
        public int CantidadCuotas { get; set; }
        public int CuotasPagadas { get; set; }

        public PagoCuotas()
        {
            FechaInicio = DateTime.UtcNow;
            Id = 0;
        }

        public override decimal CalcularMontoEnPesos(decimal tasa)
        {
            return Monto.EnPesos(tasa);
        }

        public override bool EstaPendienteEnMes(int mes, int anio)
        {
            if (CantidadCuotas <= 0) return false;

            var mesesTranscurridos = ((anio - FechaInicio.Year) * 12) + (mes - FechaInicio.Month);
            if (mesesTranscurridos < 0) return false;
            int cuotaIndex = mesesTranscurridos + 1; // 1-based index
            return cuotaIndex > CuotasPagadas && cuotaIndex <= CantidadCuotas;
        }
    }
}
