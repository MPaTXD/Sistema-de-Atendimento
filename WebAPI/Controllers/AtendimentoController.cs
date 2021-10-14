using App.Interfaces;
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

        public AtendimentoController(IAppAtendimento IAppAtendimento, IAppOrdem IAppOrdem, IAppFuncionario IAppFuncionario)
        {
            _IAppAtendimento = IAppAtendimento;
            _IAppFuncionario = IAppFuncionario;
            _IAppOrdem = IAppOrdem;
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
                var listaDeAtendimentos = new List<ViewModelBaseAtendimento>();
                foreach (var objetoAtendimento in atendimentos)
                {
                    var atendimento = new ViewModelBaseAtendimento();
                    atendimento.Ordem = new ViewModelBaseOrdem();
                    atendimento.Funcionario = new ViewModelBaseFuncionario();

                    atendimento.IdAtendimento = objetoAtendimento.IdAtendimento;
                    atendimento.Protocolo = objetoAtendimento.Protocolo;
                    atendimento.Status = objetoAtendimento.Status;
                    atendimento.DataDeLancamento = objetoAtendimento.DataDeLancamento;
                    atendimento.DataDeConclusao = objetoAtendimento.DataDeConclusao;

                    atendimento.Ordem.IdOrdem = objetoAtendimento.Ordem.IdOrdem;
                    atendimento.Ordem.Atendimento = objetoAtendimento.Ordem.Atendimento;
                    atendimento.Ordem.Titulo = objetoAtendimento.Ordem.Titulo;
                    atendimento.Ordem.Descricao = objetoAtendimento.Ordem.Descricao;
                    atendimento.Ordem.Solicitante = objetoAtendimento.Ordem.Solicitante;
                    atendimento.Ordem.Status = objetoAtendimento.Ordem.Status;
                    atendimento.Ordem.DataDeLancamento = objetoAtendimento.Ordem.DataDeLancamento;
                    atendimento.Ordem.DataDeConclusao = objetoAtendimento.Ordem.DataDeConclusao;

                    atendimento.Funcionario.IdFuncionario = objetoAtendimento.Funcionario.IdFuncionario;
                    atendimento.Funcionario.Matricula = objetoAtendimento.Funcionario.Matricula;
                    atendimento.Funcionario.Nome = objetoAtendimento.Funcionario.Nome;
                    atendimento.Funcionario.Atendimento = objetoAtendimento.Funcionario.Atendimento;

                    listaDeAtendimentos.Add(atendimento);
                }
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
                var atendimento = new ViewModelBaseAtendimento();
                atendimento.Ordem = new ViewModelBaseOrdem();
                atendimento.Funcionario = new ViewModelBaseFuncionario();

                atendimento.IdAtendimento = atendimentoExistente.IdAtendimento;
                atendimento.Protocolo = atendimentoExistente.Protocolo;
                atendimento.Status = atendimentoExistente.Status;
                atendimento.DataDeLancamento = atendimentoExistente.DataDeLancamento;
                atendimento.DataDeConclusao = atendimentoExistente.DataDeConclusao;

                atendimento.Ordem.IdOrdem = atendimentoExistente.Ordem.IdOrdem;
                atendimento.Ordem.Atendimento = atendimentoExistente.Ordem.Atendimento;
                atendimento.Ordem.Titulo = atendimentoExistente.Ordem.Titulo;
                atendimento.Ordem.Descricao = atendimentoExistente.Ordem.Descricao;
                atendimento.Ordem.Solicitante = atendimentoExistente.Ordem.Solicitante;
                atendimento.Ordem.Status = atendimentoExistente.Ordem.Status;
                atendimento.Ordem.DataDeLancamento = atendimentoExistente.Ordem.DataDeLancamento;
                atendimento.Ordem.DataDeConclusao = atendimentoExistente.Ordem.DataDeConclusao;

                atendimento.Funcionario.IdFuncionario = atendimentoExistente.Funcionario.IdFuncionario;
                atendimento.Funcionario.Matricula = atendimentoExistente.Funcionario.Matricula;
                atendimento.Funcionario.Nome = atendimentoExistente.Funcionario.Nome;
                atendimento.Funcionario.Atendimento = atendimentoExistente.Funcionario.Atendimento;

                return Ok(atendimento);
            }
        }
    }
}
