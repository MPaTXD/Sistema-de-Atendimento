using App.Interfaces;
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

namespace App.Apps {
    public class AppOrdem : IAppOrdem {

        IOrdem _IOrdem;
        IServiceOrdem _IServiceOrdem;

        public AppOrdem(IOrdem IOrdem, IServiceOrdem IServiceOrdem) {
            _IOrdem = IOrdem;
            _IServiceOrdem = IServiceOrdem;
        }

        public async Task AddOrdem(ViewModelCadastroOrdem ordem) {
            await _IServiceOrdem.AddOrdem(ordem);
        }
        public async Task UpdateOrdem(ViewModelCadastroOrdem ordem, int id)
        {
            await _IServiceOrdem.UpdateOrdem(ordem, id);
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
        public async Task Add(Ordem Object) 
        {
            await _IOrdem.Add(Object);
        }
        public async Task Delete(Ordem Object) 
        {
            await _IOrdem.Delete(Object);
        }
        public async Task<List<Ordem>> List() 
        {
            return await _IOrdem.List();
        }
        public async Task<Ordem> SearchId(int Id) 
        {
            return await _IOrdem.SearchId(Id);
        }
        public async Task Update(Ordem Object) 
        {
            await _IOrdem.Update(Object);
        }
    }
}
