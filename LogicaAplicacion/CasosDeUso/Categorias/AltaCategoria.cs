using CasosUso.DTOs;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;
using CasosUso.Mappers;

namespace LogicaAplicacion.CasosDeUso.Categorias
{
    public class AltaCategoria : InterfacesCasosDeUso.Categorias.IAltaCategoria
    {
        private readonly ICategoriaRepositorio _repositorio;

        public AltaCategoria(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null) return;
            Categoria entidad = CategoriaMapper.FromDTO(categoriaDto);
            entidad.Validar();
            _repositorio.Add(entidad);
        }
    }
}
