﻿
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacesServices;
using Domain.ViewModel.Ordem;
using Entites.Entites;
using Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceOrdem : IServiceOrdem 
    {

        private readonly IOrdem _IOrdem;
       
        public ServiceOrdem(IOrdem IOrdem) 
        {
            _IOrdem = IOrdem;
        }

        public async Task AddOrdem(ViewModelCadastroOrdem ordem)
        {
            if (ValidarDadosDaOrdem(ordem))
            {
                var novaOrdem = CriarOrdem(ordem);
                await _IOrdem.Add(novaOrdem);
            }
        }
        public async Task UpdateOrdem(ViewModelCadastroOrdem ordem, int id) 
        {
            if (ValidarDadosDaOrdem(ordem))
            {
                var ordemExistente = await _IOrdem.SearchId(id);
                var ordemAtualizada = AlterarOrdem(ordem, ordemExistente);
                await _IOrdem.Update(ordemAtualizada);
            }
        }
        public async Task AlterarStatusDaOrdem(Ordem ordem)
        {
            ordem.Status = StatusDaOrdem.INDISPONIVEL;
            await _IOrdem.Update(ordem);
        }
        public Ordem CriarOrdem (ViewModelCadastroOrdem ordem)
        {
            var novaOrdem = new Ordem
            {
                Atendimento = ordem.Atendimento,
                Titulo = ordem.Titulo,
                Descricao = ordem.Descricao,
                Solicitante = ordem.Solicitante,
                DataDeLancamento = GerarData(),
                Status = StatusDaOrdem.DISPONIVEL
            };
            return novaOrdem;
        }
        public Ordem AlterarOrdem(ViewModelCadastroOrdem ordem, Ordem ordemExistente)
        {
            var ordemAtualizada = new Ordem
            {
                IdOrdem = ordemExistente.IdOrdem,
                Atendimento = ordem.Atendimento,
                Titulo = ordem.Titulo,
                Descricao = ordem.Descricao,
                Solicitante = ordem.Solicitante,
                DataDeLancamento = ordemExistente.DataDeLancamento
            };
            return ordemAtualizada;
        }
        public bool ValidarDadosDaOrdem(ViewModelCadastroOrdem ordem)
        {
            var validarTituloDaOrdem = ordem.ValidarTituloDaOrdem(ordem.Titulo);
            var validarAtendimentoDaOrdem = ordem.ValidarAtendimentoDaOrdem((int)ordem.Atendimento);
            var validarDescricaoDaOrdem = ordem.ValidarDescricaoDaOrdem(ordem.Descricao);
            var validarSolicitanteDaOrdem = ordem.ValidarSolicitanteDaOrdem((int)ordem.Solicitante);

            if (validarTituloDaOrdem && validarAtendimentoDaOrdem && validarDescricaoDaOrdem && validarSolicitanteDaOrdem)
            {
                return true;
            }
            return false;
        }
        public DateTime GerarData()
        {
            var data = DateTime.Now;
            return data;
        }
        public async Task<List<Ordem>> ListarOrdemPeloAtendimento(Atendimentos atendimento)
        {
            return await _IOrdem.ListarOrdemPeloAtendimento(ordem => ordem.Atendimento == atendimento);
        }
        public async Task<List<Ordem>> ListarOrdemPeloStatus(StatusDaOrdem statusDaOrdem)
        {
            return await _IOrdem.ListarOrdemPeloStatus(ordem => ordem.Status == statusDaOrdem);
        }
        public async Task<List<Ordem>> ListarOrdemPeloSolicitante(Solicitantes solicitante)
        {
            return await _IOrdem.ListarOrdemPeloSolicitante(ordem => ordem.Solicitante == solicitante);
        }
    }
}

