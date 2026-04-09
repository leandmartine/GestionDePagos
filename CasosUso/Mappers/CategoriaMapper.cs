using CasosUso.DTOs;
using GestionDePagos.Entidades;

namespace CasosUso.Mappers
{
    public static class CategoriaMapper
    {
        public static CategoriaDTO ToDTO(Categoria entidad)
        {
            if (entidad == null) return null!;
            return new CategoriaDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Descripcion = entidad.Descripcion
            };
        }

        public static Categoria FromDTO(CategoriaDTO dto)
        {
            if (dto == null) return null!;
            return new Categoria
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };
        }
    }
}
