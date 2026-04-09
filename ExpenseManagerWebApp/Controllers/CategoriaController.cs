using Microsoft.AspNetCore.Mvc;
using CasosUso.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using System.Collections.Generic;

namespace ExpenseManagerWebApp.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IEncontrarTodasCategorias _encontrarTodas;
        private readonly IAltaCategoria _alta;
        private readonly IEncontrarCategoriaPorId _encontrarPorId;
        private readonly IEditarCategoria _editar;
        private readonly IEliminarCategoria _eliminar;

        public CategoriaController(
            IEncontrarTodasCategorias encontrarTodas,
            IAltaCategoria alta,
            IEncontrarCategoriaPorId encontrarPorId,
            IEditarCategoria editar,
            IEliminarCategoria eliminar)
        {
            _encontrarTodas = encontrarTodas;
            _alta = alta;
            _encontrarPorId = encontrarPorId;
            _editar = editar;
            _eliminar = eliminar;
        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<CategoriaDTO> lista = _encontrarTodas.Ejecutar();
                return View(lista);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<CategoriaDTO>());
            }
        }

        public IActionResult Create()
        {
            return View(new CategoriaDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaDTO dto)
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
            CategoriaDTO cat = _encontrarPorId.Ejecutar(id);
            if (cat == null) return NotFound();
            return View(cat);
        }

        public IActionResult Edit(int id)
        {
            CategoriaDTO cat = _encontrarPorId.Ejecutar(id);
            if (cat == null) return NotFound();
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaDTO dto)
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
            CategoriaDTO cat = _encontrarPorId.Ejecutar(id);
            if (cat == null) return NotFound();
            return View(cat);
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
