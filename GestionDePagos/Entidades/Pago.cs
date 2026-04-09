using System;
using GestionDePagos.ValueObjects;
using GestionDePagos.InterfacesDelDominio;
using GestionDePagos.Excepciones;
using GestionDePagos.Enums;

namespace GestionDePagos.Entidades
{
    public abstract class Pago : IValidable
    {
        public Dinero Monto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public int MetodoPagoId { get; set; }
        public DateTime FechaRegistro { get; set; }

        protected Pago()
        {
            Id = 0;
            FechaRegistro = DateTime.UtcNow;
            Monto = new Dinero(0m, Moneda.UYU);
        }

        public virtual void Validar()
        {
            if (Monto == null)
                throw new PagoInvalidoException("El monto no puede ser nulo.");
            if (Monto.Valor <= 0)
                throw new PagoInvalidoException("El monto debe ser mayor que cero.");
        }

        public abstract decimal CalcularMontoEnPesos(decimal tasa);
        public abstract bool EstaPendienteEnMes(int mes, int anio);
    }
}
