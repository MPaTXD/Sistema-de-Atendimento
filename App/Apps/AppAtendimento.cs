using App.Interfaces;
using Domain.Interfaces.InterfaceAtendimento;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppAtendimento : IAppAtendimento {

        IAtendimento _IAtendimento;
        IServiceAtendimento _IServiceAtendimento;

        public AppAtendimento(IAtendimento IAtendimento, IServiceAtendimento IServiceAtendimento) {
            _IAtendimento = IAtendimento;
            _IServiceAtendimento = IServiceAtendimento;
        }

        public async Task AddAtendimento(Atendimento atendimento, Ordem ordem, Funcionario funcionario) {
            await _IServiceAtendimento.AddAtendimento(atendimento, ordem, funcionario);
        }
        public async Task<List<Atendimento>> ListarAtendimentos() {
            return await _IAtendimento.ListarAtendimentos();
        }

        public async Task Add(Atendimento Object) {
            await _IAtendimento.Add(Object);
        }
        public async Task Update(Atendimento Object) {
            await _IAtendimento.Update(Object);
        }

        public async Task Delete(Atendimento Object) {
            await _IAtendimento.Delete(Object);
        }

        public async Task<List<Atendimento>> List() {
            return await _IAtendimento.List();
        }

        public async Task<Atendimento> SearchId(int Id) {
            return await _IAtendimento.SearchId(Id);
        }

        public Task<bool> VerificarAtendimentoPeloProtocolo(long protocolo)
        {
            throw new NotImplementedException();
        }
    }
}
