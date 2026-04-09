using System.Collections.Generic;
using CasosUso.DTOs;

namespace LogicaAplicacion.InterfacesCasosDeUso.Usuarios
{
    public interface IEncontrarTodosUsuarios
    {
        IEnumerable<UsuarioDTO> Ejecutar();
    }
}
