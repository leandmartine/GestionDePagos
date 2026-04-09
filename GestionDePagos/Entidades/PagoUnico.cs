using System;
using GestionDePagos.ValueObjects;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime FechaPago { get; set; }

        public PagoUnico()
        {
            FechaPago = DateTime.UtcNow;
            Id = 0;
        }

        public override decimal CalcularMontoEnPesos(decimal tasa)
        {
            return Monto.EnPesos(tasa);
        }

        public override bool EstaPendienteEnMes(int mes, int anio)
        {
            return FechaPago.Month == mes && FechaPago.Year == anio;
        }
    }
}
