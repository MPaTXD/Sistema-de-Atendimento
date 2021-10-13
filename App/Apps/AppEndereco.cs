using App.Interfaces;
using Domain.Interfaces.InterfaceEndereco;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppEndereco : IAppEndereco {

        IEndereco _IEndereco;
        IServiceEndereco _IServiceEndereco;

        public AppEndereco(IEndereco IEndereco, IServiceEndereco IServiceEndereco) {
            _IEndereco = IEndereco;
            _IServiceEndereco = IServiceEndereco;
        }

        public async Task AddEndereco(Endereco endereco) {
            await _IServiceEndereco.AddEndereco(endereco);
        }
        public async Task UpdateEndereco(Endereco endereco) {
            await _IServiceEndereco.UpdateEndereco(endereco);
        }


        public async Task Add(Endereco Object) {
            await _IEndereco.Add(Object);
        }

        public async Task Delete(Endereco Object) {
            await _IEndereco.Delete(Object);
        }

        public async Task<List<Endereco>> List() {
            return await _IEndereco.List();
        }

        public async Task<Endereco> SearchId(int Id) {
            return await _IEndereco.SearchId(Id);
        }

        public async Task Update(Endereco Object) {
            await _IEndereco.Update(Object);
        }
    }
}
