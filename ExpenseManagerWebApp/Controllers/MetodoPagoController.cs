using Microsoft.AspNetCore.Mvc;
using CasosUso.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos;
using System.Collections.Generic;

namespace ExpenseManagerWebApp.Controllers
{
    public class MetodoPagoController : Controller
    {
        private readonly IEncontrarTodosMetodosPago _encontrarTodos;
        private readonly IAltaMetodoPago _alta;
        private readonly IEncontrarMetodoPagoPorId _encontrarPorId;
        private readonly IEditarMetodoPago _editar;
        private readonly IEliminarMetodoPago _eliminar;

        public MetodoPagoController(
            IEncontrarTodosMetodosPago encontrarTodos,
            IAltaMetodoPago alta,
            IEncontrarMetodoPagoPorId encontrarPorId,
            IEditarMetodoPago editar,
            IEliminarMetodoPago eliminar)
        {
            _encontrarTodos = encontrarTodos;
            _alta = alta;
            _encontrarPorId = encontrarPorId;
            _editar = editar;
            _eliminar = eliminar;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<MetodoPagoDTO> lista = _encontrarTodos.Ejecutar();
                return View(lista);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<MetodoPagoDTO>());
            }
        }

        public IActionResult Create()
        {
            return View(new MetodoPagoDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MetodoPagoDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);
            try
            {
                _alta.Ejecutar(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(dto);
            }
        }

        public IActionResult Details(int id)
        {
            MetodoPagoDTO mp = _encontrarPorId.Ejecutar(id);
            if (mp == null) return NotFound();
            return View(mp);
        }

        public IActionResult Edit(int id)
        {
            MetodoPagoDTO mp = _encontrarPorId.Ejecutar(id);
            if (mp == null) return NotFound();
            return View(mp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MetodoPagoDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);
            try
            {
                _editar.Ejecutar(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(dto);
            }
        }

        public IActionResult Delete(int id)
        {
            MetodoPagoDTO mp = _encontrarPorId.Ejecutar(id);
            if (mp == null) return NotFound();
            return View(mp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _eliminar.Ejecutar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
