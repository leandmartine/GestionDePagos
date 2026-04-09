using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CasosUso.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Pagos;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using LogicaAplicacion.InterfacesCasosDeUso.MetodosPagos;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManagerWebApp.Controllers
{
    public class PagoController : Controller
    {
        private readonly IEncontrarTodosPagos _encontrarTodos;
        private readonly IEncontrarPagoPorId _encontrarPorId;
        private readonly IAltaPagoUnico _altaPagoUnico;
        private readonly IAltaPagoCuotas _altaPagoCuotas;
        private readonly IAltaSuscripcion _altaSuscripcion;
        private readonly IEliminarPago _eliminar;
        private readonly IEncontrarTodasCategorias _categorias;
        private readonly IEncontrarTodosUsuarios _usuarios;
        private readonly IEncontrarTodosMetodosPago _metodosPago;

        public PagoController(
            IEncontrarTodosPagos encontrarTodos,
            IEncontrarPagoPorId encontrarPorId,
            IAltaPagoUnico altaPagoUnico,
            IAltaPagoCuotas altaPagoCuotas,
            IAltaSuscripcion altaSuscripcion,
            IEliminarPago eliminar,
            IEncontrarTodasCategorias categorias,
            IEncontrarTodosUsuarios usuarios,
            IEncontrarTodosMetodosPago metodosPago)
        {
            _encontrarTodos = encontrarTodos;
            _encontrarPorId = encontrarPorId;
            _altaPagoUnico = altaPagoUnico;
            _altaPagoCuotas = altaPagoCuotas;
            _altaSuscripcion = altaSuscripcion;
            _eliminar = eliminar;
            _categorias = categorias;
            _usuarios = usuarios;
            _metodosPago = metodosPago;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<PagoDTO> lista = _encontrarTodos.Ejecutar();
                return View(lista);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<PagoDTO>());
            }
        }

        public IActionResult Details(int id)
        {
            PagoDTO pago = _encontrarPorId.Ejecutar(id);
            if (pago == null) return NotFound();
            return View(pago);
        }

        // --- Pago Unico ---
        public IActionResult CreatePagoUnico()
        {
            CargarListas();
            return View(new PagoUnicoDTO { FechaPago = System.DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePagoUnico(PagoUnicoDTO dto)
        {
            if (!ModelState.IsValid) { CargarListas(); return View(dto); }
            try
            {
                dto.FechaRegistro = System.DateTime.UtcNow;
                _altaPagoUnico.Ejecutar(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                CargarListas();
                return View(dto);
            }
        }

        // --- Pago Cuotas ---
        public IActionResult CreatePagoCuotas()
        {
            CargarListas();
            return View(new PagoCuotasDTO { FechaInicio = System.DateTime.Today });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePagoCuotas(PagoCuotasDTO dto)
        {
            if (!ModelState.IsValid) { CargarListas(); return View(dto); }
            try
            {
                dto.FechaRegistro = System.DateTime.UtcNow;
                _altaPagoCuotas.Ejecutar(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                CargarListas();
                return View(dto);
            }
        }

        // --- Suscripcion ---
        public IActionResult CreateSuscripcion()
        {
            CargarListas();
            return View(new SuscripcionDTO { FechaProximoVencimiento = System.DateTime.Today.AddMonths(1) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSuscripcion(SuscripcionDTO dto)
        {
            if (!ModelState.IsValid) { CargarListas(); return View(dto); }
            try
            {
                dto.FechaRegistro = System.DateTime.UtcNow;
                _altaSuscripcion.Ejecutar(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                CargarListas();
                return View(dto);
            }
        }

        public IActionResult Delete(int id)
        {
            PagoDTO pago = _encontrarPorId.Ejecutar(id);
            if (pago == null) return NotFound();
            return View(pago);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _eliminar.Ejecutar(id);
            return RedirectToAction(nameof(Index));
        }

        private void CargarListas()
        {
            ViewBag.Categorias = _categorias.Ejecutar()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre }).ToList();
            ViewBag.Usuarios = _usuarios.Ejecutar()
                .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.Username }).ToList();
            ViewBag.MetodosPago = _metodosPago.Ejecutar()
                .Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Nombre }).ToList();
        }
    }
}
