using System;

namespace CasosUso.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        // Do not expose password in DTOs in real apps, included here per request
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;

        // Direccion as primitives
        public string Calle { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
    }
}
