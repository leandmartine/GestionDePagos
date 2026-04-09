using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Categorias
{
    public class EditarCategoria : InterfacesCasosDeUso.Categorias.IEditarCategoria
    {
        private readonly ICategoriaRepositorio _repositorio;

        public EditarCategoria(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(CategoriaDTO dto)
        {
            if (dto == null) return;
            Categoria entidad = CategoriaMapper.FromDTO(dto);
            entidad.Validar();
            _repositorio.Update(entidad);
        }
    }
}
