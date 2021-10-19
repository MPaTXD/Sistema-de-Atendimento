using App.Interfaces;
using AutoMapper;
using Domain.ViewModel.Ordem;
using Entites.Entites;
using Entites.Enums;
using Entites.Notifys;
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
    public class OrdemController : ControllerBase
    {
        private readonly IAppOrdem _IAppOrdem;
        private readonly IMapper _mapper;

        public OrdemController(IAppOrdem IAppOrdem, IMapper mapper)
        {
            _IAppOrdem = IAppOrdem;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastrarOrdem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<OrdemNotify>>> Post(ViewModelCadastroOrdem ordem)
        {
            await _IAppOrdem.AddOrdem(ordem);
            return ordem.Notifys.Any()

                ? BadRequest (
                    new
                    {
                      ordem.Notifys,
                      Error = true
                    })
            
               : Ok (
                    new
                    {
                        Mensagem = $"O cadastro da ordem {ordem.Titulo} foi bem sucedido!"
                    });
        }

        [Produces("application/json")]
        [HttpPut("/api/EditarOrdem/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<OrdemNotify>>> Put(ViewModelCadastroOrdem ordem, int id)
        {
            var ordemExistente = await _IAppOrdem.SearchId(id);
            if (ordemExistente == null)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existe ordem cadastrada com o ID => {id}",
                        Error = true
                    });
            }
            else 
            {
                await _IAppOrdem.UpdateOrdem(ordem, id);
                return ordem.Notifys.Any()
                
                    ? BadRequest(
                        new
                        {
                            ordem.Notifys,
                            Error = true
                        })
               
                    : Ok(
                        new 
                        {
                            Mensagem = $"Ordem {ordemExistente.Titulo} editada com sucesso!"
                        });
            }
        }

        [Produces("application/json")]
        [HttpDelete("/api/ExcluirOrdem/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var ordem = await _IAppOrdem.SearchId(id);
            if (ordem == null)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existe ordem cadastrada com o ID => {id}",
                        Error = true
                    });
            }
            else
            {
                await _IAppOrdem.Delete(ordem);
                return Ok(
                    new 
                    {
                        Mensagem = $"Ordem {ordem.Titulo} foi excluida com sucesso!",
                    });
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarOrdens")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseOrdem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ViewModelBaseOrdem>>> GetOrdens()
        {
            var ordens = await _IAppOrdem.List();
            if (ordens.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = "Não existem ordens cadastradas!",
                        Error = true
                    });
            }
            else
            {
                var listaDeOrdens = _mapper.Map<List<ViewModelBaseOrdem>>(ordens);
                return Ok(listaDeOrdens);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarOrdensPorAtendimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseOrdem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ViewModelBaseOrdem>>> GetOrdensPorAtendimento(Atendimentos atendimento)
        {
            var ordens = await _IAppOrdem.ListarOrdemPeloAtendimento(atendimento);
            if (ordens.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existem ordens cadastradas do atendimento {atendimento}",
                        Error = true
                    });
            }
            else
            {
                var listaDeOrdens = _mapper.Map<List<ViewModelBaseOrdem>>(ordens);
                return Ok(listaDeOrdens);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarOrdensPorSolicitante")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseOrdem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ViewModelBaseOrdem>>> GetOrdensPorSolicitante(Solicitantes solicitante)
        {
            var ordens = await _IAppOrdem.ListarOrdemPeloSolicitante(solicitante);
            if (ordens.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existem ordens cadastradas pelo solicitante {solicitante}",
                        Error = true
                    });
            }
            else
            {
                var listaDeOrdens = _mapper.Map<List<ViewModelBaseOrdem>>(ordens);
                return Ok(listaDeOrdens);
            }
        }

        [Produces("application/json")]
        [HttpGet("/api/ListarOrdensPorStatus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewModelBaseOrdem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ViewModelBaseOrdem>>> GetOrdensPorStatus(StatusDaOrdem status)
        {
            var ordens = await _IAppOrdem.ListarOrdemPeloStatus(status);
            if (ordens.Count == 0)
            {
                return NotFound(
                    new
                    {
                        Mensagem = $"Não existem ordens cadastradas com o status {status}",
                        Error = true
                    });
            }
            else
            {
                var listaDeOrdens = _mapper.Map<List<ViewModelBaseOrdem>>(ordens);
                return Ok(listaDeOrdens);
            }
        }
    }
}
