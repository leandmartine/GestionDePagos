using System;

namespace GestionDePagos.Excepciones
{
    public class LimiteGastoInvalidoException : Exception
    {
        public LimiteGastoInvalidoException(string message) : base(message) { }
    }
}
