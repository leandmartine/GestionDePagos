using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Categorias
{
    public class EncontrarCategoriaPorId : InterfacesCasosDeUso.Categorias.IEncontrarCategoriaPorId
    {
        private readonly ICategoriaRepositorio _repositorio;

        public EncontrarCategoriaPorId(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public CategoriaDTO Ejecutar(int id)
        {
            Categoria entidad = _repositorio.FindById(id);
            return CategoriaMapper.ToDTO(entidad);
        }
    }
}
