using App.Interfaces;
using AutoMapper;
using Domain.ViewModel.Atendimento;
using Domain.ViewModel.Ordem;
using Entites.Entites;
using Entites.Enums;
using Entites.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAppAtendimento _IAppAtendimento;
        private readonly IAppOrdem _IAppOrdem;
        private readonly IAppFuncionario _IAppFuncionario;
        private readonly IMapper _mapper;

        public AtendimentoController(IAppAtendimento IAppAtendimento, IAppOrdem IAppOrdem, IAppFuncionario IAppFuncionario, IMapper mapper)
        {
            _IAppAtendimento = IAppAtendimento;
            _IAppFuncionario = IAppFuncionario;
            _IAppOrdem = IAppOrdem;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastrarAtendimento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ViewModelCadastroAtendimento>> Post(int ordemId, int funcionarioId)
        {
            var funcionario = await _IAppFuncionario.SearchId(funcionarioId);
            var ordem = await _IAppOrdem.SearchId(ordemId);
            if (ordem.Status != StatusDaOrdem.DISPONIVEL) 
            {
                return BadRequest(
                    new
                    {
                        Mensagem = $"A ordem com ID => {ordemId} se encontrar Indisponivel ou foi Concluida!",
                        Error = true
                    });
            }else
            await _IAppAtendimento.AddAtendimento(ordem, funcionario);
            await _IAppOrdem.AlterarStatusDaOrdem(ordem);
            return Ok(
                new
                {
                    Mensagem = "Atendimento cadastrado com sucesso!"
                });
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarAtendimentos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseAtendimento))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ViewModelBaseAtendimento>>> GetListarAtendimentos()
        {
            var atendimentos = await _IAppAtendimento.ListarAtendimentos();
            if (atendimentos.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = "Não existem atendimentos cadastrados!",
                        Error = true
                    });
            }
            else
            {
                var listaDeAtendimentos =  _mapper.Map<List<ViewModelBaseAtendimento>>(atendimentos);
                return Ok(listaDeAtendimentos);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarAtendimentosPeloStatus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseAtendimento))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ViewModelBaseAtendimento>>> GetListarAtendimentosPeloStatus(StatusDoAtendimento status)
        {
            var atendimentos = await _IAppAtendimento.ListarAtendimentosPeloStatus(status);
            if (atendimentos.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existem atendimentos cadastrados com o status {status}!",
                        Error = true
                    });
            }
            else
            {
                var listaDeAtendimentos = _mapper.Map<List<ViewModelBaseAtendimento>>(atendimentos);
                return Ok(listaDeAtendimentos);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarAtendimentoPeloProtocolo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseAtendimento))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ViewModelBaseAtendimento>> GetListarAtendimentoPeloProtocolo(long protocolo)
        {
            var atendimentoExistente = await _IAppAtendimento.ListarAtendimentosPeloProtocolo(protocolo);
            if (atendimentoExistente == null)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existem atendimento com o protocolo {protocolo}",
                        Error = true
                    });
            }
            else
            {
                var atendimento = _mapper.Map<ViewModelBaseAtendimento>(atendimentoExistente);
                return Ok(atendimento);
            }
        }
    }
}
