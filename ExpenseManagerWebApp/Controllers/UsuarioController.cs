using Microsoft.AspNetCore.Mvc;
using CasosUso.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using System.Collections.Generic;

namespace ExpenseManagerWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IEncontrarTodosUsuarios _encontrarTodos;
        private readonly IAltaUsuario _altaUsuario;
        private readonly IEncontrarUsuarioPorId _encontrarPorId;
        private readonly IEditarUsuario _editar;
        private readonly IEliminarUsuario _eliminar;

        public UsuarioController(
            IEncontrarTodosUsuarios encontrarTodos,
            IAltaUsuario altaUsuario,
            IEncontrarUsuarioPorId encontrarPorId,
            IEditarUsuario editar,
            IEliminarUsuario eliminar)
        {
            _encontrarTodos = encontrarTodos;
            _altaUsuario = altaUsuario;
            _encontrarPorId = encontrarPorId;
            _editar = editar;
            _eliminar = eliminar;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<UsuarioDTO> lista = _encontrarTodos.Ejecutar();
                return View(lista);
            }
            catch (System.Data.Common.DbException)
            {
                ViewBag.ErrorMessage = "No existe la Base de datos, recuerda inicializarla con update-database";
                return View(new List<UsuarioDTO>());
            }
            catch (System.Exception ex)
            {
                string message = ex.Message ?? string.Empty;
                if (message.IndexOf("cannot open database", System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    message.IndexOf("database .* does not exist", System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                    message.IndexOf("login failed", System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ViewBag.ErrorMessage = "No existe la Base de datos, recuerda inicializarla con update-database";
                    return View(new List<UsuarioDTO>());
                }
                throw;
            }
        }

        public IActionResult Create()
        {
            return View(new UsuarioDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);
            try
            {
                _altaUsuario.Ejecutar(dto);
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
            UsuarioDTO usuario = _encontrarPorId.Ejecutar(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        public IActionResult Edit(int id)
        {
            UsuarioDTO usuario = _encontrarPorId.Ejecutar(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UsuarioDTO dto)
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
            UsuarioDTO usuario = _encontrarPorId.Ejecutar(id);
            if (usuario == null) return NotFound();
            return View(usuario);
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
