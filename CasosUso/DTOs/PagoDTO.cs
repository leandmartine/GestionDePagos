using System;

namespace CasosUso.DTOs
{
    public abstract class PagoDTO
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string? Moneda { get; set; } = "UYU"; // keep currency as string for DTO simplicity
        public string Descripcion { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public int MetodoPagoId { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
