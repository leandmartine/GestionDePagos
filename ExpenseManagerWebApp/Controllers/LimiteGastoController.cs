using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CasosUso.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.LimitesGasto;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManagerWebApp.Controllers
{
    public class LimiteGastoController : Controller
    {
        private readonly IEncontrarTodosLimitesGasto _encontrarTodos;
        private readonly IAltaLimiteGasto _alta;
        private readonly IEncontrarLimiteGastoPorId _encontrarPorId;
        private readonly IEliminarLimiteGasto _eliminar;
        private readonly IEncontrarTodasCategorias _categorias;
        private readonly IEncontrarTodosUsuarios _usuarios;

        public LimiteGastoController(
            IEncontrarTodosLimitesGasto encontrarTodos,
            IAltaLimiteGasto alta,
            IEncontrarLimiteGastoPorId encontrarPorId,
            IEliminarLimiteGasto eliminar,
            IEncontrarTodasCategorias categorias,
            IEncontrarTodosUsuarios usuarios)
        {
            _encontrarTodos = encontrarTodos;
            _alta = alta;
            _encontrarPorId = encontrarPorId;
            _eliminar = eliminar;
            _categorias = categorias;
            _usuarios = usuarios;
        }

        public IActionResult Index()
        {
            try
            {
                var lista = _encontrarTodos.Ejecutar().ToList();
                var cats = _categorias.Ejecutar().ToDictionary(c => c.Id, c => c.Nombre);
                var users = _usuarios.Ejecutar().ToDictionary(u => u.Id, u => u.Username);

                foreach (var item in lista)
                {
                    item.NombreCategoria = cats.TryGetValue(item.CategoriaId, out var cn) ? cn : "-";
                    item.UsernameUsuario = users.TryGetValue(item.UsuarioId, out var un) ? un : "-";
                }

                return View(lista);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<LimiteGastoDTO>());
            }
        }

        public IActionResult Create()
        {
            CargarListas();
            return View(new LimiteGastoDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LimiteGastoDTO dto)
        {
            if (!ModelState.IsValid) { CargarListas(); return View(dto); }
            try
            {
                _alta.Ejecutar(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                CargarListas();
                return View(dto);
            }
        }

        public IActionResult Details(int id)
        {
            LimiteGastoDTO dto = _encontrarPorId.Ejecutar(id);
            if (dto == null) return NotFound();

            var cats = _categorias.Ejecutar().ToDictionary(c => c.Id, c => c.Nombre);
            var users = _usuarios.Ejecutar().ToDictionary(u => u.Id, u => u.Username);
            dto.NombreCategoria = cats.TryGetValue(dto.CategoriaId, out var cn) ? cn : "-";
            dto.UsernameUsuario = users.TryGetValue(dto.UsuarioId, out var un) ? un : "-";

            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            LimiteGastoDTO dto = _encontrarPorId.Ejecutar(id);
            if (dto == null) return NotFound();

            var cats = _categorias.Ejecutar().ToDictionary(c => c.Id, c => c.Nombre);
            var users = _usuarios.Ejecutar().ToDictionary(u => u.Id, u => u.Username);
            dto.NombreCategoria = cats.TryGetValue(dto.CategoriaId, out var cn) ? cn : "-";
            dto.UsernameUsuario = users.TryGetValue(dto.UsuarioId, out var un) ? un : "-";

            return View(dto);
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
        }
    }
}
