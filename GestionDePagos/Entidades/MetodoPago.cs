using System;
using GestionDePagos.InterfacesDelDominio;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public class MetodoPago : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;

        public MetodoPago()
        {
            Id = 0;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new MetodoPagoInvalidoException("El nombre del método de pago no puede estar vacío.");
        }
    }
}
