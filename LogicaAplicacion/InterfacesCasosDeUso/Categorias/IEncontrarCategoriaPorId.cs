using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Categorias
{
    public interface IEncontrarCategoriaPorId
    {
        CategoriaDTO Ejecutar(int id);
    }
}
