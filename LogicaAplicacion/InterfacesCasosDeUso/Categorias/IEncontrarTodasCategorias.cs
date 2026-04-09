using System.Collections.Generic;
using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Categorias
{
    public interface IEncontrarTodasCategorias
    {
        IEnumerable<CategoriaDTO> Ejecutar();
    }
}
