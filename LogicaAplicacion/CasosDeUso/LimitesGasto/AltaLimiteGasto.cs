using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.Excepciones;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.LimitesGasto
{
    public class AltaLimiteGasto : InterfacesCasosDeUso.LimitesGasto.IAltaLimiteGasto
    {
        private readonly ILimiteGastoRepositorio _repositorio;

        public AltaLimiteGasto(ILimiteGastoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(LimiteGastoDTO dto)
        {
            if (dto == null) return;

            if (_repositorio.ExisteParaUsuarioYCategoria(dto.UsuarioId, dto.CategoriaId))
                throw new LimiteGastoInvalidoException("Ya existe un límite de gasto para ese usuario y categoría.");

            LimiteGasto entidad = LimiteGastoMapper.FromDTO(dto);
            entidad.Validar();
            _repositorio.Add(entidad);
        }
    }
}
