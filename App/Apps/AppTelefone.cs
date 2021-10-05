using App.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Domain.Interfaces.InterfaceTelefone;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppTelefone : IAppTelefone {

        ITelefone _ITelefone;
        IServiceTelefone _IServiceTelefone;

        public AppTelefone(ITelefone ITelefone, IServiceTelefone IServiceTelefone) {
            _ITelefone = ITelefone;
            _IServiceTelefone = IServiceTelefone;
        }

        public async Task AddTelefone(Telefone telefone) {
            await _IServiceTelefone.AddTelefone(telefone);
        }
        public async Task UpdateTelefone(Telefone telefone) {
            await _IServiceTelefone.UpdateTelefone(telefone);
        }
        public async Task Add(Telefone Object) {
            await _ITelefone.Add(Object);
        }

        public async Task Delete(Telefone Object) {
            await _ITelefone.Delete(Object);
        }

        public async Task<List<Telefone>> List() {
            return await _ITelefone.List();
        }

        public async Task<Telefone> SearchId(int Id) {
            return await _ITelefone.SearchId(Id);
        }

        public async Task Update(Telefone Object) {
            await _ITelefone.Update(Object);
        }
    }
}
