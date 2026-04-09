using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Usuarios
{
    public interface IEncontrarUsuarioPorId
    {
        UsuarioDTO Ejecutar(int id);
    }
}
