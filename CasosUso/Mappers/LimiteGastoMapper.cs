using CasosUso.DTOs;
using GestionDePagos.Entidades;

namespace CasosUso.Mappers
{
    public static class LimiteGastoMapper
    {
        public static LimiteGastoDTO ToDTO(LimiteGasto entidad)
        {
            if (entidad == null) return null!;
            return new LimiteGastoDTO
            {
                Id = entidad.Id,
                UsuarioId = entidad.UsuarioId,
                CategoriaId = entidad.CategoriaId,
                MontoMaximo = entidad.MontoMaximo,
                ValorAlerta = entidad.ValorAlerta
            };
        }

        public static LimiteGasto FromDTO(LimiteGastoDTO dto)
        {
            if (dto == null) return null!;
            return new LimiteGasto
            {
                Id = dto.Id,
                UsuarioId = dto.UsuarioId,
                CategoriaId = dto.CategoriaId,
                MontoMaximo = dto.MontoMaximo,
                ValorAlerta = dto.ValorAlerta
            };
        }
    }
}
