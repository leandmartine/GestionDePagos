using System;

namespace GestionDePagos.Excepciones
{
    public class MetodoPagoInvalidoException : Exception
    {
        public MetodoPagoInvalidoException(string message) : base(message) { }
    }
}
