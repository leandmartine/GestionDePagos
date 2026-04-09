using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class EditarUsuario : InterfacesCasosDeUso.Usuarios.IEditarUsuario
    {
        private readonly IUsuarioRepositorio _repositorio;

        public EditarUsuario(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Ejecutar(UsuarioDTO dto)
        {
            if (dto == null) return;
            Usuario entidad = UsuarioMapper.FromDTO(dto);
            entidad.Validar();
            _repositorio.Update(entidad);
        }
    }
}
