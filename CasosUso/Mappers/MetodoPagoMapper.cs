using CasosUso.DTOs;
using GestionDePagos.Entidades;

namespace CasosUso.Mappers
{
    public static class MetodoPagoMapper
    {
        public static MetodoPagoDTO ToDTO(MetodoPago entidad)
        {
            if (entidad == null) return null!;
            return new MetodoPagoDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Detalle = entidad.Detalle
            };
        }

        public static MetodoPago FromDTO(MetodoPagoDTO dto)
        {
            if (dto == null) return null!;
            return new MetodoPago
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Detalle = dto.Detalle
            };
        }
    }
}
