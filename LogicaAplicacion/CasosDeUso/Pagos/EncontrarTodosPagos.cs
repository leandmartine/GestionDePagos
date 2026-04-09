using CasosUso.DTOs;
using CasosUso.Mappers;
using GestionDePagos.InterfacesDeRepositorio;
using System.Collections.Generic;
using System.Linq;

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class EncontrarTodosPagos : InterfacesCasosDeUso.Pagos.IEncontrarTodosPagos
    {
        private readonly IPagoRepositorio _repositorio;

        public EncontrarTodosPagos(IPagoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<PagoDTO> Ejecutar()
        {
            return _repositorio.FindAll()
                .Select(p => PagoMapper.ToDTO(p))
                .Where(p => p != null)
                .ToList();
        }
    }
}
