using System.Collections.Generic;
using System.Linq;
using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;
using GestionDePagos.Entidades;
using System;

namespace LogicaAplicacion.CasosDeUso.MetodosPagos
{
    public class EncontrarTodosMetodosPago : InterfacesCasosDeUso.MetodosPagos.IEncontrarTodosMetodosPago
    {
        private readonly IMetodoPagoRepositorio _repositorio;

        public EncontrarTodosMetodosPago(IMetodoPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<MetodoPagoDTO> Ejecutar()
        {
            return _repositorio.FindAll().Select(MetodoPagoMapper.ToDTO);
        }
    }
}
