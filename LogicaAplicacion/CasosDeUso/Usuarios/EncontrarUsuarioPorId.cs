using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.Entidades;
using GestionDePagos.InterfacesDeRepositorio;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class EncontrarUsuarioPorId : InterfacesCasosDeUso.Usuarios.IEncontrarUsuarioPorId
    {
        private readonly IUsuarioRepositorio _repositorio;

        public EncontrarUsuarioPorId(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public UsuarioDTO Ejecutar(int id)
        {
            Usuario entidad = _repositorio.FindById(id);
            return UsuarioMapper.ToDTO(entidad);
        }
    }
}
