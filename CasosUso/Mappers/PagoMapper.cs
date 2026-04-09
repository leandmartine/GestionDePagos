using CasosUso.DTOs;
using GestionDePagos.Entidades;
using GestionDePagos.Enums;
using GestionDePagos.ValueObjects;

namespace CasosUso.Mappers
{
    public static class PagoMapper
    {
        public static PagoDTO ToDTO(Pago entidad)
        {
            if (entidad == null) return null!;

            return entidad switch
            {
                PagoUnico pu => new PagoUnicoDTO
                {
                    Id = pu.Id,
                    Monto = pu.Monto.Valor,
                    Moneda = pu.Monto.Moneda.ToString(),
                    Descripcion = pu.Descripcion,
                    CategoriaId = pu.CategoriaId,
                    UsuarioId = pu.UsuarioId,
                    MetodoPagoId = pu.MetodoPagoId,
                    FechaRegistro = pu.FechaRegistro,
                    FechaPago = pu.FechaPago
                },
                PagoCuotas pc => new PagoCuotasDTO
                {
                    Id = pc.Id,
                    Monto = pc.Monto.Valor,
                    Moneda = pc.Monto.Moneda.ToString(),
                    Descripcion = pc.Descripcion,
                    CategoriaId = pc.CategoriaId,
                    UsuarioId = pc.UsuarioId,
                    MetodoPagoId = pc.MetodoPagoId,
                    FechaRegistro = pc.FechaRegistro,
                    FechaInicio = pc.FechaInicio,
                    CantidadCuotas = pc.CantidadCuotas,
                    CuotasPagadas = pc.CuotasPagadas
                },
                Suscripcion s => new SuscripcionDTO
                {
                    Id = s.Id,
                    Monto = s.Monto.Valor,
                    Moneda = s.Monto.Moneda.ToString(),
                    Descripcion = s.Descripcion,
                    CategoriaId = s.CategoriaId,
                    UsuarioId = s.UsuarioId,
                    MetodoPagoId = s.MetodoPagoId,
                    FechaRegistro = s.FechaRegistro,
                    Periodicidad = (int)s.Periodicidad,
                    FechaProximoVencimiento = s.FechaProximoVencimiento,
                    Estado = (int)s.Estado
                },
                _ => null!
            };
        }

        public static Pago FromDTO(PagoDTO dto)
        {
            if (dto == null) return null!;

            Moneda moneda = Enum.TryParse<Moneda>(dto.Moneda, true, out var m) ? m : Moneda.UYU;

            return dto switch
            {
                PagoUnicoDTO pu => new PagoUnico
                {
                    Id = pu.Id,
                    Monto = new Dinero(pu.Monto, moneda),
                    Descripcion = pu.Descripcion,
                    CategoriaId = pu.CategoriaId,
                    UsuarioId = pu.UsuarioId,
                    MetodoPagoId = pu.MetodoPagoId,
                    FechaRegistro = pu.FechaRegistro,
                    FechaPago = pu.FechaPago
                },
                PagoCuotasDTO pc => new PagoCuotas
                {
                    Id = pc.Id,
                    Monto = new Dinero(pc.Monto, moneda),
                    Descripcion = pc.Descripcion,
                    CategoriaId = pc.CategoriaId,
                    UsuarioId = pc.UsuarioId,
                    MetodoPagoId = pc.MetodoPagoId,
                    FechaRegistro = pc.FechaRegistro,
                    FechaInicio = pc.FechaInicio,
                    CantidadCuotas = pc.CantidadCuotas,
                    CuotasPagadas = pc.CuotasPagadas
                },
                SuscripcionDTO s => new Suscripcion
                {
                    Id = s.Id,
                    Monto = new Dinero(s.Monto, moneda),
                    Descripcion = s.Descripcion,
                    CategoriaId = s.CategoriaId,
                    UsuarioId = s.UsuarioId,
                    MetodoPagoId = s.MetodoPagoId,
                    FechaRegistro = s.FechaRegistro,
                    Periodicidad = (Periodicidad)s.Periodicidad,
                    FechaProximoVencimiento = s.FechaProximoVencimiento,
                    Estado = (EstadoSuscripcion)s.Estado
                },
                _ => null!
            };
        }
    }
}
