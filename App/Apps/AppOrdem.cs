using App.Interfaces;
using Domain.Interfaces.InterfaceOrdem;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
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

        public async Task AddOrdem(Ordem ordem) {
            await _IServiceOrdem.AddOrdem(ordem);
        }
        public async Task UpdateOrdem(Ordem ordem) {
            await _IServiceOrdem.UpdateOrdem(ordem);
        }

        public async Task Add(Ordem Object) {
            await _IOrdem.Add(Object);
        }

        public async Task Delete(Ordem Object) {
            await _IOrdem.Delete(Object);
        }

        public async Task<List<Ordem>> List() {
            return await _IOrdem.List();
        }

        public async Task<Ordem> SearchId(int Id) {
            return await _IOrdem.SearchId(Id);
        }

        public async Task Update(Ordem Object) {
            await _IOrdem.Update(Object);
        }
    }
}
