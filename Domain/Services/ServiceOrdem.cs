
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacesServices;
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

        public async Task AddOrdem(Ordem ordem)
        {
            if (ValidarDadosDaOrdem(ordem))
            {
                ordem.DataDeLancamento = GerarData();
                ordem.Status = StatusDaOrdem.DISPONIVEL;
                await _IOrdem.Add(ordem);
            }
        }
        public async Task UpdateOrdem(Ordem ordem) 
        {
            if (ValidarDadosDaOrdem(ordem))
            {
                await _IOrdem.Update(ordem);
            }
        }

        public bool ValidarDadosDaOrdem(Ordem ordem)
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
