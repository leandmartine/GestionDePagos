using System;
using GestionDePagos.ValueObjects;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public enum Periodicidad
    {
        Mensual,
        Trimestral,
        Anual
    }

    public enum EstadoSuscripcion
    {
        Activa,
        Suspendida,
        Cancelada
    }

    public class Suscripcion : Pago
    {
        public Periodicidad Periodicidad { get; set; }
        public DateTime FechaProximoVencimiento { get; set; }
        public EstadoSuscripcion Estado { get; set; }

        public Suscripcion()
        {
            FechaProximoVencimiento = DateTime.UtcNow;
            Estado = EstadoSuscripcion.Activa;
            Id = 0;
        }

        public override decimal CalcularMontoEnPesos(decimal tasa)
        {
            return Monto.EnPesos(tasa);
        }

        public override bool EstaPendienteEnMes(int mes, int anio)
        {
            return FechaProximoVencimiento.Month == mes && FechaProximoVencimiento.Year == anio && Estado == EstadoSuscripcion.Activa;
        }
    }
}
