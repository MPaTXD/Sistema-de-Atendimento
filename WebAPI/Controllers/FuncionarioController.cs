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
        [HttpPost("/api/CadastrarFuncionario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<FuncionarioNotify>>> Post(ViewModelCadastroFuncionario funcionario)
        {
            var novoFuncionario = new Funcionario
            {
                Nome = funcionario.Nome,
                Atendimento = funcionario.Atendimento
            };
            await _IAppFuncionario.AddFuncionario(novoFuncionario);
            if (novoFuncionario.Notifys.Any())
            {
                return BadRequest(
                    new
                    {
                        novoFuncionario.Notifys,
                        Error = true
                    });
            }
            else
                return Ok(
                    new
                    {
                        Mensagem = $"Funcionario {funcionario.Nome} cadastrado com sucesso!"
                    });

        }

        [Produces("application/json")]
        [HttpPut("/api/EditarFuncionario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FuncionarioNotify>>> Put(int id, ViewModelCadastroFuncionario funcionario)
        {
            var funcionarioExistente = await _IAppFuncionario.BuscarFuncionarioPeloId(id);
            if (funcionarioExistente == null)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existe funcionario cadastrado com o ID : {id}",
                        Error = true
                    });
            }
            else
            {
                var funcionarioEditado = new Funcionario
                {
                    IdFuncionario = funcionarioExistente.IdFuncionario,
                    Nome = funcionario.Nome,
                    Atendimento = funcionario.Atendimento
                };
                await _IAppFuncionario.UpdateFuncionario(funcionarioEditado);
                if (funcionarioEditado.Notifys.Any())
                {
                    return BadRequest(
                        new
                        {
                            funcionarioEditado.Notifys,
                            Error = true
                        });
                }
                else
                    return Ok(
                        new
                        {
                            Mensagem = $"O cadastro do funcionario {funcionarioExistente.Nome} foi editado com sucesso!"
                        });

            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarFuncionarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseFuncionario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FuncionarioNotify>>> GetListaDeFuncionarios()
        {
            var funcionarios = await _IAppFuncionario.List();
            if (funcionarios.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existe funcionários cadastrados no sistema!",
                        Error = true
                    });
            }
            else
            {
                var listaDeFuncionarios = new List<ViewModelBaseFuncionario>();
                foreach (var objetoFuncionario in funcionarios)
                {
                    var funcionario = new ViewModelBaseFuncionario();
                    funcionario.IdFuncionario = objetoFuncionario.IdFuncionario;
                    funcionario.Nome = objetoFuncionario.Nome;
                    funcionario.Matricula = objetoFuncionario.Matricula;
                    funcionario.Atendimento = objetoFuncionario.Atendimento;
                    listaDeFuncionarios.Add(funcionario);
                }
                return Ok(listaDeFuncionarios);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/BuscarFuncionarioPeloId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseFuncionario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FuncionarioNotify>>> GetFuncionarioPeloId(int id)
        {
            var funcionario = await _IAppFuncionario.BuscarFuncionarioPeloId(id);
            if (funcionario == null)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existe funcionário com o ID : {id}",
                        Error = true
                    });
            }
            else
            {
                var funcionarioEncontrado = new ViewModelBaseFuncionario();

                funcionarioEncontrado.IdFuncionario = funcionario.IdFuncionario;
                funcionarioEncontrado.Nome = funcionario.Nome;
                funcionarioEncontrado.Matricula = funcionario.Matricula;
                funcionarioEncontrado.Atendimento = funcionario.Atendimento;

                return Ok(funcionarioEncontrado);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/BuscarFuncionarioPeloAtendimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseFuncionario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FuncionarioNotify>>> GetFuncionarioPeloAtendimento(Atendimentos atendimento)
        {
            var funcionarios = await _IAppFuncionario.ListarFuncionariosPeloAtendimento(atendimento);
            if (funcionarios.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existe funcionário do atendimento {atendimento} cadastrados no sistema!",
                        Error = true
                    });
            }
            else
            {
                var listaDeFuncionarios = new List<ViewModelBaseFuncionario>();
                foreach (var objetoFuncionario in funcionarios)
                {
                    var funcionario = new ViewModelBaseFuncionario();
                    funcionario.IdFuncionario = objetoFuncionario.IdFuncionario;
                    funcionario.Nome = objetoFuncionario.Nome;
                    funcionario.Matricula = objetoFuncionario.Matricula;
                    funcionario.Atendimento = objetoFuncionario.Atendimento;
                    listaDeFuncionarios.Add(funcionario);
                }
                return Ok(listaDeFuncionarios);
            }
        }
    }
}
