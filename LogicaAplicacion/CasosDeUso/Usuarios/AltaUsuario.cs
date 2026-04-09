using CasosUso.DTOs;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;
using CasosUso.Mappers;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class AltaUsuario : InterfacesCasosDeUso.Usuarios.IAltaUsuario
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AltaUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Ejecutar(UsuarioDTO usuarioDto)
        {
            // Validaciones básicas
            if (usuarioDto == null) return;

            Usuario usuario = UsuarioMapper.FromDTO(usuarioDto);
            usuario.Validar();

            _usuarioRepositorio.Add(usuario);
        }
    }
}
