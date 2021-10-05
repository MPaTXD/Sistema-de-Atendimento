using App.Interfaces;
using Entites.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAPP.Controllers {
    public class OperadorController : Controller {

        public readonly IAppOperador _IAppOperador;

        public OperadorController(IAppOperador IAppOperador) {
            _IAppOperador = IAppOperador;
        }

        // GET: OperadorController
        public async Task<IActionResult> Index() {
            
            var list = await _IAppOperador.List();
            ViewBag.Operadores = list.Count();
            return View(list);
        }

        // GET: OperadorController/Details/5
        public async Task<IActionResult> Details(int id) {
            var operador = await _IAppOperador.SearchId(id);
            return View(operador);
        }

        // GET: OperadorController/Create
        public async Task<IActionResult> Create() {
            
            return View();
        }

        // POST: OperadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Operador operador) {
            try {
                await _IAppOperador.AddOperador(operador);
                if (operador.Notifys.Any()) {
                    foreach (var item in operador.Notifys) {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    return View("Create", operador);
                }
            }
            catch {
                return View("Create", operador);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OperadorController/Edit/5
        public async Task<IActionResult> Edit(int id) {
            var operador = await _IAppOperador.SearchId(id);
            return View(operador);
        }

        // POST: OperadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Operador operador) {
            try {
                await _IAppOperador.UpdateOperador(operador);
                if (operador.Notifys.Any()) {
                    foreach (var item in operador.Notifys) {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    return View("Edit", operador);
                }
            }
            catch {
                return View("Edit", operador);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: OperadorController/Delete/5
        public async Task<IActionResult> Delete(int id) {
            var operador = await _IAppOperador.SearchId(id);
            ViewBag.Operador = operador;
            return View(operador);
        }

        // POST: OperadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Operador operador) {
            try {
                await _IAppOperador.Delete(operador);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
