using GestionDePagos.Entidades;

namespace GestionDePagos.InterfacesDeRepositorio
{
    public interface ILimiteGastoRepositorio : IRepositorio<LimiteGasto>
    {
        bool ExisteParaUsuarioYCategoria(int usuarioId, int categoriaId);
        IEnumerable<LimiteGasto> FindByUsuario(int usuarioId);
    }
}
