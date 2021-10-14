using App.Interfaces;
using Domain.ViewModel.Ordem;
using Entites.Entites;
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

        public OrdemController(IAppOrdem IAppOrdem)
        {
            _IAppOrdem = IAppOrdem;
        }

        [Produces("application/json")]
        [HttpPost("/api/CadastrarOrdem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<OrdemNotify>>> Post(ViewModelCadastroOrdem ordem)
        {
            var novaOrdem = new Ordem
            {
                Atendimento = ordem.Atendimento,
                Titulo = ordem.Titulo,
                Descricao = ordem.Descricao,
                Solicitante = ordem.Solicitante
            };
            await _IAppOrdem.AddOrdem(novaOrdem);
            if (novaOrdem.Notifys.Any())
            {
                return BadRequest(new
                {
                    novaOrdem.Notifys,
                    Error = true
                });
            }
            else
            {
                return Ok(
                    new
                    {
                        Mensagem = $"O cadastro da ordem {novaOrdem.Titulo} foi bem sucedido!"
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
                var listaDeOrdens = new List<ViewModelBaseOrdem>();
                foreach (var objetoOrdem in ordens)
                {
                    var ordem = new ViewModelBaseOrdem();
                    ordem.IdOrdem = objetoOrdem.IdOrdem;
                    ordem.Titulo = objetoOrdem.Titulo;
                    ordem.Descricao = objetoOrdem.Descricao;
                    ordem.Atendimento = objetoOrdem.Atendimento;
                    ordem.Status = objetoOrdem.Status;
                    ordem.Solicitante = objetoOrdem.Solicitante;
                    ordem.DataDeLancamento = objetoOrdem.DataDeLancamento;
                    ordem.DataDeConclusao = objetoOrdem.DataDeConclusao;

                    listaDeOrdens.Add(ordem);
                }
                return Ok(listaDeOrdens);
            }
        }
    }
}
