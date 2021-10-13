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
    public class FuncionarioController : ControllerBase
    {

        private readonly IAppFuncionario _IAppFuncionario;

        public FuncionarioController(IAppFuncionario IAppFuncionario)
        {
            _IAppFuncionario = IAppFuncionario;
        }

        [Produces("application/json")]
        [HttpPost("/api/AdicionarOperador")]
        public async Task<ActionResult<List<FuncionarioNotify>>> Post(ViewModelCadastroFuncionario funcionario)
        {
            var NovoFuncionario = new Funcionario
            {
                Nome = funcionario.Nome,
                Atendimento = funcionario.Atendimento
            };
            await _IAppFuncionario.AddFuncionario(NovoFuncionario);
            if (NovoFuncionario.Notifys.Any())
            {
                return BadRequest(
                    new
                    {
                        NovoFuncionario.Notifys,
                        Error = true
                    });
            }

        }
    }
}
