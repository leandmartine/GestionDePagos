using System;

namespace GestionDePagos.Excepciones
{
    public class UsuarioInvalidoException : Exception
    {
        public UsuarioInvalidoException(string message) : base(message) { }
    }
}
