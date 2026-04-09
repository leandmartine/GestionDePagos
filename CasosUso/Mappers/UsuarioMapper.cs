using CasosUso.DTOs;
using GestionDePagos.Entidades;
using GestionDePagos.ValueObjects;

namespace CasosUso.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO ToDTO(Usuario entidad)
        {
            if (entidad == null) return null!;
            return new UsuarioDTO
            {
                Id = entidad.Id,
                Username = entidad.Username,
                Password = entidad.Password,
                Rol = entidad.Rol.ToString(),
                Calle = entidad.Direccion.Calle,
                Ciudad = entidad.Direccion.Ciudad,
                CodigoPostal = entidad.Direccion.CodigoPostal
            };
        }

        public static Usuario FromDTO(UsuarioDTO dto)
        {
            if (dto == null) return null!;
            return new Usuario
            {
                Id = dto.Id,
                Username = dto.Username,
                Password = dto.Password,
                Rol = Enum.TryParse<RolUsuario>(dto.Rol, out var r) ? r : RolUsuario.Usuario,
                Direccion = new Direccion(dto.Calle, dto.Ciudad, dto.CodigoPostal)
            };
        }
    }
}
