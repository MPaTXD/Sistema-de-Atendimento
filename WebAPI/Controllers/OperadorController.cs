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
using Entites.Enums;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase {
       
        private readonly IAppOperador _IAppOperador;

        public OperadorController(IAppOperador IAppOperador) {
            _IAppOperador = IAppOperador;
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarOperadores")]
        public async Task<List<ViewModelOperadorAPIBase>> ListarOperadores() {
            var list = await _IAppOperador.List();
            var op = new ViewModelOperadorAPIList();
            op.Operador = new List<ViewModelOperadorAPIBase>();

            foreach (var item in list) {
                var opView = new ViewModelOperadorAPIBase();
                opView.IdOperador = item.IdOperador;
                opView.Matricula_Operador = item.Matricula_Operador;
                opView.Nome_Operador = item.Nome_Operador;
                opView.Atendimento = item.Atendimento;
                op.Operador.Add(opView);
            }
            
            return op.Operador;
        }

        [Produces("application/json")]
        [HttpPost("/api/AdicionarOperador")]
        public async Task<List<OperadorNotify>> AdicionarOperador(ViewModelOperadorAPICadastro operador) {
            var newOp = new Operador {
                Nome_Operador = operador.Nome_Operador,
                Atendimento = operador.Atendimento
            };
            await _IAppOperador.AddOperador(newOp);
            return newOp.Notifys;
        }

        [Produces("application/json")]
        [HttpPut("/api/EditarOperador/{id}")]
        public async Task<List<OperadorNotify>> EditarOperador(ViewModelOperadorAPICadastro operador, int id) {
            var newOp = await _IAppOperador.SearchId(id);
            newOp.Nome_Operador = operador.Nome_Operador;
            newOp.Atendimento = operador.Atendimento;
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
        [HttpGet("/api/BuscarOperador/{id}")]
        public async Task<ViewModelOperadorAPIBase> BuscarOperador(int id) {
            var newOp = await _IAppOperador.SearchId(id);
            ViewModelOperadorAPIBase opView = new ViewModelOperadorAPIBase();
            opView.IdOperador = newOp.IdOperador;
            opView.Matricula_Operador = newOp.Matricula_Operador;
            opView.Nome_Operador = newOp.Nome_Operador;
            opView.Atendimento = newOp.Atendimento;
            return opView;
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarAtendimentos")]
        public async Task<List<EnumModel>> ListarAtendimento()
        {
            List<EnumModel> Atendimentos = ((AreaAtendimento[])Enum.GetValues(typeof(AreaAtendimento))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();

            return Atendimentos;
        }
    }
}
