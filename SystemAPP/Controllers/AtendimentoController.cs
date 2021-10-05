using App.Interfaces;
using Entites.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAPP.Controllers {
    public class AtendimentoController : Controller {

        public readonly IAppAtendimento _IAppAtendimento;
        public readonly IAppOperador _IAppOperador;
        public readonly IAppFormulario _IAppFormulario;
        public readonly IAppEstado _IAppEstado;
        public readonly IAppEndereco _IAppEndereco;
        public readonly IAppTelefone _IAppTelefone;
        public readonly IAppPessoaF _IAppPessoaF;
        public readonly IAppPessoaJ _IAppPessoaJ;

        public AtendimentoController(IAppAtendimento IAppAtendimento, IAppOperador IAppOperador, IAppFormulario IAppFormulario, IAppEstado IAppEstado, IAppEndereco IAppEndereco, IAppTelefone IAppTelefone, IAppPessoaF IAppPessoaF, IAppPessoaJ IAppPessoaJ) {
            _IAppAtendimento = IAppAtendimento;
            _IAppOperador = IAppOperador;
            _IAppFormulario = IAppFormulario;
            _IAppEstado = IAppEstado;
            _IAppEndereco = IAppEndereco;
            _IAppTelefone = IAppTelefone;
            _IAppPessoaF = IAppPessoaF;
            _IAppPessoaJ = IAppPessoaJ;
        }


        // GET: AtendimentoController
        public async Task<IActionResult> Index() {
            var atendimentos = await _IAppAtendimento.List();
            ViewBag.Atendimentos = atendimentos.Count();
            return View(atendimentos);
        }

        // GET: AtendimentoController/Details/5
        public async Task<IActionResult> Details(int id) {
            return View();
        }

        // GET: AtendimentoController/Create
        public async Task<IActionResult> Create() {
            return View();
        }

        // POST: AtendimentoController/CreateAtendimentoPessoaFisica
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Formulario formulario, Endereco endereco, Telefone telefone, Estado estado, PessoaF pf) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // POST: AtendimentoController/CreateAtendimentoPessoaJuridica
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Formulario formulario, Endereco endereco, Telefone telefone, Estado estado, PessoaJ pj) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: AtendimentoController/Edit/5
        public async Task<IActionResult> Edit(int id) {
            return View();
        }

        // POST: AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: AtendimentoController/Delete/5
        public async Task<IActionResult> Delete(int id) {
            return View();
        }

        // POST: AtendimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

       
        public async Task<IActionResult> GetTipoFormulario(string collection) {
            //var s = tipo;
            return View("Create");
        }
    }
}
