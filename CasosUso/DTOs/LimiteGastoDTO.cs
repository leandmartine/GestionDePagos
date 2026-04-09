using System;

namespace CasosUso.DTOs
{
    public class LimiteGastoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public decimal MontoMaximo { get; set; }
        public decimal ValorAlerta { get; set; }

        // For display purposes
        public string? UsernameUsuario { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
