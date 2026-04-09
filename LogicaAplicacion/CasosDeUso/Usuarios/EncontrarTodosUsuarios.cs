using System.Collections.Generic;
using System.Linq;
using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;
using GestionDePagos.Entidades;
using System;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class EncontrarTodosUsuarios : InterfacesCasosDeUso.Usuarios.IEncontrarTodosUsuarios
    {
        private readonly IUsuarioRepositorio _repositorio;

        public EncontrarTodosUsuarios(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<UsuarioDTO> Ejecutar()
        {
            IEnumerable<Usuario> lista = _repositorio.FindAll();
            return lista.Select(ent => UsuarioMapper.ToDTO(ent));
        }
    }
}
