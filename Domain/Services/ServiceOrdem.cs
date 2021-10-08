
using Domain.Interfaces.InterfaceOrdem;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
    public class ServiceOrdem : IServiceOrdem {

        private readonly IOrdem _IOrdem;
       
        public ServiceOrdem(IOrdem IOrdem) {
            _IOrdem = IOrdem;
        }

        public async Task AddOrdem(Ordem Ordem) {
            await _IOrdem.Add(Ordem);
        }

        public async Task<List<Ordem>> ListOrdem() {
            throw new NotImplementedException();
        }

        public async Task UpdateOrdem(Ordem Ordem) {
            throw new NotImplementedException();
        }
    }
}
