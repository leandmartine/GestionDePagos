using System;

namespace GestionDePagos.Excepciones
{
    public class CategoriaInvalidaException : Exception
    {
        public CategoriaInvalidaException(string message) : base(message) { }
    }
}
