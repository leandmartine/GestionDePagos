using System;

namespace GestionDePagos.Excepciones
{
    public class PagoInvalidoException : Exception
    {
        public PagoInvalidoException(string message) : base(message) { }
    }
}
