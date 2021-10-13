using App.Interfaces;
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacesServices;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Apps {
    public class AppOrdem : IAppOrdem {

        IOrdem _IFormulario;
        IServiceOrdem _IServiceFormulario;

        public AppOrdem(IOrdem IFormulario, IServiceOrdem IServiceFormulario) {
            _IFormulario = IFormulario;
            _IServiceFormulario = IServiceFormulario;
        }

        public async Task AddFormulario(Ordem formulario) {
            await _IServiceFormulario.AddFormulario(formulario);
        }
        public async Task UpdateFormulario(Ordem formulario) {
            await _IServiceFormulario.UpdateFormulario(formulario);
        }

        public async Task Add(Ordem Object) {
            await _IFormulario.Add(Object);
        }

        public async Task Delete(Ordem Object) {
            await _IFormulario.Delete(Object);
        }

        public async Task<List<Ordem>> List() {
            return await _IFormulario.List();
        }

        public async Task<Ordem> SearchId(int Id) {
            return await _IFormulario.SearchId(Id);
        }

        public async Task Update(Ordem Object) {
            await _IFormulario.Update(Object);
        }
    }
}
