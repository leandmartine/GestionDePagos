using System;
using GestionDePagos.ValueObjects;
using GestionDePagos.InterfacesDelDominio;
using GestionDePagos.Excepciones;

namespace GestionDePagos.Entidades
{
    public enum RolUsuario
    {
        Administrador,
        Usuario
    }

    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }
        public Direccion Direccion { get; set; } = new Direccion(string.Empty, string.Empty, string.Empty);

        public Usuario()
        {
            Id = 0;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new UsuarioInvalidoException("El username no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(Password))
                throw new UsuarioInvalidoException("La contraseña no puede estar vacía.");
        }
    }
}
