using App.Interfaces;
using Entites.Entites;
using Entites.ViewModel;
using Entites.Notifys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ViewModel;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase {
       
        private readonly IAppOperador _IAppOperador;

        public OperadorController(IAppOperador IAppOperador) {
            _IAppOperador = IAppOperador;
        }

        [Produces("application/json")]
        [HttpPost("/api/ListarOperadores")]
        public async Task<List<ViewModelOperadorAPIBase>> ListarOperadores() {
            var list = await _IAppOperador.List();
            ViewModelOperadorAPIBase opView = new ViewModelOperadorAPIBase();
            var op = new List<ViewModelOperadorAPIBase>();
            foreach (var item in list) {
                opView.IdOperador = item.IdOperador;
                opView.Matricula_Operador = item.Matricula_Operador;
                opView.Nome_Operador = item.Nome_Operador;
                opView.TipoOperador = item.Tipo;
                op.Add(opView);
            }
            var ViewModelOperadorAPIList = new ViewModelOperadorAPIList {
                operador = op
            };
            return ViewModelOperadorAPIList.operador;
        }

        [Produces("application/json")]
        [HttpPost("/api/AdicionarOperador")]
        public async Task<List<OperadorNotify>> AdicionarOperador(ViewModelOperadorAPICadastro operador) {
            var newOp = new Operador();
            newOp.Nome_Operador = operador.Nome_Operador;
            newOp.Tipo = operador.TipoOperador;
            await _IAppOperador.AddOperador(newOp);

            return newOp.Notifys;
        }

        [Produces("application/json")]
        [HttpPost("/api/EditarOperador/{id}")]
        public async Task<List<OperadorNotify>> EditarOperador(ViewModelOperadorAPICadastro operador, int id) {
            var newOp = await _IAppOperador.SearchId(id);
            newOp.Nome_Operador = operador.Nome_Operador;
            newOp.Tipo = operador.TipoOperador;
            await _IAppOperador.UpdateOperador(newOp);

            return newOp.Notifys;
        }

        [Produces("application/json")]
        [HttpPost("/api/ExcluirOperador/{id}")]
        public async Task<List<OperadorNotify>> ExcluirOperador(int id) {
            var op = await _IAppOperador.SearchId(id);
            await _IAppOperador.Delete(op);
            return op.Notifys;
        }

        [Produces("application/json")]
        [HttpPost("/api/BuscarOperador/{id}")]
        public async Task<ViewModelOperadorAPIBase> BuscarOperador(int id) {
            var newOp = await _IAppOperador.SearchId(id);
            ViewModelOperadorAPIBase opView = new ViewModelOperadorAPIBase();
            opView.IdOperador = newOp.IdOperador;
            opView.Matricula_Operador = newOp.Matricula_Operador;
            opView.Nome_Operador = newOp.Nome_Operador;
            opView.TipoOperador = newOp.Tipo;
            return opView;
        }
    }
}
