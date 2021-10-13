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
    public class AppFormulario : IAppFormulario {

        IFormulario _IFormulario;
        IServiceFormulario _IServiceFormulario;

        public AppFormulario(IFormulario IFormulario, IServiceFormulario IServiceFormulario) {
            _IFormulario = IFormulario;
            _IServiceFormulario = IServiceFormulario;
        }

        public async Task AddFormulario(Formulario formulario) {
            await _IServiceFormulario.AddFormulario(formulario);
        }
        public async Task UpdateFormulario(Formulario formulario) {
            await _IServiceFormulario.UpdateFormulario(formulario);
        }

        public async Task Add(Formulario Object) {
            await _IFormulario.Add(Object);
        }

        public async Task Delete(Formulario Object) {
            await _IFormulario.Delete(Object);
        }

        public async Task<List<Formulario>> List() {
            return await _IFormulario.List();
        }

        public async Task<Formulario> SearchId(int Id) {
            return await _IFormulario.SearchId(Id);
        }

        public async Task Update(Formulario Object) {
            await _IFormulario.Update(Object);
        }
    }
}
