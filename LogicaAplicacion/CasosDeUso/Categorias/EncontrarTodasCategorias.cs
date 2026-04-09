using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using System.Collections.Generic;
using System.Linq;

namespace LogicaAplicacion.CasosDeUso.Categorias
{
    public class EncontrarTodasCategorias : IEncontrarTodasCategorias
    {
        private readonly ICategoriaRepositorio _repositorio;

        public EncontrarTodasCategorias(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<CategoriaDTO> Ejecutar()
        {
            return _repositorio.FindAll().Select(CategoriaMapper.ToDTO);
        }
    }
}
